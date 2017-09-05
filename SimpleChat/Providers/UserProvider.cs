using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hospital.Models;
using System.Configuration;
using MySql.Data.MySqlClient;
namespace Hospital.Providers
{
    public class UserProvider
    {
        public static IEnumerable<User> GetList()
        {
            List<User> UserList = new List<User>();
            string connString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                string statement = "SELECT * FROM Users";

                MySqlCommand cmd = new MySqlCommand(statement, conn);

                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        User User = new User();
                        User.Id = reader.GetInt32("Id");
                        User.UserName = reader.GetString("UserName");
                        User.Password = reader.GetString("Password");
                        User.isOnline = reader.GetBoolean("isOnline");

                        UserList.Add(User);
                    }
                }
            }
            return UserList;
        }



        public static IEnumerable<User> GetList(string online)
        {
            List<User> UserList = new List<User>();
            string connString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                string statement = "SELECT * FROM Users where isOnline = true";

                MySqlCommand cmd = new MySqlCommand(statement, conn);

                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        User User = new User();
                        User.Id = reader.GetInt32("Id");
                        User.UserName = reader.GetString("UserName");
                        User.Password = reader.GetString("Password");
                        User.isOnline = reader.GetBoolean("isOnline");

                        UserList.Add(User);
                    }
                }
            }
            return UserList;
        }



        public static User GetUser(User u)
        {
            Security secure = new Security();
            u.Password = secure.HashSHA1(u.Password);

            List<User> UserList = new List<User>();
            string connString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                string statement = "SELECT * FROM Users";

                MySqlCommand cmd = new MySqlCommand(statement, conn);

                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        User User = new User();
                        User.UserName = reader.GetString("UserName");
                        User.Password = reader.GetString("Password");
                        if (u.UserName == User.UserName && u.Password == User.Password)
                        {

                            User.Id = reader.GetInt32("Id");
                            User.isOnline = reader.GetBoolean("isOnline");

                            return User;
                        }
        
                    }
                }
            }
            return null;
        }

        public static void UpdateUser(User User)
        {
            string connString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE `Users` SET `isOnline` = @isOnline WHERE `Users`.`Id` = @Id;";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@Id", User.Id);
                cmd.Parameters.AddWithValue("@isOnline", User.isOnline);

                cmd.ExecuteNonQuery();
            }
        }

        public static IEnumerable<User> GetList(int type)
        {

            List<User> UserList = new List<User>();
            string connString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();

                string statement = "";
                if (type == 1)
                    statement = "SELECT * FROM Users WHERE `isAdmin` = 1";
                else if (type == 2)
                    statement = "SELECT * FROM Users WHERE `isAdmin` = 0 AND `isDoctor` = 0";
                else
                    statement = "SELECT * FROM Users WHERE `isDoctor` = 1";

                MySqlCommand cmd = new MySqlCommand(statement, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        User User = new User();
                        User.Id = reader.GetInt32("Id");
                        User.UserName = reader.GetString("UserName");
                        User.Password = reader.GetString("Passwors");
                        User.isOnline = reader.GetBoolean("isOnline");


                        UserList.Add(User);
                    }
                }
            }
            return UserList;
        }

        internal static void InsertMessage(MessageC m)
        {
            string connString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(connString))
            {

                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO messages(idS, idR, message) VALUES(@idS, @idR, @message)";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@idS", m.IdS);
                cmd.Parameters.AddWithValue("@idR", m.IdR);
                cmd.Parameters.AddWithValue("@message", m.MessageS);

                cmd.ExecuteNonQuery();
            }
        }

        internal static IEnumerable<MessageC> GetMessages(MessageC msg)
        {
            List<MessageC> MessageList = new List<MessageC>();
            string connString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                string statement = "SELECT * FROM `messages` WHERE (idS = @u1 and idR = @u2) or(idS = @u2 and idR = @u1)";

                MySqlCommand cmd = new MySqlCommand(statement, conn);

                cmd.Parameters.AddWithValue("@u1", msg.IdR);
                cmd.Parameters.AddWithValue("@u2", msg.IdS);

                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        MessageC m = new MessageC();
                        m.Id = reader.GetInt32("Id");
                        m.IdR = reader.GetInt32("IdR");
                        m.IdS = reader.GetInt32("IdS");
                        m.MessageS = reader.GetString("message");
                        m.Seen = reader.GetBoolean("seen");

                        MessageList.Add(m);
                    }
                }
            }
            return MessageList;
        }

        public static User GetById(string id)
        {
            List<User> UserList = new List<User>();
            return UserList.FirstOrDefault(x => x.UserName == id);
        }

        public static void AddUser(User User)
        {
            Security secure = new Security();
            User.Password = secure.HashSHA1(User.Password);

            string connString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(connString)) {

                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO Users(UserName, Password) VALUES(@UserName, @Password)";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@UserName", User.UserName);
                cmd.Parameters.AddWithValue("@Password", User.Password);

                cmd.ExecuteNonQuery();
            }
        }
    }
}