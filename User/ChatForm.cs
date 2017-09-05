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

        delegate void SetTextCallback(string text);

        private void addText(string text)
        {
            if (listBox1.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(addText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                listBox1.Items.Add(text);
            }
        }

        private void clearText(string s)
        {
            if (this.IsDisposed)
                return;

            if (listBox1.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(clearText);
                this.Invoke(d, new object[] { "" });
            }
            else
            {
                this.listBox1.Items.Clear();
            }
        }
        private void refresh()
        {
            IEnumerable<MessageC> messages = getMessages(new MessageC() { IdS = u1.Id, IdR = u2.Id });
            clearText("");
            if (messages != null)
            {
                foreach (MessageC msg in messages)
                {
                    if (msg.IdS == u1.Id)
                    {
                        addText("Me");
                    }
                    else
                    {
                        addText(u2.UserName + ":");
                    }
                    addText(msg.MessageS);
                    addText("");
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
            textBox1.Text = "";
        }

        public ChatForm(User user1, User user2)
        {
            InitializeComponent();
            this.Text = user2.UserName;

            this.u1 = user1;
            this.u2 = user2;

            new Thread(threadFunc).Start();

            //refresh();

        }

        private void button2_Click(object sender, EventArgs e)
        {
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
