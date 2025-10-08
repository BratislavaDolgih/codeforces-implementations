using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DequeTest
{
    internal class Program
    {
        /*
        public class ProductDeque
        {
            private readonly Person[] data;
            private readonly int capacity;
            private int size;

            private int head;
            private int tail;

            public ProductDeque(int cpcty)
            {
                capacity = cpcty;
                data = new Person[cpcty];
                head = 0;
                tail = 0;
                size = 0;
            }

            public bool IsEmpty() => size == 0;
            public bool IsFull() => size == capacity;

            // 1. Занимает последним человек
            public void PushBack(Person human)
            {
                if (IsFull())
                    throw new InvalidOperationException("Deque is full");
                data[tail] = human;
                tail = (tail + 1) % capacity;
                size++;
            }

            // Только для внутреннего использования
            private void PushFront(Person human)
            {
                if (IsFull())
                    throw new InvalidOperationException("Deque is full");
                head = (head - 1 + capacity) % capacity;
                data[head] = human;
                size++;
            }

            // 2. Человек спереди очереди сваливает
            public Person PopFront()
            {
                if (IsEmpty())
                    throw new InvalidOperationException("Deque is empty");
                Person value = data[head];
                data[head] = null;
                head = (head + 1) % capacity;
                size--;
                return value;
            }

            // 3. Человек с конца очереди сваливает
            public Person PopBack()
            {
                if (IsEmpty())
                    throw new InvalidOperationException("Deque is empty");
                tail = (tail - 1 + capacity) % capacity;
                Person value = data[tail];
                data[tail] = null;
                size--;
                return value;
            }

            // 4. Сколько человек впереди данного id
            public int HowManyInFront(int humanId)
            {
                int countHowMany = 0;
                int itr = head;

                while (itr != tail)
                {
                    if (data[itr].ID == humanId)
                        break;
                    countHowMany++;
                    itr = (itr + 1) % capacity;
                }

                return countHowMany;
            }

            // 5. Кто сейчас первый в очереди
            public Person PeekFront()
            {
                if (IsEmpty())
                    throw new InvalidOperationException("Deque is empty");
                return data[head];
            }

            // Не используется в задаче
            private Person PeekBack()
            {
                if (IsEmpty())
                    throw new InvalidOperationException("Deque is empty");
                return data[(tail - 1 + capacity) % capacity];
            }

            public int Size() => size;

            public class Person 
            {
                public int ID { get; set; }
                public Person(int id)
                {
                    ID = id;
                }
            }
        }
        */
        static void Main()
        {
            int moments = int.Parse(Console.ReadLine());
            var log = new Dictionary<int, int>();
            var listQueue = new LinkedList<int>();
            int howMuchInFront = 0;

            for (int i = 0; i < moments; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                int option = int.Parse(tokens[0]);

                switch (option)
                {
                    case 1: 
                        int id = int.Parse(tokens[1]);
                        listQueue.AddLast(id);
                        log[id] = ++howMuchInFront;
                        break;
                    case 2:
                        log.Remove(listQueue.First.Value);
                        listQueue.RemoveFirst();
                        break;
                    case 3:
                        log.Remove(listQueue.Last.Value);
                        listQueue.RemoveLast();
                        --howMuchInFront;
                        break;
                    case 4:
                        int id4 = int.Parse(tokens[1]);
                        Console.WriteLine(log[id4] - log[listQueue.First.Value]);
                        break;
                    case 5:
                        Console.WriteLine(listQueue.First.Value);
                        break;
                }
            }
        }
    }
}
