using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TubeProject
{
    [TestClass]
    public class TubeXMLPull_Test
    {
        private readonly TubeXMLPull tubeXMLPullTest;
        
        public TubeXMLPull_Test()
        {
            tubeXMLPullTest = new TubeXMLPull();
        }

        [TestMethod]
        public void Get_Test()
        {
            bool ret = tubeXMLPullTest.Get(TubeCredentials.app_dir, TubeCredentials.app_id, TubeCredentials.app_key);
            Assert.IsTrue(ret, "Func: 'tubeXMLPull::Get' - should be true");
            ret = tubeXMLPullTest.Get("C:/Test.XML", TubeCredentials.app_id, TubeCredentials.app_key);
            Assert.IsFalse(ret, "Func: 'tubeXMLPull::Get' - should be false - Permission Denied for C drive root");
            ret = tubeXMLPullTest.Get("", "", "");
            Assert.IsFalse(ret, "Func: 'tubeXMLPull::Get' - should be false - Empty Parameters");
        }
    }
}
