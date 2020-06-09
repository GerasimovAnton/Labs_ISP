using System;

namespace CSLaba7
{
    class Program
    {
        static void Main(string[] args)
        {
            RationalNum r = new RationalNum(3, 2);
            RationalNum r1 = new RationalNum(5, 4);
            RationalNum r2 = 21.72;

            Console.WriteLine("R = {0}", r);
            Console.WriteLine("R1 = {0}", r1);
            Console.WriteLine("R2 = {0}", r2);

            Console.WriteLine("--------------------------------------");

            Console.WriteLine("R + R1 = {0}", r + r1);
            Console.WriteLine("R - R1 = {0}", r - r1);
            Console.WriteLine("R * R1 = {0}", r * r1);
            Console.WriteLine("R / R1 = {0}", r / r1);

            Console.WriteLine("--------------------------------------");


            Console.WriteLine("Parse '22/7'  = {0}", RationalNum.Parse("22/7"));
            Console.WriteLine("22/7 to Double  = {0}", (double)RationalNum.Parse("22/7"));
            Console.WriteLine("22/7 == 3.141 ?  = {0}", (double)RationalNum.Parse("22/7") == 3.141);
            Console.WriteLine("1.5 == 3/2 ?  = {0}", (double)RationalNum.Parse("3/2") == 1.5);


        }
    }
}
