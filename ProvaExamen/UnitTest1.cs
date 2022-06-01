using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiblioRecu1;
using System.Collections.Generic;
using System;

namespace ProvaExamen
{
    [TestClass]
    public class UnitTest1
    {
            String msg = "";
            String prova = "";
            String[] vdades;

            ClProveidorProves proveidor = null;
            Class1 cripto = new Class1();

            [TestMethod]

            public void provaCriptoEncode()
            {
                proveidor = new ClProveidorProves("CriptoEncode.txt");

                if (proveidor.fitxer != null)
                {
                    prova = proveidor.NextProva();

                    while (prova != "")
                    {
                        vdades = prova.Split('#');
                        if (vdades.Length != 3)
                        {
                            Console.WriteLine("***ERROR*** ---> " + prova);
                        }
                        else
                        {
                            msg = "TESTING ---> " + vdades[0].ToString() + " - " + vdades[1].ToString();
                            Console.WriteLine(msg);
                            //msg = cripto.CriptoEncode(vdades[0], Int32.Parse(vdades[1]));
                            //Console.WriteLine(msg + "      yes     ");
                            Assert.AreEqual(vdades[2], cripto.CriptoEncode(vdades[0], Int32.Parse(vdades[1])), msg);

                        }
                        prova = proveidor.NextProva();
                    }
                    proveidor.TancarProveidor();
                }
            }

            [TestMethod]
            public void provaCriptoDecode()
            {
                proveidor = new ClProveidorProves("CriptoDecode.txt");

                if (proveidor.fitxer != null)
                {
                    prova = proveidor.NextProva();

                    while (prova != "")
                    {
                        vdades = prova.Split('#');
                        if (vdades.Length != 3)
                        {
                            Console.WriteLine("***ERROR*** ---> " + prova + vdades.Length);
                        }
                        else
                        {
                            msg = "TESTING ---> " + vdades[0].ToString() + " - " + vdades[1].ToString();
                            Console.WriteLine(msg);
                            msg = cripto.CriptoDecode(vdades[0], Int32.Parse(vdades[1]));
                            Console.WriteLine(msg + "          yes");
                            Assert.AreEqual(vdades[2], cripto.CriptoDecode(vdades[0], Int32.Parse(vdades[1])), msg);

                        }
                        prova = proveidor.NextProva();
                    }
                    proveidor.TancarProveidor();
                }
            }
            Class1 taula = new Class1();
            [TestMethod]
            public void TestParaulesRepetides()
            {
            List<String> llistaResultat = new List<String>();

            llistaResultat.Add("4#hola");
            llistaResultat.Add("3#arasi");
            llistaResultat.Add("2#sise");
            llistaResultat.Add("2#segon");
            llistaResultat.Add("1#primer");
            llistaResultat.Add("1#cinque");

            CollectionAssert.AreEqual(llistaResultat, taula.ParaulesMesRepetides("primer segon arasi hola cinque sise", "nove vuite sete sise sise cinque hola hola hola hola arasi arasi arasi segon segon primer"));
        }
        [TestMethod]
        public void provaExtreuConsonants()
        {
            List<Char> llResultat = new List<Char>();

            proveidor = new ClProveidorProves("extreuconsonants.txt");

            if (proveidor.fitxer != null)
            {
                prova = proveidor.NextProva();

                while (prova != "")
                {
                    vdades = prova.Split('#');
                    if (vdades.Length != 2)
                    {
                        Console.WriteLine("***ERROR*** ---> " + prova);
                    }
                    else
                    {
                        llResultat.Clear();
                        foreach (string s in vdades[1].Split(','))
                        {
                            llResultat.Add(s.ToCharArray()[0]);
                        }
                        msg = "TESTING ---> " + vdades[0].ToString() + " - " + vdades[1].ToString();
                        Console.WriteLine(msg);
                        CollectionAssert.AreEqual(llResultat, taula.ExtreuConsonants(vdades[0]), msg);

                    }
                    prova = proveidor.NextProva();
                }
                proveidor.TancarProveidor();
            }
        }
    }
    }
