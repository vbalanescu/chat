using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
using Administrator;
using User;

namespace LogIn
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            User.User u = new User.User() { UserName = textBox1.Text, Password = textBox2.Text, isOnline = true};
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:50086/");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


            HttpResponseMessage response = client.PostAsJsonAsync("api/getUser", u).Result;

            if (response.IsSuccessStatusCode)
            {
                u = response.Content.ReadAsAsync<User.User>().Result;
                if (u == null)
                {
                    MessageBox.Show("Date invalide!");
                    return;
                }
                {
                    if (u.isOnline == true)
                    {
                        MessageBox.Show("Sunteti deja logat!");
                    }
                    else
                    {
                        u.isOnline = true;
                        UserForm userForm = new UserForm(u);
                        userForm.Show();
                    }
                }
            }
    }

        private void button2_Click(object sender, EventArgs e)
        {
            Register adminForm = new Register();
            adminForm.Show();
        }
    }
}
