using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackWithMinimums
{
    class UserStack
    {
        private int[] data;
        private int top;
        private const int DEFAULT_CAPACITY = 12;

        private MinHistory historyOfMinimum;

        public UserStack()
        {
            data = new int[DEFAULT_CAPACITY];
            top = -1;

            historyOfMinimum = new MinHistory();
        }

        public void Push(int value)
        {
            EnsureCapacity();
            data[++top] = value;

            if (historyOfMinimum.LocalIsEmpty() 
                || historyOfMinimum.PeekCurrent() >= value)
            {
                historyOfMinimum.Push(value);
            }
        }

        public int Pop()
        {
            int popingElement = data[top];
            data[top--] = 0;
            if (popingElement == historyOfMinimum.PeekCurrent())
            {
                historyOfMinimum.Pop();
            }

            return popingElement;
        }

        public int Peek()
        {
            return data[top];
        }

        public int Minimum() => historyOfMinimum.PeekCurrent();

        private void EnsureCapacity()
        {
            if (Size() == data.Length)
            {
                int[] updatedData = new int[data.Length * 2];
                Array.Copy(
                    data,
                    updatedData,
                    data.Length
                    );

                data = updatedData;
            }
        }

        private int Size() { return top + 1;  }

        private class MinHistory
        {
            private int[] historyBody;
            private int minTop = -1;

            public MinHistory()
            {
                historyBody = new int[DEFAULT_CAPACITY];
            }

            public void Push(int newMin)
            {
                LocalEnsureCapacity();
                historyBody[++minTop] = newMin;
            }

            public void Pop()
            {
                if (!LocalIsEmpty())
                {
                    historyBody[minTop--] = 0;
                }
            }

            public int PeekCurrent()
            {
                return LocalIsEmpty() ? -1 : historyBody[minTop];
            }

            private void LocalEnsureCapacity()
            {
                if (this.Size() == historyBody.Length)
                {
                    int[] updated = new int[historyBody.Length * 2];
                    Array.Copy(
                        historyBody,
                        updated, 
                        historyBody.Length);
                    historyBody = updated;
                }
            }

            public bool LocalIsEmpty() => minTop == -1;
            private int Size() => minTop + 1;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOperations = int.Parse(Console.ReadLine());
            UserStack st = new UserStack();
            List<int> mins = new List<int>();

            for (int i = 0; i < countOperations; i++)
            {
                int operation;
                string[] tokens = Console.ReadLine().Split(' ');

                operation = int.Parse(tokens[0]);

                if (operation == 1)
                {
                    st.Push(int.Parse(tokens[1]));
                }
                else if (operation == 2)
                {
                    st.Pop();
                }
                else
                {
                    mins.Add(st.Minimum());
                }
            }

            foreach (int min in mins)
            {
                Console.WriteLine(min);
            }
        }
    }
}
