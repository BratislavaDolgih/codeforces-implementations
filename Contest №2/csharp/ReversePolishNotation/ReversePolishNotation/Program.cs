using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReversePolishNotation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] tokens = Console.ReadLine().Split(' ');
            Stack<int> myStack = new Stack<int>();

            foreach (string token in tokens)
            {
                if (!token.Equals("+") && !token.Equals("-")
                    && !token.Equals("*"))
                {
                    myStack.Push(int.Parse(token));
                }
                else
                {
                    int b = myStack.Pop();
                    int a = myStack.Pop();
                    
                    switch (token)
                    {
                        case "+":
                            myStack.Push(a + b);
                            break;
                        case "-":
                            myStack.Push(a - b);
                            break;
                        case "*":
                            myStack.Push(a * b);
                            break;
                    }
                }
            }
            Console.WriteLine(myStack.Pop());
        }
    }
}
