using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace winChatServer
{
    public partial class ServerForm : Form
    {

        public ServerForm()
        {
            InitializeComponent();
        }

        private void hostButton_Click(object sender, EventArgs e)
        {
            int serverPort;
            try
            {
                serverPort = int.Parse(portField.Text);
            }
            catch (System.FormatException err)
            {
                MessageBox.Show("Server Port: can only contain numbers");
                return;
            }
            Server srv = new Server(this);
            Thread connectThread = new Thread(() => srv.hostServer(serverPort));
            connectThread.Start();
        }//end hostbutton
    }//end Main class
}//end namespace