using System;
using mystack;

namespace CSLaba4t2
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack s = new Stack();

            s.Pop();
            s.Push(1);
            s.Push(2);
            s.Pop();
            s.Push(1);
            s.Push(2);
            s.Pop();

            Console.WriteLine("Stack size = {0} element on top = {1}",s.Size,s.Top());
        }
    }
}
