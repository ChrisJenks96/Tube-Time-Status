using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace TubeProject
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            TubeXMLPull tubeXMLPull = new TubeXMLPull();
            //private credentials, directory to save the xml file too, app id and app key can be requested from TFL
            bool xmlPullSuccess = tubeXMLPull.Get(TubeCredentials.app_dir, TubeCredentials.app_id, TubeCredentials.app_key);
            if (xmlPullSuccess)
            {
                TubeXMLParser tubeXML = new TubeXMLParser();
                //parse and read the xml file
                if (tubeXML.Load(TubeCredentials.app_dir)){
                    tubeXML.Read();
                }
            }
        }
    }
}
