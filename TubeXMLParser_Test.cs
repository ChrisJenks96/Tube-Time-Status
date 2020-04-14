using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TubeProject
{
    [TestClass]
    public class TubeXMLParser_Test
    {
        private readonly TubeXMLParser tubeXMLTest;
        
        public TubeXMLParser_Test()
        {
            tubeXMLTest = new TubeXMLParser();
        }

        [TestMethod]
        public void LoadFile_Test()
        {
            bool ret = tubeXMLTest.LoadFile("TubeThisWeekend_v2.xml");
            Assert.IsTrue(ret, "Func: 'tubeXML::LoadFile(TubeThisWeekend_v2.xml)' - should be true");
            ret = tubeXMLTest.LoadFile("notafilewehave.xml");
            Assert.IsFalse(ret, "Func: 'tubeXML::LoadFile(notafilewehave.xml)' - should be false");
        }
    }
}
