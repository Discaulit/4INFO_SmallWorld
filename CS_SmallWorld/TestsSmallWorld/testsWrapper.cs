using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using wrapperLibSmallWorld;
//using CS_SmallWorld;

namespace TestsSmallWorld
{
    [TestClass]
    public class testsWrapper
    {
        [TestMethod]
        public void WrapperNonNull()
        {
            Assert.IsNotNull(new WrapperLibsSmallWorld(5));
        }

        [TestMethod]
        public void UneCaseDeChaqueType()
        {
             = new WrapperLibsSmallWorld(10).getMatrice();
            bool desertFound = false, eauFound = false, foretFound = false,
                montagneFound = false, plaineFound = false;
            
            Assert.IsTrue(desertFound);
            Assert.IsTrue(eauFound);
            Assert.IsTrue(foretFound);
            Assert.IsTrue(montagneFound);
            Assert.IsTrue(plaineFound);
        }
    }
}
