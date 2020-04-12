using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Net;
using System.IO;

namespace TubeProject
{
    public class TubeXMLPull
    {
        private bool Write(string dir, string text)
        {
            StreamWriter writer;
            try
            {
                writer = new StreamWriter(dir);
            }

            catch (System.UnauthorizedAccessException){
                return false;
            }

            writer.Write(text);
            writer.Close();
            return true;
        }

        public bool Get(string app_dir, string app_id, string app_key)
        {
            //make sure non of the strings are empty
            if (app_id.Length == 0 || app_key.Length == 0){
                return false;
            }
            //generate the URL for pulling the tube XML data (v2)
            string xmlURL = "https://tfl.gov.uk/tfl/syndication/feeds/TubeThisWeekend_v2.xml?app_id=";
            xmlURL += app_id;
            xmlURL += "&app_key=";
            xmlURL += app_key;

            WebRequest request = HttpWebRequest.Create(xmlURL);
            WebResponse response = request.GetResponse();
            //make sure the response got results before reading it in
            if (response.ContentLength == 0){
                return false;
            }

            //get the xml data from the web response
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string responseText = reader.ReadToEnd();
            reader.Close();
            //write the data to a local file so we can open and digest it
            if (!Write(app_dir, responseText)){
                return false;
            }

            else
                return true;
        }
    }
}
