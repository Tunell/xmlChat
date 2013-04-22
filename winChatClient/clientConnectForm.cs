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
    public partial class clientConnectForm : Form
    {
        string serverIP;
        int serverPort;
        ChatClientForm form;
        ClientProg client;

        public clientConnectForm(ChatClientForm f1, ClientProg c)
        {   
            client = c;
            form = f1;
            InitializeComponent();
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            string nick = nickField.Text + "$";
            //string nick = nickField.Text;
            serverIP = IPField.Text;
            try
            {
                serverPort = int.Parse(portField.Text);
            }//end try
            catch (System.FormatException err)
            {
                MessageBox.Show("Server Port: can only contain numbers");
                return;
            }//end catch
            if (client.connect(serverIP, serverPort, nick))
            {
                form.connectButton.Visible = false;
                form.button1.Visible = true;
                form.messageField.Enabled = true;
                form.sendButton.Enabled = true;
                form.label1.Text = "Connected: " + serverIP + " : " + serverPort;
                form.Text = "Connected to: " + serverIP + " Port : " + serverPort;
                form.messageField.Focus();
                this.Close();
                xmlMessageSender msg = new xmlMessageSender(nick);

            }
        }

        private void nickField_KeyUp(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case '\r':
                connectButton_Click(sender, e);
                break;
            }
        }
    }
}
