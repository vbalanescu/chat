using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
using System.Threading;

namespace User
{
    public partial class UserForm : Form
    {
        public User u;
        public UserForm(User u)
        {
            InitializeComponent();
            this.u = u;
            this.Text = u.UserName;
            updateUser();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private bool updateUser() {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:50086/");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.PostAsJsonAsync("api/updateUser", u).Result;

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        private IEnumerable<User> getUsers() {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:50086/");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("api/User").Result;

            if (response.IsSuccessStatusCode)
            {
                var users = response.Content.ReadAsAsync<IEnumerable<User>>().Result;
                return users;
            }

            return null;
        }

        private IEnumerable<User> getOnlineUsers()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:50086/");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.PostAsJsonAsync("api/onlineUsers", "").Result;

            if (response.IsSuccessStatusCode)
            {
                var users = response.Content.ReadAsAsync<IEnumerable<User>>().Result;
                return users;
            }

            return null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //   try
            {
                IEnumerable<User> users = getUsers();
                dataGridView1.DataSource = users;
                dataGridView1.Columns.Remove("Password");
                dataGridView1.Columns.Remove("isOnline");
            }
            // catch (Exception) { MessageBox.Show("Date invalide."); }
        }


        protected override void OnClosed(EventArgs e)
        {
            u.isOnline = false;
            updateUser();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //   try
            {
                IEnumerable<User> users = getOnlineUsers();
                dataGridView1.DataSource = users;
                dataGridView1.Columns.Remove("Password");
                dataGridView1.Columns.Remove("isOnline");
            }
            // catch (Exception) { MessageBox.Show("Date invalide."); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            User User2 = null;

            string UserName = textBox1.Text;

            if (UserName == this.u.UserName)
            {
                MessageBox.Show("Introduceti un user diferit de dvs.!");
                return;
            }

            IEnumerable<User> users = getOnlineUsers();

            foreach(User u in users)
            {
                if(u.UserName == UserName)
                {
                    User2 = u;
                    break;
                }
            }

            if(User2 == null)
            {
                MessageBox.Show("Nu exista online acest user!");
                return;
            }

            ChatForm chat = new ChatForm(this.u, User2);
            chat.Visible = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
