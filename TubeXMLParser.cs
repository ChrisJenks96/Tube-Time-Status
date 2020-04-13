using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Xml;

namespace TubeProject
{
    public class TubeXMLParser
    {
        private XmlTextReader tubeXMLFile;
        private string tubeXMLDataDate;

        public string GetTubeXMLDataDate(){
            return tubeXMLDataDate;
        }

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
        private bool ReadTubeLines(DataTable dt)
        {
            string[] data = new string[3];
            //read the inner structure of the line
            XmlReader inner = tubeXMLFile.ReadSubtree();
            if (inner.ReadToFollowing("Name")){
                data[0] = inner.ReadElementContentAsString();
            }

            else
            {
                Console.WriteLine("No 'Name' Element in 'Line' descendant");
                inner.Close();
                return false;
            }

            //get the status of the line
            if (inner.ReadToFollowing("Status")){
                inner.ReadStartElement();
                data[1] = inner.ReadElementContentAsString();
                //read any additional messages for the line
                if (inner.ReadToFollowing("Message")){
                    inner.ReadStartElement();
                    data[2] = inner.ReadElementContentAsString();
                    //message is last bit of information we need, so add the rows here as we
                    //have all the other bits of information
                    dt.Rows.Add(data[0], data[1], data[2]); 
                }

                else
                {
                    Console.WriteLine("No 'Message' Element in 'Status' descendant");
                    inner.Close();
                    return false;
                }
            }

            else
            {
                Console.WriteLine("No 'Status' Element in 'Line' descendant");
                inner.Close();
                return false;
            }
            
            inner.Close();
            return true;
        }

        public void Read(DataTable dt)
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
                        tubeXMLDataDate = tubeXMLFile.ReadElementContentAsString();
                        break;
                        
                    //the tube line information
                    case "Line":
                        ReadTubeLines(dt);
                        break;
                }
            }

            tubeXMLFile.Close();
        }
    }
}
