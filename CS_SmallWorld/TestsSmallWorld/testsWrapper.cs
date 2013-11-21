using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using wrapperLibSmallWorld;
using System.Collections.Generic;
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
            List<int> map = new WrapperLibsSmallWorld(10).getMap();

            //desertFound, eauFound, foretFound, montagneFound, plaineFound = false;
            bool[] typecase = {false,false,false,false,false};
            for (int i = 0; i < 10; i++)
            {
                //indique vrai lorsque le type de carte est rencontré
                typecase[map[i]] = true;
            }
            
            Assert.IsTrue(typecase[0]);
            Assert.IsTrue(typecase[1]);
            Assert.IsTrue(typecase[2]);
            Assert.IsTrue(typecase[3]);
            Assert.IsTrue(typecase[4]);
        }
    }
}
