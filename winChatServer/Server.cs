using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net;
using System.IO;
using System.Net.Sockets;
using System.Collections;

namespace winChatServer
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

            TcpClient tcpClient = default(TcpClient);

            serverSocket.Start();
            form.label2.Invoke(new ThreadStart(delegate { form.label2.Text = "Server running, IP: 127.0.0.1: " + form.portField.Text; }));
            Console.WriteLine("Chat Server Started!");
            while (true)
            {
                tcpClient = serverSocket.AcceptTcpClient();

                byte[] bytesFrom = new byte[tcpClient.ReceiveBufferSize];
                string dataFromClient = null;

                tcpClient.ReceiveBufferSize = tcpClient.ReceiveBufferSize;
                tcpClient.GetStream().Read(bytesFrom, 0, (int)tcpClient.ReceiveBufferSize);
                dataFromClient = System.Text.Encoding.ASCII.GetString(bytesFrom);
                dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf("$"));

                clientsList.Add(dataFromClient, tcpClient);

                broadcast(dataFromClient + " Joined ", dataFromClient, false);

                Console.WriteLine(dataFromClient + " Joined chat room ");
                handleClinet client = new handleClinet();
                client.startClient(tcpClient, dataFromClient, clientsList, this);
            }
            tcpClient.GetStream().Close();
            tcpClient.Close();
            serverSocket.Stop();
            Console.WriteLine("exit");
            Console.ReadLine();
        }

        public void broadcast(string msg, string uName, bool flag)
        {
            string printLine = msg;
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
                        printLine = uName + " says : " + msg;
                    }
                    if (printLine != "")
                    {
                        broadcastBytes = Encoding.ASCII.GetBytes(printLine);
                        broadcastStream.Write(broadcastBytes, 0, broadcastBytes.Length);
                        broadcastStream.Flush();
                    }
                }
                catch (System.ObjectDisposedException)
                {
                    Console.WriteLine("errorrrr");
                    uName = (string)Item.Key;
                    clientsList.Remove(Item.Key);
                    if (printLine == "" || msg.Length>=31 && (msg.Substring(msg.Length - 31, msg.Length) != " disconnected from Chat Server!"))
                        broadcast(uName + " disconnected from Chat Server!", uName, false);
                    return;
                }
            }//foreach
            this.form.chatField.Invoke(new ThreadStart(delegate
            {
                form.chatField.Text = form.chatField.Text + Environment.NewLine + " >> " + printLine;
                form.chatField.SelectionStart = form.chatField.Text.Length;
                form.chatField.ScrollToCaret();
            }));
        }  //end broadcast function
    }//end Main class


    public class handleClinet
    {
        TcpClient tcpClient;
        string clNo;
        Hashtable clientsList;
        Server srv;

        public void startClient(TcpClient inTcpClient, string clineNo, Hashtable cList, Server s)
        {
            tcpClient = inTcpClient;
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
            string messageFile = "message.xml";
            string dataFromClient = null;

            while ((true))
            {
                try
                {
                    int buffSize = 1024;
                    byte[] bytesFrom = new byte[buffSize];
                    tcpClient.GetStream().Read(bytesFrom, 0, buffSize);

                    dataFromClient = System.Text.Encoding.ASCII.GetString(bytesFrom);

                    string xmlText = dataFromClient.Replace("$", "");
                    xmlText = xmlText.Substring(0, xmlText.LastIndexOf(">")+1);
                    File.WriteAllText(messageFile, xmlText);
                    
                    xmlMessageReader xmr = new xmlMessageReader();
                    xmr.read(messageFile);

                    srv.broadcast(xmr.body, clNo, true);
                }
                catch (System.ObjectDisposedException)
                {
                    string leaverNick = dataFromClient;
                    srv.broadcast("", dataFromClient, false);
                    return;
                }
                
                catch (System.Xml.XmlException e)
                {
                    Console.WriteLine(e);
                    tcpClient.GetStream().Close();
                    tcpClient.Close();
                    srv.broadcast("", dataFromClient, false);
                    return;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("errorrrr" + ex.ToString());
                    tcpClient.GetStream().Close();
                    tcpClient.Close();
                    srv.broadcast("", dataFromClient, false);
                    return;
                }
            }//end while
        }//end doChat
    } //end class handleClinet
}//end namespace
