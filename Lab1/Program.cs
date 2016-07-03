using System;
using System.Linq;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*string[] Reshuffles = {
                "00","01","02","03","04","05",
                "10","11","12","13","14","15",
                "20","21","22","23","24","25",
                "30","31","32","33","34","35",
                "40","41","42","43","44","45",
                "50","51","52","53","54","55",
            };*/
            string[] Reshuffles = genReshuffles();
            string[] RandReshuffles = {
                "10","22","35","12","45","51",
                "02","32","52","41","40","21",
                "00","11","33","44","55","50",
                "03","31","25","23","13","14",
                "05","15","24","43","53","20",
                "01","42","54","04","30","34",
            };
            string InpStr = "";
            string Alph = "012345";
            bool isCorrectString = false;
            Console.WriteLine("Введите шифруемую строку:");
            while (!isCorrectString)
            {
                InpStr = Console.ReadLine();
                isCorrectString = isInAlph(InpStr, Alph);
                if (isCorrectString == false)
                    Console.WriteLine("Ошибка: Введите строку в алфавите {0,1,2,3,4,5}:");

            }
            string EncryptedInp = Encrypt(InpStr, Reshuffles, RandReshuffles);
            Console.WriteLine("Результат шифрования:\n" + EncryptedInp);
            Console.WriteLine("Результат дешифрования:\n" + Decrypt(EncryptedInp, Reshuffles, RandReshuffles));
            Console.ReadKey();

        }

        static string Encrypt(string EncStr, string[] Reshuffles, string[] RandReshuffles)
        {
            string res = "";
            string tempInp = EncStr;
            if (tempInp.Length % 2 != 0) tempInp += "0";

            string BinStr = "";
            for (int i = 0; i < tempInp.Length; i += 2)
            {
                BinStr = "";
                BinStr += tempInp[i];
                BinStr += tempInp[i + 1];
                int j = Array.FindIndex(Reshuffles, x => x == BinStr);
                if (j != -1)
                    res += RandReshuffles[j];
            }

            return res;

        }
        static string Decrypt(string DecrStr, string[] Reshuffles, string[] RandReshuffles) {
            string res="";
            string BinStr;
            for(int i = 0; i < DecrStr.Length; i += 2)
            {
                BinStr = "";
                BinStr += DecrStr[i];
                BinStr += DecrStr[i + 1];
                int j = Array.FindIndex(RandReshuffles, x => x == BinStr);
                if (j != -1)
                    res += Reshuffles[j];
            }
            return res;
        
        }
        static string getAlph(string str)
        {
            string res = "";
            char[] Alph = str.Union(str).ToArray<char>();
            Alph = Alph.OrderBy(c => c).ToArray();
            res = new string(Alph);
            return res;
        }
        static bool isInAlph(string str, string Alph)
        {
            foreach (char ch in str)
                if (!Alph.Contains(ch))
                    return false;
            return true;
        }
        static string[] genReshuffles()
        {
            string[] res = new string[36];
            string BinStr = "";
            int k = 0;
            for(int i = 0; i < 6; i++)
            {
                for(int j = 0; j < 6; j++)
                {
                    BinStr = "";
                    BinStr += i.ToString();
                    BinStr += j.ToString();
                    res[k++] = BinStr;
                }
            }
            return res;
        }
        
    }
}
