using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioRecu1
{
    public class Class1
    {
        private Hashtable taulaH = new Hashtable();
        
        public String CriptoEncode(String xs, Int32 n)
        {
            String encodedAscii = "";

            foreach (char lletra in xs)
            {
                Int32 num = Convert.ToInt32(lletra);
                String lletraNum = num.ToString();
                if (lletraNum.Length != n)
                {
                    while (lletraNum.Length != n)
                    {
                        lletraNum = "0" + lletraNum;
                    }
                }
                encodedAscii += lletraNum;
            }
            return encodedAscii;
        }
        public String CriptoDecode(String xs, Int32 n)
        {
            String decodedAscii = "";
            int qttCaracters = xs.Length / n;
            for (int i = 0; i < qttCaracters; i++)
            {
                Int32 num = Convert.ToInt32(xs.Substring(n * i, n));
                decodedAscii += (char)num;
            }

            return decodedAscii;
        }
        public List<String> ParaulesMesRepetides(String frase1, String frase2)
        {
            List<String> llistaParaulesMesRepetides = new List<string>();
            int n = 0;
            String paraula = "";

            String[] vParaules1 = frase1.Split(' ');
            for (int i = 0; i < vParaules1.Length; i++)
            {
                if (!taulaH.Contains(vParaules1[i]))
                {
                    taulaH.Add(vParaules1[i], 0);
                }
            }

            String[] vParaules2 = frase2.Split(' ');
            for (int i = 0; i < vParaules2.Length; i++)
            {
                if (taulaH.Contains(vParaules2[i]))
                {
                    taulaH[vParaules2[i]] = ((Int32)taulaH[vParaules2[i]]) + 1;
                }
            }
            foreach (String k in taulaH.Keys)
            {
                paraula = k;
                n = (Int32)taulaH[k];
                if (n > 0) llistaParaulesMesRepetides.Add(n.ToString() + "#" + paraula);
            }
            llistaParaulesMesRepetides.Sort();
            llistaParaulesMesRepetides.Reverse();

            return (llistaParaulesMesRepetides);
        }
        public List<Char> ExtreuConsonants(String xs)
        {
            String consonants = "BCDFGHJKLMNPQRSTVWXYZÇÑ";
            List<Char> ll = new List<char>();
            int i = 0;
            int n = 0;
            char ch;

            for (i = 0; i < xs.Length; i++)
            {
                if (consonants.Contains(xs.Substring(i, 1).ToUpper()))
                {
                    ch = xs.Substring(i, 1).ToUpper().ToCharArray()[0];
                    if (!ll.Contains(ch))
                    {
                        ll.Add(ch);
                    }
                    n++;
                }
            }
            return (ll);
        }

    }
}
