using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CS_SmallWorld;

namespace UnitTestSmallWorld
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int taille = 5;
            PlateauConcret plateau = new PlateauConcret(taille);
            bool plateauOk = false;
            bool[] types = new bool[5];
            types[0] = types[1] = types[2] = types[3] = types[4] = false;

            for (int i = 0; i < taille; i++)
                for (int j = 0; j < taille; j++)
                {
                     if (plateau.getCaseAt(new Position(i, j)).TypeTerrain == typeCase.t_montagne)
                        types[0] = true;
                     if (plateau.getCaseAt(new Position(i, j)).TypeTerrain == typeCase.t_plaine)
                        types[1] = true;
                     if (plateau.getCaseAt(new Position(i, j)).TypeTerrain == typeCase.t_desert)
                        types[2] = true;
                     if (plateau.getCaseAt(new Position(i, j)).TypeTerrain == typeCase.t_eau)
                        types[3] = true;
                    if (plateau.getCaseAt(new Position(i, j)).TypeTerrain == typeCase.t_foret)
                        types[4] = true;
                    
                }

            plateauOk = types[0] && types[1] && types[2] && types[3] && types[4];
            
            Assert.IsTrue(plateauOk);

        }
    }
}
