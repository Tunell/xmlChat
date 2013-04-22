using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.IO;
using System.Xml;
using System.Xml.Schema;
//problem när man stänger server fönstret utan att stänga servern och sedan försökar skicka meddelande ifrån klient(lägg till detection om connection finns)
//även problem när man stänger client utan att disconnecta(lägg till detection om connection finns)
namespace WindowsFormsApplication2
{
    public class ClientProg
    {
        public TcpClient clientSocket = new TcpClient();
        public NetworkStream serverStream = default(NetworkStream);
        public string readData = null;
        Thread ctThread;
        ChatClientForm form;
        //test för filöverföring, ska ligga vid connect egentligen.
        string serverIP = "127.0.0.1";
        int serverPort = 400;
        xmlMessageSender xms;

        public ClientProg(ChatClientForm f) { form = f; }

        public bool connect(string srvIP, int srvPort, string n)
        {
            serverIP = srvIP;
            serverPort = srvPort;
            string nick = n;
            string xmlReadyNick = n.Trim(new char[]{'$'});
            for(;;)
                try
                {
                    clientSocket.Connect(srvIP, srvPort);
                    serverStream = clientSocket.GetStream();

                    byte[] outStream = System.Text.Encoding.ASCII.GetBytes(nick);
                    serverStream.Write(outStream, 0, outStream.Length);
                    serverStream.Flush();

                    ctThread = new Thread(getMessage);
                    ctThread.Start();

                    readData = "Conected to Chat Server!";
                    form.msg(readData);

                    xms = new xmlMessageSender(xmlReadyNick); 
                    return true;
                }
                catch (System.Net.Sockets.SocketException err)
                {
                    MessageBox.Show("Error connecting to server\n" + err);
                    return false;
                }
        }

        public void sendMsg(string msg)
        {
            xms.createMsg(msg);
            XmlDocument msgDoc = new XmlDocument();
            XmlTextReader reader = new XmlTextReader("message.xml");
            reader.WhitespaceHandling = WhitespaceHandling.None;
            reader.MoveToContent();
            reader.Read();
            msgDoc.Load("message.xml");
            string xmlMessage;
            using (var stringWriter = new StringWriter())
            using (var xmlTextWriter = XmlWriter.Create(stringWriter))
            {
                msgDoc.WriteTo(xmlTextWriter);
                xmlTextWriter.Flush();
                xmlMessage = stringWriter.GetStringBuilder().ToString();
                xmlTextWriter.Close();
                stringWriter.Close();
            }
            reader.Close();
            //Dumt försök att skicka xml:en som en fil
            //Byte[] outStream = new Byte[6000];
            //outStream = File.ReadAllBytes("message.xml");
            //serverStream.Write(outStream, 0, outStream.Length);

            //form.msg(xmlMessage);
            Encoding encoding = Encoding.UTF8;
            byte[] outStream = encoding.GetBytes(xmlMessage);
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();
        }

        public void getMessage()
        {
            Thread.CurrentThread.Name = "getMessageThread";
            int counter = 0;
            while (true)
            {
                try
                {
                    serverStream = clientSocket.GetStream();
                    counter++;
                    Console.WriteLine(counter);
                    int buffSize = 0;
                    byte[] inStream = new byte[clientSocket.ReceiveBufferSize];
                    buffSize = clientSocket.ReceiveBufferSize;
                    serverStream.Read(inStream, 0, buffSize);
                    string returndata = System.Text.Encoding.ASCII.GetString(inStream);
                    readData = "" + returndata;
                    form.msg(readData);
                }
                    
                catch (System.IO.IOException)
                {
                    Console.WriteLine("Disconnected");
                    return;
                }
                catch (System.InvalidOperationException)
                {
                    Console.WriteLine("Socket not connected");
                    return;
                }
                catch
                {
                    Console.WriteLine("Error!");
                    return;
                }
            }
        }

        public void disconnect()
        {
            form.msg("Disconnected from server!");
            serverStream.Close();
            clientSocket.Close();
        }

    }
}