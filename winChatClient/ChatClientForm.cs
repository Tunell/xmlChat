using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;


namespace WindowsFormsApplication2
{
    public partial class ChatClientForm : Form
    {
        ClientProg client;

        public ChatClientForm()
        {
            InitializeComponent();
        }

        private void sendMsgButtonClick(object sender, EventArgs e)
        {
            client.sendMsg(messageField.Text + "$");
            this.messageField.Text= "";
        }

        private void senMsgKeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case '\r':
                    sendMsgButtonClick(sender, e);
                    break;
            }
        }

        public void msg(string readData)
        {
            if (this.InvokeRequired)
                this.Invoke((MethodInvoker)delegate
                {
                    msg(readData);
                });
            else
                chatField.Text = chatField.Text + Environment.NewLine + " >> " + readData;

                this.chatField.SelectionStart = this.chatField.Text.Length;
                this.chatField.ScrollToCaret();
        }

        private void connectButtonClick(object sender, EventArgs e)
        {
            client = new ClientProg(this);
            new clientConnectForm(this, client).Show();

        }

        private void dissconButtonClick(object sender, EventArgs e)
        {
            client.disconnect();

            connectButton.Visible = true;
            button1.Visible = false;
            messageField.Enabled = false;
            sendButton.Enabled = false;
            label1.Text = "";
            Text = "Chat Client";
        }
    }
}
