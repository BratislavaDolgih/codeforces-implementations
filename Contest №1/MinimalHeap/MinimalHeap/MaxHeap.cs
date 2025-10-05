using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimalHeap
{
    internal class MaxHeap
    {
        private int[] heap;
        private int size;
        private const int DEFAULT_CAPACITY = 10;

        public MaxHeap()
        {
            heap = new int[DEFAULT_CAPACITY];
            size = 0;
        }

        public int Peek()
        {
            if (size == 0)
            {
                throw new Exception("Heap is empty.");
            }
            return heap[0];
        }

        public void Add(int val)
        {
            EnsureCapacity();
            heap[size++] = val;
            HeapifyUp();
        }

        public void Add(int[] numArray)
        {
            foreach (int num in numArray)
            {
                this.Add(num);
            }
        }

        private void HeapifyUp()
        {
            int index = size - 1; // last element.

            while (HasParent(index))
            {
                int parentIndex = GetParentIndex(index);
                if (heap[parentIndex] >= heap[index]) { break; }
                Swap(index, parentIndex);
                index = parentIndex;
            }
        }

        public int Poll()
        {
            if (size == 0) { throw new Exception("Heap is empty!"); }
            int max = heap[0];
            heap[0] = heap[size - 1];
            size--;
            HeapifyDown();
            return max;
        }

        private void HeapifyDown()
        {
            int index = 0;
            while (HasLeftChild(index))
            {
                int smallerLeftChild = GetLeftChildIndex(index);

                if (HasRightChild(index)
                    && heap[GetLeftChildIndex(index)] < heap[GetRightChildIndex(index)])
                {
                    smallerLeftChild = GetRightChildIndex(index);
                }

                if (heap[index] >= heap[smallerLeftChild])
                {
                    break;
                }

                Swap(index, smallerLeftChild);
                index = smallerLeftChild;
            }
        }

        public int[] HeapSort()
        {
            int originalSize = size;
            int[] sortedHeap = new int[size];

            for (int i = 0; i < sortedHeap.Length; i++)
            {
                sortedHeap[i] = Poll();
            }

            heap = new int[DEFAULT_CAPACITY];
            size = 0;

            Add(sortedHeap);
            return sortedHeap;
        }

        // Getters.
        private int GetLeftChildIndex(int parent) { return 2 * parent + 1; }
        private int GetRightChildIndex(int parent) { return 2 * parent + 2; }
        private int GetParentIndex(int child) { return (child - 1) / 2; }

        // Checkers
        private bool HasLeftChild(int parent) { return GetLeftChildIndex(parent) < size; }
        private bool HasRightChild(int parent) { return GetRightChildIndex(parent) < size; }
        private bool HasParent(int child) { return child > 0; }

        private void Swap(int first, int second)
        {
            int temp = heap[first];
            heap[first] = heap[second];
            heap[second] = temp;
        }
        private void EnsureCapacity()
        {
            if (size == heap.Length)
            {
                int[] increasedHeap = new int[heap.Length * 2];
                Array.Copy(heap, increasedHeap, heap.Length);
                heap = increasedHeap;
            }
        }

        public void PrintHeap()
        {
            for (int i = 0; i < size; ++i)
            {
                Console.Write($"{heap[i]} ");
            }
            Console.WriteLine();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int commandsValue = int.Parse(Console.ReadLine());
            MaxHeap myHeap = new MaxHeap();
            List<int> printMaxis = new List<int>();

            for (int cmd = 0; cmd < commandsValue; ++cmd)
            {
                string line = Console.ReadLine();
                string[] tokens = line.Split();

                if (tokens[0] == "0")
                {
                    myHeap.Add(int.Parse(tokens[1]));
                }
                else
                {
                    printMaxis.Add(myHeap.Poll());
                }
            }

            foreach (int maxs in printMaxis)
            {
                Console.WriteLine(maxs);
            }
        }
    }
}