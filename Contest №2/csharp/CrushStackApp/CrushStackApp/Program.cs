using System;
using System.Linq;

namespace October.Algorithms
{
    public class CrushStack
    {
        private CrushGroup[] data;
        private int topIndex;
        private const int DEFAULT_CAPACITY = 1000;

        public CrushStack()
        {
            data = new CrushGroup[DEFAULT_CAPACITY];
            topIndex = -1;
        }

        public void Push(CrushGroup crushes)
        {
            EnsureCapacity();
            data[++topIndex] = crushes;
        }

        public CrushGroup Pop()
        {
            if (IsEmpty()) throw new InvalidOperationException("Stack is empty");
            CrushGroup poppingGroup = data[topIndex];
            data[topIndex--] = null;
            return poppingGroup;
        }

        public CrushGroup Peek()
        {
            if (IsEmpty()) throw new InvalidOperationException("Stack is empty");
            return data[topIndex];
        }

        private void EnsureCapacity()
        {
            if (Size() == data.Length)
            {
                CrushGroup[] newData = new CrushGroup[data.Length * 2];
                Array.Copy(data, newData, data.Length);
                data = newData;
            }
        }

        public bool IsEmpty()
        {
            return topIndex == -1;
        }

        private int Size()
        {
            return topIndex + 1;
        }
    }

    public class CrushGroup
    {
        private byte colour;
        private int amount;
        public byte Colour() => this.colour;
        public int Amount() => this.amount;

        public CrushGroup(byte clr, int amt)
        {
            colour = clr; amount = amt;
        }
    }

    public class CrushBallsAnalog
    {
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
    }
}
