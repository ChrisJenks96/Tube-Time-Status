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
        public void Load_Test()
        {
            bool ret = tubeXMLTest.Load("TubeThisWeekend_v1.xml");
            Assert.IsTrue(ret, "Func: 'tubeXML::Load' - should be true");
            ret = tubeXMLTest.Load("notafilewehave.xml");
            Assert.IsFalse(ret, "Func: 'tubeXML::Load' - should be false");
        }

        [TestMethod]
        public void Read_Test()
        {

        }
    }
}
