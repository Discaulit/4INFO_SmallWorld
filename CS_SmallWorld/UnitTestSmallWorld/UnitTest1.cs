using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CS_SmallWorld;
using wrapperLibSmallWorld;
using System.Collections.Generic;

namespace UnitTestSmallWorld
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodPlateau()
        {
            int taille = 5;
            WrapperLibsSmallWorld wrapper = new WrapperLibsSmallWorld(taille);
            
            PlateauConcret plateau = new PlateauConcret(taille, wrapper);
            bool plateauOk = false;
            bool[] types = {false, false, false, false, false};

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
        public void TestMethodCombat()
        {
            int taille = 5;
            WrapperLibsSmallWorld wrapper = new WrapperLibsSmallWorld(taille);
            Combat combat = new CombatConcret(wrapper);
            bool[] resDuCombat =  { false, false, false };
            bool resFinal = false;
            int uniteAttaque, uniteDef;


            //Test plusieurs fois pour savoir si on peut avoir atq gagne, def gagne et match nul
            for (int i = 0; i < 20; i++)
            {
                uniteAttaque = 5;
                uniteDef = 5;
                /* Ceci est un copier-coller quasi identique du code de CombatConcret.lancerCombat(Unite atq, Case caseDef).
                 * Le but est de tester l'algo de combat, sans devoir passer par la création d'une Unite et donc d'un Peuple,
                 *  d'une Case et donc d'un Plateau etc.
                 */

                /* Avec Atq = 2, Def = 1, l'attaquant a 100% de chance de gagner ...
                 * avec 3, 2 => 75%
                 * avec 4,3 => 66%
                */
                List<int> resCombat = wrapper.combatResult(uniteAttaque, uniteDef, 4, 3, 5);
                uniteAttaque = resCombat[0];
                uniteDef = resCombat[1];

                if (uniteAttaque > 0)
                {
                    if (uniteDef > 0)
                        resDuCombat[1] = true; //Atq vivant, Def vivant = match null
                    else
                        resDuCombat[0] = true; // Atq vivant, Def mort = victoire attaquant
                }
                else
                    resDuCombat[2] = true; // Atq mort = victoire def
            }

            resFinal = resDuCombat[0] && resDuCombat[1];
            Assert.IsTrue(resFinal); // On verifie que le defenseur a au moins une chance de faire match nul
            
        }

        /*[TestMethod]
        public void TestMethodPartie()
        {
            System.Collections.Generic.Dictionary<String,Peuple> players = new  System.Collections.Generic.Dictionary<String,Peuple>();
            // /!\ Pb de conception = Joueur demande un Peuple pour etre creer et Peuple demande un joueur ...
            
            //players.Add("Tom",new PeupleNainConcret());
            //Partie partie = new PartieConcret(
        }*/

    }
}
