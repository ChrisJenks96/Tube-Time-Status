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
            TubeXMLParser tubeXML = new TubeXMLParser();
            //parse and read the xml file
            string XMLPath = "TubeThisWeekend_v1.xml";
            if (tubeXML.Load(XMLPath)){
                tubeXML.Read();
            }
        }
    }
}
