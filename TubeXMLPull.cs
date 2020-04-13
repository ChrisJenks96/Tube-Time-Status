using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Net;
using System.IO;
using System.Windows.Forms;

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

        //https://stackoverflow.com/questions/1366848/httpwebrequest-getresponse-throws-webexception-on-http-304/1366869#1366869
        //Work around for web exception being thrown when the http request is valid
        private HttpWebResponse GetHttpResponse(HttpWebRequest request)
        {
            try
            {
                return (HttpWebResponse)request.GetResponse();
            }

            catch (WebException ex) when (ex.Status == WebExceptionStatus.ProtocolError && ex.Response != null){
                return (HttpWebResponse)ex.Response;
            }
        }

        public bool Get(string app_dir, string app_id, string app_key)
        {
            //make sure non of the strings are empty
            if (app_id.Length == 0 || app_key.Length == 0){
                MessageBox.Show("App ID/App Key Length: 0");
                return false;
            }

            //This is the fix - sets the security protocol used by the ServicePoint objects
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            WebResponse response;
            //generate the URL for pulling the tube XML data (v2)
            string xmlURL = "https://tfl.gov.uk/tfl/syndication/feeds/TubeThisWeekend_v2.xml?app_id=";
            xmlURL += app_id;
            xmlURL += "&app_key=";
            xmlURL += app_key;

            try
            {
                //try the modified http response function
                response = GetHttpResponse((HttpWebRequest)WebRequest.Create(xmlURL));// request.GetResponse();
            }

            catch (System.Net.WebException){
                MessageBox.Show("System.Net.WebException: Check App ID and App Key");
                return false;
            }

            //make sure the response got results before reading it in
            if (response.ContentLength == 0){
                MessageBox.Show("WebResponse.ContentLength: 0");
                return false;
            }

            //get the xml data from the web response
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string responseText = reader.ReadToEnd();
            reader.Close();
            //write the data to a local file so we can open and digest it
            if (!Write(app_dir, responseText)){
                MessageBox.Show("TubeXMLPull.Write: Could not write to " + app_dir);
                return false;
            }

            else
                return true;
        }
    }
}
