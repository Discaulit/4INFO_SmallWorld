using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CS_SmallWorld;

namespace UnitTestSmallWorld
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodPlateau()
        {
            int taille = 5;
            PlateauConcret plateau = new PlateauConcret(taille);
            bool plateauOk = false;
            bool[] types = new bool[5];
            types[0] = types[1] = types[2] = types[3] = types[4] = false;

            for (int i = 0; i < taille; i++)
            {
                for (int j = 0; j < taille; j++)
                {
                    if (plateau.getCaseAt(new Position(i, j)) is CaseMontagneConcret)
                        types[0] = true;
                    if (plateau.getCaseAt(new Position(i, j)) is CasePlaineConcret)
                        types[1] = true;
                    if (plateau.getCaseAt(new Position(i, j)) is CaseDesertConcret)
                        types[2] = true;
                    if (plateau.getCaseAt(new Position(i, j)) is CaseEauConcret)
                        types[3] = true;
                    if (plateau.getCaseAt(new Position(i, j)) is CaseForetConcret)
                        types[4] = true;

                }
            }

            plateauOk = types[0] && types[1] && types[2] && types[3] && types[4];
            
            Assert.IsTrue(plateauOk);
        }

        [TestMethod]
        public void TestMethodPartie()
        {
            System.Collections.Generic.Dictionary<String,Peuple> players = new  System.Collections.Generic.Dictionary<String,Peuple>();
            // /!\ Pb de conception = Joueur demande un Peuple pour etre creer et Peuple demande un joueur ...
            
            //players.Add("Tom",new PeupleNainConcret());
            //Partie partie = new PartieConcret(
        }

    }
}
