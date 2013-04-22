/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.IO;

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

        public ClientProg(ChatClientForm f) { form = f; }

        public void sendMsg(string msg)
        {

            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(msg);
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();
        }

        public bool connect(string srvIP, int srvPort, string n)
        {
            serverIP = srvIP;
            serverPort = srvPort;
            string nick = n;
            for (; ; )
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
                    return true;
                }
                catch (System.Net.Sockets.SocketException err)
                {
                    MessageBox.Show("Error connecting to server\n" + err);
                    return false;
                }
        }

        public static void CopyStream(Stream input, Stream output)
        {
            byte[] buffer = new byte[8 * 1024];
            int len;
            while ((len = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                output.Write(buffer, 0, len);
            }
        }

        public void receiveFile()
        {
            Thread.CurrentThread.Name = "receiveFileThread";
            while (true)
            {
                try
                {
                    serverStream = clientSocket.GetStream();
                    int buffSize = 0;
                    byte[] inStream = new byte[10025];
                    clientSocket.ReceiveBufferSize = 10025;
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

        public void sendFile()
        {
            IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddr = IPAddress.Parse(serverIP);
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, serverPort);
            Socket client = new Socket(AddressFamily.InterNetwork,
            SocketType.Stream, ProtocolType.Tcp);

            // Connect the socket to the remote endpoint.
            client.Connect(ipEndPoint);
            string fileName = "C://Users/Pelle/Dropbox/Skola/Stationära enheter/ConsoleApplication2/WindowsFormsApplication2/bin/Debug/message.xml";

            // Send file fileName to remote device
            Console.WriteLine("Sending {0} to the host.", fileName);
            client.SendFile(fileName);

            // Release the socket.
            client.Shutdown(SocketShutdown.Both);
            client.Close();
        }

        public void getMessage()
        {
            Thread.CurrentThread.Name = "getMessageThread";
            int counter = 0;
            while (true)
            {
                try
                {
                    counter++;
                    Console.WriteLine(counter);
                    serverStream = clientSocket.GetStream();
                    int buffSize = 0;
                    byte[] inStream = new byte[10025];
                    clientSocket.ReceiveBufferSize = 10025;
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

        public void dissconnect()
        {
            form.msg("Disconnected from server!");
            serverStream.Close();
            clientSocket.Close();
        }

    }
}
*/