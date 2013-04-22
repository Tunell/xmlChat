using System;
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

    public class xmlMessageSender
    {
        public xmlMessageSender(string name){this.name=name;}
        string command = "sendMsg";
        string email = "pelle@mailpunktse";
        string name;
        string homepage = "www.tfk.com";
        string host= "pelle";
        public void createMsg(string body)
        {   xmlMessage msg = new xmlMessage(command, name, email, homepage, host, body);
                using (XmlWriter writer = XmlWriter.Create("message.xml"))
                {
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

                Console.WriteLine("xml skapad?");
            }//using
        }//createMsg
    }//xmlMessageSender
}
