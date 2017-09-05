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

namespace Administrator
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AdminForm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                User user = new User() {UserName = textBox1.Text, Password = textBox2.Text};

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:50086/");

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.PostAsJsonAsync("api/user", user).Result;

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Operation succeded");
                }
                else
                {
                    MessageBox.Show("Operation failed");
                }
            }

            catch (Exception) { MessageBox.Show("Date invalide."); }

        }

       
    }
}