/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Collections;

namespace winChatServer2
{
    public class Server
    {
        ServerForm form;

        public static Hashtable clientsList = new Hashtable();
        
        public Server(ServerForm f) { form = f;}

        public void hostServer(int sp)
        {
            Thread.CurrentThread.Name = "hostServerThread";
            int serverPort = sp;
            IPAddress ipAdress = IPAddress.Parse("127.0.0.1");
            TcpListener serverSocket = new TcpListener(ipAdress, serverPort);

            TcpClient clientSocket = default(TcpClient);

            serverSocket.Start();
            form.label2.Invoke(new ThreadStart(delegate { form.label2.Text = "Server running, IP: 127.0.0.1: " + form.portField.Text; }));
            Console.WriteLine("Chat Server Started!");
            while (true)
            {
                clientSocket = serverSocket.AcceptTcpClient();

                byte[] bytesFrom = new byte[10025];
                string dataFromClient = null;

                clientSocket.ReceiveBufferSize = 10025;
                clientSocket.GetStream().Read(bytesFrom, 0, (int)clientSocket.ReceiveBufferSize);
                dataFromClient = System.Text.Encoding.ASCII.GetString(bytesFrom);
                dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf("$"));

                clientsList.Add(dataFromClient, clientSocket);

                broadcast(dataFromClient + " Joined ", dataFromClient, false);

                Console.WriteLine(dataFromClient + " Joined chat room ");
                handleClinet client = new handleClinet();
                client.startClient(clientSocket, dataFromClient, clientsList, this);
            }
            clientSocket.GetStream().Close();
            clientSocket.Close();
            serverSocket.Stop();
            Console.WriteLine("exit");
            Console.ReadLine();
        }

        public void broadcast(string msg, string uName, bool flag)
        {
            foreach (DictionaryEntry Item in clientsList)
            {
                try
                {
                    TcpClient broadcastSocket;
                    broadcastSocket = (TcpClient)Item.Value;
                    NetworkStream broadcastStream = broadcastSocket.GetStream();
                    Byte[] broadcastBytes = null;

                    if (flag == true)
                    {
                        broadcastBytes = Encoding.ASCII.GetBytes(uName + " says : " + msg);
                    }
                    else
                    {
                        broadcastBytes = Encoding.ASCII.GetBytes(msg);
                    }

                    broadcastStream.Write(broadcastBytes, 0, broadcastBytes.Length);
                    broadcastStream.Flush();
                }
                catch (System.ObjectDisposedException)
                {
                    Console.WriteLine("errorrrr");
                    uName = (string)Item.Key;
                    clientsList.Remove(Item.Key);
                    broadcast(" disconnected from Chat Server!", uName, false);
                    return;
                }
            }


            this.form.chatField.Invoke(new ThreadStart(delegate
            {
                form.chatField.Text = form.chatField.Text + Environment.NewLine + " >> " + uName + " says : " + msg;
            }));
        }  //end broadcast function
    }//end Main class


    public class handleClinet
    {
        TcpClient clientSocket;
        string clNo;
        Hashtable clientsList;
        Server srv;

        public void startClient(TcpClient inClientSocket, string clineNo, Hashtable cList, Server s)
        {
            clientSocket = inClientSocket;
            clNo = clineNo;
            clientsList = cList;
            srv = s;
            Thread ctThread = new Thread(() => doChat(srv));
            ctThread.Start();
        }

        private void doChat(Server s)
        {
            srv = s;
            Thread.CurrentThread.Name = "doChatThread";
            byte[] bytesFrom = new byte[10025];
            string dataFromClient = null;

            while ((true))
            {
                try
                {
                    clientSocket.GetStream().Read(bytesFrom, 0, (int)clientSocket.ReceiveBufferSize);
                    dataFromClient = System.Text.Encoding.ASCII.GetString(bytesFrom);
                    dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf("$"));
                    Console.WriteLine("From client - " + clNo + " : " + dataFromClient + "indexOf" + dataFromClient.IndexOf("$"));

                    srv.broadcast(dataFromClient, clNo, true);
                }
                catch (System.ObjectDisposedException)
                {
                    srv.broadcast(" disconnected from Chat Server!", dataFromClient, false);
                    return;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("errorrrr" + ex.ToString());
                    clientsList.Remove(dataFromClient);
                    clientSocket.GetStream().Close();
                    clientSocket.Close();
                    srv.broadcast( " disconnected from Chat Server!", dataFromClient, false);
                    return;
                }
            }//end while
        }//end doChat
    } //end class handleClinet
}//end namespace
*/