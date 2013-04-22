/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace WindowsFormsApplication2
{
    class xmlMessage
    {
	    public string type;
        public string version;
        public string command;
        public string name;
        public string email;
        public string homepage;
        public string host;
        public string body;

	    public xmlMessage(string command, string name, string email, string homepage, string host, string body)
	    {
            this.type = "PelleMsg";
            this.version = "1.0";
	        this.command = command;
	        this.name = name;
	        this.email = email;
	        this.homepage = homepage;
	        this.host = host;
	        this.body = body;
	    }
    }
    public class test
    {
        public void testXml()
        {
            xmlMessage[] msgs = new xmlMessage[4];
            msgs[0] = new xmlMessage("CommandSendMsg", "David", "david@go.com", "www.tfk.com", "HostPelle", "medelande av david");
            msgs[1] = new xmlMessage("CommandSendMsg", "Pelle", "Pelle@go.com", "www.tfk.com", "HostPelle", "medelande av pelle");
            msgs[2] = new xmlMessage("CommandSendMsg", "Erik", "Erik@go.com", "www.tfk.com", "HostPelle", "medelande av erik");
            msgs[3] = new xmlMessage("CommandSendMsg", "Micke", "Micke@go.com", "www.tfk.com", "HostPelle", "medelande av micke");
            int counter = 0;
            foreach (xmlMessage msg in msgs)
            {
                using (XmlWriter writer = XmlWriter.Create("message"+counter+".xml"))
                {
                    counter++;
                    writer.WriteStartDocument();
                    writer.WriteDocType("message", null, "message.dtd", null);// ~pierre funkar inte som adress..

                    writer.WriteStartElement("message");

                    writer.WriteStartElement("header");

                    writer.WriteStartElement("protocol");
                    writer.WriteElementString("type", msg.type);
                    writer.WriteElementString("version", msg.version);
                    writer.WriteElementString("command", msg.command);
                    writer.WriteEndElement();

                    writer.WriteStartElement("id");
                    writer.WriteElementString("name", msg.name);
                    writer.WriteElementString("email", msg.email);
                    writer.WriteElementString("homepage", msg.homepage);
                    writer.WriteElementString("host", msg.host);
                    writer.WriteEndElement();

                    writer.WriteEndElement();

                    writer.WriteElementString("body", msg.body);

                    writer.WriteEndElement();
                    writer.WriteEndDocument();

                }

                Console.WriteLine("xml skapad?");
            }//using
        }//testXml
    }//test
}
*/