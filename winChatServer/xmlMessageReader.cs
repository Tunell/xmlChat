using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.IO;

namespace winChatServer
{
    class xmlMessageReader
    {
        //dessa borde antagligen vara privata?
        public string type;
        public string version;
        public string command;
        public string name;
        public string email;
        public string homepage;
        public string host;
        public string body;

        public void read(string fileName)
        {
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.DtdProcessing = DtdProcessing.Parse;
            settings.ValidationType = ValidationType.DTD;
            settings.ValidationEventHandler += new ValidationEventHandler(ValidationCallBack);
            using (XmlReader reader = XmlReader.Create(fileName, settings))
            {
                while (reader.Read())
                {
                    // Only detect start elements.
                    if (reader.IsStartElement())
                    {
                        // Get element name and switch on it.
                        switch (reader.Name)
                        {
                            case "name":
                                if (reader.Read())
                                {
                                    name = reader.Value.Trim();
                                }
                                break;
                            case "body":
                                if (reader.Read())
                                {
                                    body = reader.Value.Trim();
                                }
                                break;
                            case "command":
                                if (reader.Read())
                                {
                                    command = reader.Value.Trim();
                                }
                                break;
                        }//switch
                    }//if
                }//while
            }//using
            return;
        }//read

        // Display any validation errors.
        private static void ValidationCallBack(object sender, ValidationEventArgs e)
        {
            Console.WriteLine("Validation Error: {0}", e.Message);
        }
    }//xmlMessageReader
}//namespace
