using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TEsting
{
    [TestClass]
    public class UnitTest1
    {
        private char[][] StringArrayToCharArray(string[] arr)
        {
            return arr.Select(s => s.ToCharArray()).ToArray();
        }

        [TestMethod]
        public void Basic()
        {
            var c = new[] { "-###-####-" };
            var count = Program.CountStarsInMap(StringArrayToCharArray(c));
            Assert.AreEqual(count, 3);
        }

        [TestMethod]
        public void F24()
        {
            var c = new[]
            {
                "####--#--##",
                "##---##--##", 
                "-##-##--###",
                "----##-#-##"
            };
            var count = Program.CountStarsInMap(StringArrayToCharArray(c));
            Assert.AreEqual(count, 3);
        }

        [TestMethod]
        public void None()
        {
            var c = new[] { "----",
                            "##--",
                            "#-#-",
                            "##--",
                            "####"
            };
            var count = Program.CountStarsInMap(StringArrayToCharArray(c));
            Assert.AreEqual(count, 2);
        }

        [TestMethod]
        public void F23()
        {
            var c = new[] { "#-#-",
                            "#---",
                            "####",
                            "####"
            };
            var count = Program.CountStarsInMap(StringArrayToCharArray(c));
            Assert.AreEqual(count, 1);
        }

        [TestMethod]
        public void Border()
        {
            var c = new[] { "-##-",
                            "-##-",
                            "-##-",
                            "----"
            };
            var count = Program.CountStarsInMap(StringArrayToCharArray(c));
            Assert.AreEqual(count, 1);
        }

        [TestMethod]
        public void SingleColumn()
        {
            var c = new[] { "-", "-", "-", "-", "-", "-", "-", "-", "-", "-" };
            var count = Program.CountStarsInMap(StringArrayToCharArray(c));
            Assert.AreEqual(count, 1);
        }

        [TestMethod]
        public void Spiral()
        {
            var c = new[] { "-##",
                            "--#",
                            "#--",
                            "#-#",
                            "--#" };
            var count = Program.CountStarsInMap(StringArrayToCharArray(c));
            Assert.AreEqual(count, 1);
        }

        [TestMethod]
        public void Square()
        {
            var c = new[] { "----",
                            "----"
            };
            var count = Program.CountStarsInMap(StringArrayToCharArray(c));
            Assert.AreEqual(count, 1);
        }

        [TestMethod]
        public void ParadoxExample1()
        {
            var c = new[]
            {
                "#################---",
                "##-###############--",
                "#---################",
                "##-#################",
                "########---#########",
                "#######-----########",
                "########---#########",
                "##################--",
                "#################---",
                "##################-#",
            };
            var count = Program.CountStarsInMap(StringArrayToCharArray(c));
            Assert.AreEqual(count, 4);
        }

        [TestMethod]
        public void ParadoxExample2()
        {
            var c = new[]
            {
                "#-########",
                "----------",
                "#-########"
            };
            var count = Program.CountStarsInMap(StringArrayToCharArray(c));
            Assert.AreEqual(count, 1);
        }

        [TestMethod]
        public void SingleStar()
        {
            var c = new[] { "-" };
            var count = Program.CountStarsInMap(StringArrayToCharArray(c));
            Assert.AreEqual(count, 1);
        }

        [TestMethod]
        public void SingleNone()
        {
            var c = new[] { "#" };
            var count = Program.CountStarsInMap(StringArrayToCharArray(c));
            Assert.AreEqual(count, 0);
        }

        [TestMethod]
        public void ParadoxExampleLinked()
        {
            var c = new[]
            {
                "#################---",
                "##-###############--",
                "#---################",
                "##-------###########",
                "########---#########",
                "#######-----########",
                "########---#########",
                "##################--",
                "#################---",
                "##################-#",
            };
            var count = Program.CountStarsInMap(StringArrayToCharArray(c));
            Assert.AreEqual(count, 3);
        }

        [TestMethod]
        public void OnlyLastLine()
        {
            var c = new[]
            {
                "####",
                "####",
                "----"
            };

            var count = Program.CountStarsInMap(StringArrayToCharArray(c));
            Assert.AreEqual(count, 1);

            c = new[]
            {
                "####",
                "####",
                "-#-#"
            };
            count = Program.CountStarsInMap(StringArrayToCharArray(c));
            Assert.AreEqual(count, 2);

            c = new[]
            {
                "####",
                "####",
                "-#--"
            };
            count = Program.CountStarsInMap(StringArrayToCharArray(c));
            Assert.AreEqual(count, 2);
        }

        [TestMethod]
        public void ParadoxExample2Mutated()
        {
            var c = new[]
            {
                "#----------",
                "#-########-",
                "---------#-",
                "#-#########"
            };
            var count = Program.CountStarsInMap(StringArrayToCharArray(c));
            Assert.AreEqual(count, 1);
        }

        [TestMethod]
        public void H()
        {
            var c = new[]
            {
                "##########",
                "#-##--##-#",
                "#-######-#",
                "#--------#",
                "#-######-#",
                "#-######-#",
                "#-######-#",
            };
            var count = Program.CountStarsInMap(StringArrayToCharArray(c));
            Assert.AreEqual(count, 2);
        }

        [TestMethod]
        public void N()
        {
            var c = new[]
            {
                "#--------#",
                "#-######-#",
                "#-######-#",
                "#-######-#",
            };
            var count = Program.CountStarsInMap(StringArrayToCharArray(c));
            Assert.AreEqual(count, 1);
        }

        [TestMethod]
        public void E()
        {
            var c = new[]
            {
                "#-------#",
                "#-#######",
                "#----####",
                "#-#######",
                "#------##",
            };
            var count = Program.CountStarsInMap(StringArrayToCharArray(c));
            Assert.AreEqual(count, 1);
        }

        [TestMethod]
        public void ReverseE()
        {
            var c = new[]
            {
                "#------#",
                "######-#",
                "#------#",
                "######-#",
                "#------#",
            };
            var count = Program.CountStarsInMap(StringArrayToCharArray(c));
            Assert.AreEqual(count, 1);
        }

        [TestMethod]
        public void ReverseE2()
        {
            var c = new[]
            {
                "#------#",
                "######-#",
                "#-------",
                "######-#",
                "#------#",
            };
            var count = Program.CountStarsInMap(StringArrayToCharArray(c));
            Assert.AreEqual(count, 1);
        }

        [TestMethod]
        public void ReverseE3()
        {
            var c = new[]
            {
                "#------#",
                "#-####-#",
                "######-#",
                "#-------",
                "######-#",
                "#------#",
            };
            var count = Program.CountStarsInMap(StringArrayToCharArray(c));
            Assert.AreEqual(count, 1);
        }

        [TestMethod]
        public void Close()
        {
            var c = new[]
            {
                "##-###",
                "#-####",
                "##---#",
                "######",
                "#-----",
            };
            var count = Program.CountStarsInMap(StringArrayToCharArray(c));
            Assert.AreEqual(count, 4);
        }

        [TestMethod]
        public void F1()
        {
            var c = new[]
            {
                "#-####",
                "#-####",
                "#-#--#",
                "#-###-",
                "#-----",
            };
            var count = Program.CountStarsInMap(StringArrayToCharArray(c));
            Assert.AreEqual(count, 2);
        }

        [TestMethod]
        public void F2()
        {
            var c = new[]
            {
                "#-####",
                "#---##",
                "#-#--#",
                "#-###-",
                "#-----",
            };
            var count = Program.CountStarsInMap(StringArrayToCharArray(c));
            Assert.AreEqual(count, 1);
        }

        [TestMethod]
        public void F3()
        {
            var c = new[]
            {
                "#-####",
                "#---##",
                "#-#---",
                "#-###-",
                "#-----",
            };
            var count = Program.CountStarsInMap(StringArrayToCharArray(c));
            Assert.AreEqual(count, 1);
        }

        [TestMethod]
        public void F4()
        {
            var c = new[]
            {
                "#-####",
                "#-#---",
                "#-###-",
                "#-###-",
                "#---#-",
            };
            var count = Program.CountStarsInMap(StringArrayToCharArray(c));
            Assert.AreEqual(count, 2);
        }

        [TestMethod]
        public void F5()
        {
            var c = new[]
            {
                "#-####",
                "#-#---",
                "#-###-",
                "#-###-",
                "#-----",
            };
            var count = Program.CountStarsInMap(StringArrayToCharArray(c));
            Assert.AreEqual(count, 1);
        }

        [TestMethod]
        public void F73()
        {
            var c = new[]
            {
                "#----#",
                "####-#",
                "#--#-#",
                "##---#",
                "######",
            };
            var count = Program.CountStarsInMap(StringArrayToCharArray(c));
            Assert.AreEqual(count, 1);
        }

        [TestMethod]
        public void F51()
        {
            var c = new[]
            {
                "#-#####",
                "#-##---",
                "#-#-##-",
                "######-",
                "-##----",
            };
            var count = Program.CountStarsInMap(StringArrayToCharArray(c));
            Assert.AreEqual(count, 4);
        }

        [TestMethod]
        public void F52()
        {
            var c = new[]
            {
                "#-######",
                "#-#-----",
                "#-#-###-",
                "#-##--#-",
                "#-#####-",
                "#-#-----",
            };
            var count = Program.CountStarsInMap(StringArrayToCharArray(c));
            Assert.AreEqual(count, 3);
        }

        [TestMethod]
        public void F6()
        {
            var c = new[]
            {
                "#-#######",
                "#-#------",
                "#-###-##-",
                "#-###-#--",
                "#-----###",
            };
            var count = Program.CountStarsInMap(StringArrayToCharArray(c));
            Assert.AreEqual(count, 1);
        }

        [TestMethod]
        public void F7()
        {
            var c = new[]
            {
                "#-#######",
                "#-#------",
                "#-###-##-",
                "#-###-#--",
                "#-#######",
            };
            var count = Program.CountStarsInMap(StringArrayToCharArray(c));
            Assert.AreEqual(count, 2);
        }

        [TestMethod]
        public void F8()
        {
            var c = new[]
            {
                "#-######",
                "#-###---",
                "#-###-##",
                "#-###-##",
                "#-----##",
            };
            var count = Program.CountStarsInMap(StringArrayToCharArray(c));
            Assert.AreEqual(count, 1);
        }

        [TestMethod]
        public void F9()
        {
            var c = new[]
            {
                "----#---",
                "-#-#--#-",
                "##---###",
                "########",
                "########",
            };
            var count = Program.CountStarsInMap(StringArrayToCharArray(c));
            Assert.AreEqual(count, 1);
        }

        [TestMethod]
        public void F93()
        {
            var c = new[]
            {
                "---#---",
                "-#--#-#",
                "###-#-#",
                "###---#",
                "#######",
            };
            var count = Program.CountStarsInMap(StringArrayToCharArray(c));
            Assert.AreEqual(count, 1);
        }

        [TestMethod]
        public void F91()
        {
            var c = new[]
            {
                "---#---",
                "##--###",
                "#######",
                "#######",
                "#######",
            };
            var count = Program.CountStarsInMap(StringArrayToCharArray(c));
            Assert.AreEqual(count, 2);
        }

        [TestMethod]
        public void F92()
        {
            var c = new[]
            {
                "----#---",
                "-##---#-",
                "########",
                "########",
            };
            var count = Program.CountStarsInMap(StringArrayToCharArray(c));
            Assert.AreEqual(count, 1);
        }

        [TestMethod]
        public void F94()
        {
            var c = new[]
            {
                "###########-",
                "----#---#---",
                "-##---#---#-",
                "############",
                "############",
            };
            var count = Program.CountStarsInMap(StringArrayToCharArray(c));
            Assert.AreEqual(count, 1);
        }

        [TestMethod]
        public void F95()
        {
            var c = new[]
            {
                "######-####-######",
                "----#---#-----#--#",
                "-##---#---#-#---##",
                "##################",
                "##################",
            };
            var count = Program.CountStarsInMap(StringArrayToCharArray(c));
            Assert.AreEqual(count, 1);
        }

        [TestMethod]
        public void F96()
        {
            var c = new[]
            {
                "################---",
                "----#---##----#--#-",
                "-##---#---#-#---##-",
                "#########----#####-",
                "#############------",
            };
            var count = Program.CountStarsInMap(StringArrayToCharArray(c));
            Assert.AreEqual(count, 1);
        }

        [TestMethod]
        public void V()
        {
            var c = new[]
            {
                "--########--",
                "#--######--#",
                "##--####--##",
                "###--##--###",
                "####----####",
            };
            var count = Program.CountStarsInMap(StringArrayToCharArray(c));
            Assert.AreEqual(count, 1);
        }

        [TestMethod]
        public void Z()
        {
            var c = new[]
            {
                "------------",
                "##########--",
                "#########--#",
                "########--##",
                "#######--###",
                "######--####",
                "#####--#####",
                "####--######",
                "###--#######",
                "##--########",
                "#--#########",
                "------------",
            };
            var count = Program.CountStarsInMap(StringArrayToCharArray(c));
            Assert.AreEqual(count, 1);
        }

        [TestMethod]
        public void Z2()
        {
            var c = new[]
            {
                "------------",
                "##########--",
                "######--#--#",
                "#####--#--##",
                "####--#--#--",
                "###--#--#--#",
                "##--#--#--##",
                "#--#--#--###",
                "--#--###--##",
                "----#####--#",
                "#--#######--",
                "------------",
            };
            var count = Program.CountStarsInMap(StringArrayToCharArray(c));
            Assert.AreEqual(count, 1);
        }

        [TestMethod]
        public void F10()
        {
            var c = new[]
            {
                "#########",
                "#---#---#",
                "-##---###",
                "----#####",
                "#########",
                "#########",
            };
            var count = Program.CountStarsInMap(StringArrayToCharArray(c));
            Assert.AreEqual(count, 1);
        }

        [TestMethod]
        public void F11()
        {
            var c = new[]
            {
                "#################",
                "#####------######",
                "#####-####-##-###",
                "#####-#-##-##-###",
                "#####---##-##-###",
                "##########-##-###",
                "#####---------###",
                "#################",
                "#####-###########",
                "######-##########",
                "#######-#########",
                "#################",
            };
            var count = Program.CountStarsInMap(StringArrayToCharArray(c));
            Assert.AreEqual(count, 4);
        }

        [TestMethod]
        public void F12()
        {
            var c = new[]
            {
                "#########",
                "#--######",
                "###-#####",
                "####-####",
                "##--#-###",
                "#########",
            };
            var count = Program.CountStarsInMap(StringArrayToCharArray(c));
            Assert.AreEqual(count, 5);
        }

        [TestMethod]
        public void F13()
        {
            var c = new[]
            {
                "#########",
                "#-----###",
                "#--######",
                "#--#-####",
                "##--#-###",
                "#########",
            };
            var count = Program.CountStarsInMap(StringArrayToCharArray(c));
            Assert.AreEqual(count, 3);
        }

        [TestMethod]
        public void F14()
        {
            var c = new[]
            {
                "-----",
                "-----",
                "####-"
            };
            var count = Program.CountStarsInMap(StringArrayToCharArray(c));
            Assert.AreEqual(count, 1);
        }

        [TestMethod]
        public void F15()
        {
            var c = new[]
            {
                "#####",
                "###--",
                "#--#-",
                "###--",
            };
            var count = Program.CountStarsInMap(StringArrayToCharArray(c));
            Assert.AreEqual(count, 2);
        }

        [TestMethod]
        public void F16()
        {
            var c = new[]
            {
                "---###",
                "---#--",
                "#---##",
                "###---"
            };
            var count = Program.CountStarsInMap(StringArrayToCharArray(c));
            Assert.AreEqual(count, 2);
        }

        [TestMethod]
        public void F17()
        {
            var c = new[]
            {
                "#######",
                "###--##",
                "---###-",
                "###--##",
                "#######"
            };
            var count = Program.CountStarsInMap(StringArrayToCharArray(c));
            Assert.AreEqual(count, 4);
        }

        [TestMethod]
        public void F18()
        {
            var c = new[]
            {
                "#######",
                "##----#",
                "---###-",
                "##----#",
                "#######"
            };
            var count = Program.CountStarsInMap(StringArrayToCharArray(c));
            Assert.AreEqual(count, 2);
        }

        [TestMethod]
        public void F19()
        {
            var c = new[]
            {
                "-------",
                "--#####",
                "#--#---",
                "##---#-",
                "#######",
                "###-#--",
                "###---#"
            };
            var count = Program.CountStarsInMap(StringArrayToCharArray(c));
            Assert.AreEqual(count, 2);
        }

        [TestMethod]
        public void F20()
        {
            var c = new[]
            {
                "--###--",
                "#--#---",
                "##---#-",
                "##-#-#-",
                "###-#--",
                "###---#"
            };
            var count = Program.CountStarsInMap(StringArrayToCharArray(c));
            Assert.AreEqual(count, 1);
        }

        [TestMethod]
        public void F21()
        {
            var c = new[]
            {
                "#####--###",
                "###---##--",
                "##---#-#-#",
                "##-#-#---#",
                "##--#--###",
                "###---####"
            };
            var count = Program.CountStarsInMap(StringArrayToCharArray(c));
            Assert.AreEqual(count, 1);
        }

        [TestMethod]
        public void F22()
        {
            var c = new[]
            {
                "######--#",
                "----###--",
                "###----##",
                "######---",
            };
            var count = Program.CountStarsInMap(StringArrayToCharArray(c));
            Assert.AreEqual(count, 2);
        }



        [TestMethod]
        public void T()
        {
            var c = new[]
            {
                "------",
                "###-##",
                "--#-##",
                "#---##",
                "###-##",
            };
            var count = Program.CountStarsInMap(StringArrayToCharArray(c));
            Assert.AreEqual(count, 1);
        }

        [TestMethod]
        public void T2()
        {
            var c = new[]
            {
                "------#",
                "###-##-",
                "-##-#--",
                "#-#---#",
                "#-#-###",
            };
            var count = Program.CountStarsInMap(StringArrayToCharArray(c));
            Assert.AreEqual(count, 3);
        }

        [TestMethod]
        public void T3()
        {
            var c = new[]
            {
                "###-###",
                "-#--###",
                "###--#-",
                "###-###",
            };
            var count = Program.CountStarsInMap(StringArrayToCharArray(c));
            Assert.AreEqual(count, 3);
        }

        [TestMethod]
        public void T4()
        {
            var c = new[]
            {
                "###-###",
                "-#--###",
                "###----",
                "###-###",
            };
            var count = Program.CountStarsInMap(StringArrayToCharArray(c));
            Assert.AreEqual(count, 2);
        }

        [TestMethod]
        public void Corners()
        {
            var c = new[]
            {
                "-####-",
                "######",
                "######",
                "-####-",
            };
            var count = Program.CountStarsInMap(StringArrayToCharArray(c));
            Assert.AreEqual(count, 4);
        }

        [TestMethod]
        public void DoubleL()
        {
            var c = new[]
            {
                "------",
                "#####-",
                "-#####",
                "------",
            };
            var count = Program.CountStarsInMap(StringArrayToCharArray(c));
            Assert.AreEqual(count, 2);
        }


        [TestMethod]
        public void B()
        {
            var c = new[]
            {
                "-----###",
                "-###--##",
                "-####--#",
                "-###--##",
                "-##--###",
                "-#--####",
                "---#####",
                "-#--####",
                "-##--###",
                "-###--##",
                "-####--#",
                "-#####--",
                "-####--#",
                "-###--##",
                "-##--###",
                "-#--####",
                "---#####"
            };
            var count = Program.CountStarsInMap(StringArrayToCharArray(c));
            Assert.AreEqual(count, 1);
        }

        [TestMethod]
        public void C()
        {
            var c = new[]
            {
                "######----",
                "####----##",
                "##----####",
                "----######",
                "##----####",
                "####----##",
                "######----",
            };
            var count = Program.CountStarsInMap(StringArrayToCharArray(c));
            Assert.AreEqual(count, 1);
        }

        [TestMethod]
        public void J()
        {
            var c = new[]
            {
                "########-",
                "########-",
                "########-",
                "########-",
                "########-",
                "########-",
                "########-",
                "########-",
                "--#####--",
                "#--###--##",
                "##--#--###",
                "###---####",
                "##########"
            };
            var count = Program.CountStarsInMap(StringArrayToCharArray(c));
            Assert.AreEqual(count, 1);
        }

        [TestMethod]
        public void DoubleL2()
        {
            var c = new[]
            {
                "------",
                "#####-",
                "###---",
                "---###",
                "-#####",
                "------",
            };
            var count = Program.CountStarsInMap(StringArrayToCharArray(c));
            Assert.AreEqual(count, 2);
        }

        [TestMethod]
        public void Hashtag()
        {
            var c = new[]
            {
                "########--####--#",
                "#######--####--##",
                "####-------------",
                "######--####--###",
                "#####--####--####",
                "####--####--#####",
                "-------------####",
                "###--####--######",
                "##--####--#######",
                "#--####--########",
                "--####--#########"
            };
            var count = Program.CountStarsInMap(StringArrayToCharArray(c));
            Assert.AreEqual(count, 1);
        }

        [TestMethod]
        public void Tall1()
        {
            var c = new[]
            {
                "-#-",
                "-#-",
                "-#-",
                "-#-",
                "-#-",
                "-#-",
                "-#-",
            };
            var count = Program.CountStarsInMap(StringArrayToCharArray(c));
            Assert.AreEqual(count, 2);
        }

        [TestMethod]
        public void Tall2()
        {
            var c = new[]
            {
                "-#-",
                "-#-",
                "-#-",
                "##-",
                "-#-",
                "-#-",
                "-#-",
            };
            var count = Program.CountStarsInMap(StringArrayToCharArray(c));
            Assert.AreEqual(count, 3);
        }
        [TestMethod]
        public void MultipleDepth()
        {
            var c = new[]
            {
                "#-#-#",
                "#-#-#",
                "#-#-#",
                "#---#",
            };
            var count = Program.CountStarsInMap(StringArrayToCharArray(c));
            Assert.AreEqual(count, 1);
        }

        [TestMethod]
        public void Verylarge()
        {
            const int expected = 7;
            var c = new[]
            {
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "#################################################-##################################################",
                "############-####################################-##################################################",
                "############-####################################-##################################################",
                "########-#------#################################-##################################################",
                "########-###-####################################-##################################################",
                "########-----#######################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "############################################################-#######################################",
                "############################################################-#######################################",
                "###########################--###############################-#######################################",
                "##########################----###########################--------###################################",
                "###########################--###############################-#######################################",
                "############################################################-#######################################",
                "############################################################-#######################################",
                "############################################################-#######################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "##-#-#--############################################################################################",
                "##---##-############################################################################################",
                "##-#-##-############################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "----------------------------------------------------------------------------------------------------",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
            };

            var count = Program.CountStarsInMap(StringArrayToCharArray(c));
            Assert.AreEqual(count, expected);
        }

        [TestMethod]
        public void Verylarge2()
        {
            const int expected = 7;
            var c = new[]
            {
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "#################################################-##################################################",
                "############-####################################-##################################################",
                "############-####################################-##################################################",
                "########-#------#################################-##################################################",
                "########-###-####################################-##################################################",
                "########-----#######################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "############################################################-#######################################",
                "############################################################-#######################################",
                "###########################--###############################-#######################################",
                "##########################----###########################--------###################################",
                "###########################--###############################-#######################################",
                "############################################################-#######################################",
                "############################################################-#######################################",
                "############################################################-#######################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "##-#-#--############################################################################################",
                "##---##-############################################################################################",
                "##-#-##-############################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "----------------------------------------------------------------------------------------------------",
                "----------------------------------------------------------------------------------------------------",
                "----------------------------------------------------------------------------------------------------",
                "----------------------------------------------------------------------------------------------------",
                "----------------------------------------------------------------------------------------------------",
                "----------------------------------------------------------------------------------------------------",
                "----------------------------------------------------------------------------------------------------",
                "----------------------------------------------------------------------------------------------------",
                "----------------------------------------------------------------------------------------------------",
                "----------------------------------------------------------------------------------------------------",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
                "####################################################################################################",
            };

            var count = Program.CountStarsInMap(StringArrayToCharArray(c));
            Assert.AreEqual(count, expected);
        }

        [TestMethod]
        public void Verylarge3()
        {
            const int expected = 1;
            var c = new[]
            {
                "---#---#---#---#---#---#---#---#---#---#---#---#---#---#---#---#---#---#---#---#---#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#---#---#---#---#---#---#---#---#---#---#---#---#---#---#---#---#---#---#---#---#---",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#---#---#---#---#---#---#---#---#---#---#---#---#---#---#---#---#---#---#---#---#---",
            };

            var count = Program.CountStarsInMap(StringArrayToCharArray(c));
            Assert.AreEqual(count, expected);
        }

        [TestMethod]
        public void Checkered()
        {
            const int expected = 5000;
            var c = new[]
            {
                "#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#",
                "#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#",
                "#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#",
                "#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#",
                "#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#",
                "#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#",
                "#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#",
                "#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#",
                "#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#",
                "#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#",
                "#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#",
                "#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#",
                "#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#",
                "#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#",
                "#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#",
                "#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#",
                "#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#",
                "#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#",
                "#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#",
                "#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#",
                "#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#",
                "#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#",
                "#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#",
                "#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#",
                "#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#",
                "#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#",
                "#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#",
                "#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#",
                "#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#",
                "#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#",
                "#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#",
                "#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#",
                "#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#",
                "#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#",
                "#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#",
                "#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#",
                "#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#",
                "#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#",
                "#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#",
                "#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#",
                "#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#",
                "#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#",
                "#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#",
                "#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#",
                "#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#",
                "#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#",
                "#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#",
                "#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#",
                "#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#",
                "#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-",
                "-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#",
            };

            var count = Program.CountStarsInMap(StringArrayToCharArray(c));
            Assert.AreEqual(count, expected);
        }

        [TestMethod]
        public void Verylarge4()
        {
            const int expected = 3;
            var c = new[]
            {
                "-#-----------------------------------------------------------------------------------#-",
                "-#-----------------------------------------------------------------------------------#-",
                "-#-----------------------------------------------------------------------------------#-",
                "-#-----------------------------------------------------------------------------------#-",
                "-#-----------------------------------------------------------------------------------#-",
                "-#-----------------------------------------------------------------------------------#-",
                "-#-----------------------------------------------------------------------------------#-",
                "-#-----------------------------------------------------------------------------------#-",
                "-#-----------------------------------------------------------------------------------#-",
                "-#-----------------------------------------------------------------------------------#-",
                "-#-----------------------------------------------------------------------------------#-",
                "-#-----------------------------------------------------------------------------------#-",
                "-#-----------------------------------------------------------------------------------#-",
                "-#-----------------------------------------------------------------------------------#-",
                "-#-----------------------------------------------------------------------------------#-",
                "-#-----------------------------------------------------------------------------------#-",
                "-#-----------------------------------------------------------------------------------#-",
                "-#-----------------------------------------------------------------------------------#-",
                "-#-----------------------------------------------------------------------------------#-",
                "-#-----------------------------------------------------------------------------------#-",
                "-#-----------------------------------------------------------------------------------#-",
                "-#-----------------------------------------------------------------------------------#-",
                "-#-----------------------------------------------------------------------------------#-",
                "-#-----------------------------------------------------------------------------------#-",
                "-#-----------------------------------------------------------------------------------#-",
                "-#-----------------------------------------------------------------------------------#-",
                "-#-----------------------------------------------------------------------------------#-",
                "-#-----------------------------------------------------------------------------------#-",
                "-#-----------------------------------------------------------------------------------#-",
                "-#-----------------------------------------------------------------------------------#-",
                "-#-----------------------------------------------------------------------------------#-",
                "-#-----------------------------------------------------------------------------------#-",
                "-#-----------------------------------------------------------------------------------#-",
                "-#-----------------------------------------------------------------------------------#-",
                "-#-----------------------------------------------------------------------------------#-",
                "-#-----------------------------------------------------------------------------------#-",
                "-#-----------------------------------------------------------------------------------#-",
                "-#-----------------------------------------------------------------------------------#-",
                "-#-----------------------------------------------------------------------------------#-",
                "-#-----------------------------------------------------------------------------------#-",
                "-#-----------------------------------------------------------------------------------#-",
                "-#-----------------------------------------------------------------------------------#-",
                "-#-----------------------------------------------------------------------------------#-",
                "-#-----------------------------------------------------------------------------------#-",
                "-#-----------------------------------------------------------------------------------#-",
                "-#-----------------------------------------------------------------------------------#-",
                "-#-----------------------------------------------------------------------------------#-",
                "-#-----------------------------------------------------------------------------------#-",
                "-#-----------------------------------------------------------------------------------#-",
                "-#-----------------------------------------------------------------------------------#-",
                "-#-----------------------------------------------------------------------------------#-",
                "-#-----------------------------------------------------------------------------------#-",
                "-#-----------------------------------------------------------------------------------#-",
                "-#-----------------------------------------------------------------------------------#-",
                "-#-----------------------------------------------------------------------------------#-",
                "-#-----------------------------------------------------------------------------------#-",
                "-#-----------------------------------------------------------------------------------#-",
                "-#-----------------------------------------------------------------------------------#-",
                "-#-----------------------------------------------------------------------------------#-",
                "-#-----------------------------------------------------------------------------------#-",
                "-#-----------------------------------------------------------------------------------#-",
                "-#-----------------------------------------------------------------------------------#-",
                "-#-----------------------------------------------------------------------------------#-",
                "-#-----------------------------------------------------------------------------------#-",
                "-#-----------------------------------------------------------------------------------#-",
                "-#-----------------------------------------------------------------------------------#-",
                "-#-----------------------------------------------------------------------------------#-",
                "-#-----------------------------------------------------------------------------------#-",
                "-#-----------------------------------------------------------------------------------#-",
                "-#-----------------------------------------------------------------------------------#-",
                "-#-----------------------------------------------------------------------------------#-",
                "-#-----------------------------------------------------------------------------------#-",
                "-#-----------------------------------------------------------------------------------#-",
                "-#-----------------------------------------------------------------------------------#-",
                "-#-----------------------------------------------------------------------------------#-",
                "-#-----------------------------------------------------------------------------------#-",
                "-#-----------------------------------------------------------------------------------#-",
                "-#-----------------------------------------------------------------------------------#-",
                "-#-----------------------------------------------------------------------------------#-",
                "-#-----------------------------------------------------------------------------------#-",
                "-#-----------------------------------------------------------------------------------#-",
                "-#-----------------------------------------------------------------------------------#-",
                "-#-----------------------------------------------------------------------------------#-",
                "-#-----------------------------------------------------------------------------------#-",
                "-#-----------------------------------------------------------------------------------#-",
                "-#-----------------------------------------------------------------------------------#-",
                "-#-----------------------------------------------------------------------------------#-",
                "-#-----------------------------------------------------------------------------------#-",
                "-#-----------------------------------------------------------------------------------#-",
                "-#-----------------------------------------------------------------------------------#-",
                "-#-----------------------------------------------------------------------------------#-",
                "-#--------------------------###------------------------------------------------------#-",
                "-#--------------------------#-#------------------------------------------------------#-",
                "-#--------------------------###------------------------------------------------------#-",
                "-#-----------------------------------------------------------------------------------#-",
                "-#-----------------------------------------------------------------------------------#-",
                "-#-----------------------------------------------------------------------------------#-",
                "-#-----------------------------------------------------------------------------------#-",
                "-#-----------------------------------------------------------------------------------#-",
                "-#-------------------------------------------------------------------------------------",
            };

            var count = Program.CountStarsInMap(StringArrayToCharArray(c));
            Assert.AreEqual(count, expected);
        }
    }
}
