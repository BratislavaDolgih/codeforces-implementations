using System;
using System.Collections.Generic;
using System.Linq;

namespace October.Algorithms
{
    public class CrushBallsAnalog
    {
        public static void Main(string[] args)
        {
            int[] balls = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> s = new Stack<int>();
            int totalScore = 0;

            for (int i = 0; i < balls.Length; ++i)
            {
                if (s.Count > 2 && balls[i] != s.Peek())
                {
                    int topBall = s.Pop();
                    int secondBall = s.Pop();

                    if (s.Peek() == secondBall && s.Peek() == topBall)
                    {
                        totalScore += 2;

                        while (s.Count > 0 && topBall == s.Peek())
                        {
                            totalScore++;
                            s.Pop();
                        }
                    }
                    else
                    {
                        s.Push(secondBall);
                        s.Push(topBall);
                    }
                }
                s.Push(balls[i]);
            }

            if (s.Count > 2)
            {
                int topBall = s.Pop();
                int secondBall = s.Pop();

                if (s.Peek() == secondBall && s.Peek() == topBall)
                {
                    totalScore += 2;

                    while (s.Count > 0 && topBall == s.Peek())
                    {
                        totalScore++;
                        s.Pop();
                    }
                }
            }

            Console.WriteLine(totalScore);
        }
    }
}
/*
        public static void Main(string[] args)
        {
            byte[] balls = Console.ReadLine().Split(' ').Select(byte.Parse).ToArray();

            CrushStack cs = new CrushStack();
            int totalScore = 0;

            // Пример: 10 3 3 2 1 1 1 2 2 3 3 -> 10
            for (int i = 0; i < balls.Length; ++i)
            {
                if (!cs.IsEmpty() && cs.Peek().Colour() == balls[i])
                {
                    CrushGroup top = cs.Pop();
                    int newAmount = top.Amount() + 1;

                    if (newAmount == 3)
                    {
                        while (i + 1 < balls.Length && balls[i] == balls[i + 1])
                        {
                            newAmount++;
                            ++i;
                        }
                        totalScore += newAmount;
                    }
                    else
                    {
                        cs.Push(new CrushGroup(balls[i], newAmount));
                    }
                }
                else
                {
                    cs.Push(new CrushGroup(balls[i], 1));
                }
            }

            Console.WriteLine(totalScore);
        }
        */