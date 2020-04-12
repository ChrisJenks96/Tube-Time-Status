using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace TubeProject
{
    public class TubeXMLParser
    {
        private XmlTextReader tubeXMLFile;
        public bool Load(string filename)
        {
            tubeXMLFile = new XmlTextReader(filename);
            try
            {
                if (tubeXMLFile.Read())
                {
                    //reading the first line tells us the file is open
                    //we then reset the state and start again for actual reading of the data
                    tubeXMLFile.ResetState();
                    return true;
                }
            }

            catch (System.IO.FileNotFoundException){
                return false;
            }

            return false;
        }

        //read the line sub elements
        private void ReadTubeLines()
        {
            //read the inner structure of the line
            XmlReader inner = tubeXMLFile.ReadSubtree();
            inner.ReadToFollowing("Name");
            Console.WriteLine(inner.ReadElementContentAsString());
            //get the status of the line
            inner.ReadToFollowing("Status");
            inner.ReadStartElement();
            Console.WriteLine(inner.ReadElementContentAsString());
            //read any additional messages for the line
            inner.ReadToFollowing("Message");
            inner.ReadStartElement();
            Console.WriteLine(inner.ReadElementContentAsString());
            inner.Close();
        }

        public void Read()
        {
            while (tubeXMLFile.Read()){
                switch (tubeXMLFile.Name)
                {
                    //a general title for the tube xml document
                    case "DisplayTitle": 
                        Console.WriteLine(tubeXMLFile.ReadElementContentAsString());
                        break;

                    //the date the information was issued
                    case "PublishDateTime":
                        Console.WriteLine(tubeXMLFile.ReadElementContentAsString());
                        break;
                        
                    //the tube line information
                    case "Line":
                        ReadTubeLines();
                        break;
                }
            }

            tubeXMLFile.Close();
        }
    }
}
