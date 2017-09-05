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
    public partial class ChatForm : Form
    {
        User u1, u2;

        private IEnumerable<MessageC> getMessages(MessageC m)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:50086/");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.PostAsJsonAsync("api/getMessages", m).Result;

            if (response.IsSuccessStatusCode)
            {
                var messages = response.Content.ReadAsAsync<IEnumerable<MessageC>>().Result;
                return messages;
            }

            return null;
        }

        private bool sendMessage(MessageC m)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:50086/");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.PostAsJsonAsync("api/sendMessage", m).Result;

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

    private void refresh()
        {
            IEnumerable<MessageC> messages = getMessages(new MessageC() { IdS = u1.Id, IdR = u2.Id });
            this.listBox1.Items.Clear();
            if (messages != null)
            {
                foreach (MessageC msg in messages)
                {
                    if (msg.IdS == u1.Id)
                    {
                        this.listBox1.Items.Add("Me:");
                    }
                    else
                    {
                        this.listBox1.Items.Add(u2.UserName+":");
                    }
                    this.listBox1.Items.Add(msg.MessageS);
                    this.listBox1.Items.Add("");
                }
            }
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageC m = new MessageC() { IdS = u1.Id, IdR = u2.Id, MessageS = textBox1.Text };
            sendMessage(m);
        }

        public ChatForm(User user1, User user2)
        {
            InitializeComponent();
            this.Text = user2.UserName;

            this.u1 = user1;
            this.u2 = user2;

        new Thread(threadFunc).Start();

        refresh();

        }
        private void threadFunc()
        {
            while (true)
            {
                // handle.WaitOne();
                Thread.Sleep(1000);
                refresh();
            }
        }
    }
}
