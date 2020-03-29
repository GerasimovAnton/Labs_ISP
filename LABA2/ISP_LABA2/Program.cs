using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace ISP_LABA2
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            String str = Console.ReadLine();

            // Console.WriteLine(p.StringToNum(str));
            // Console.WriteLine(p.MixString(str));
            // p.PrintFrenchTime();

            Console.ReadLine();
        }

        
        #region TASK1
        public double StringToNum(String s)
        {
            int RealPart = 0;
            double num = 0;
            String str = s;

            if (!IsRightFormat(s)) throw new Exception("Входная строка имела неверный формат.");

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != '.' && s[i] != ',')
                    RealPart++;
                else
                {
                    str = s.Remove(i, 1);
                    break;
                }
            }

            for (int i = 0; i  < str.Length; i++)
                num += ((int)str[i] - '0') * Math.Pow(10, RealPart - i - 1);
            
            return num;
        }

        private bool IsRightFormat(String s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if ((int)s[i] - '0' >= 0 && ((int)s[i] - '0' <= 9) || s[i] == ',' || s[i] == '.') continue;
                else return false;
            }

            return true;
        }

        #endregion

        #region Task2
        public String MixString(String str)
        {
            int StrLen = str.Length;
            Random random = new Random();
            StringBuilder stringBuilder = new StringBuilder(str);
           
            for (int i = 0; i < StrLen; i++)
            {
                int RandPos = random.Next(0, StrLen);
                (stringBuilder[i], stringBuilder[RandPos]) = (stringBuilder[RandPos],stringBuilder[i]); // Swap();
            }

            return stringBuilder.ToString();
        }

        public static void Swap<T>( ref T a, ref T b)
        {
            T tmp = a;
            a = b;
            b = tmp;
        }

        #endregion

        #region TASK3
        public void PrintFrenchTime()
        {
            CultureInfo.CurrentUICulture = CultureInfo.GetCultureInfo("fr-FR");
            for (int i = 0; i < 12; i++)
            Console.WriteLine(CultureInfo.CurrentUICulture.DateTimeFormat.MonthNames[i]);
        }
        #endregion
    }
}
