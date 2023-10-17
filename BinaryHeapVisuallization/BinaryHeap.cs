using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryHeapVisuallization
{
    public class BinaryHeap<T> where T : IComparable<T>
    {
        public List<T> _heap;

        public List<int> Min = new List<int>();

        public List<int> Max = new List<int>();

        public BinaryHeap()
        {
            _heap = new List<T>();
        }

        public BinaryHeap(IEnumerable<T> collection)
        {
            _heap = new List<T>(collection);
        }


        public int Size
        {
            get { return _heap.Count; }
        }

        public void Insert(T item)
        {
            _heap.Add(item);
            //   HeapifyUp(_heap.Count - 1);
        }


        public T ExtractMax()
        {
            if (_heap.Count == 0)
            {
                throw new Exception("Heap is empty");
            }

            T maxItem = _heap[0];
            int lastIndex = _heap.Count - 1;

            Console.WriteLine("ExtractMax:" + lastIndex);

            _heap[0] = _heap[lastIndex];
            Console.WriteLine("ExtractMax:" + _heap[0]);


            Console.WriteLine("ExtractMax:" + _heap[lastIndex]);
            _heap.RemoveAt(lastIndex);

            if (_heap.Count > 1)
            {
                HeapifyDown(0);
            }

            return maxItem;
        }

        public void BuildHeap()
        {
            int n = _heap.Count;
            for (int i = (n / 2) - 1; i >= 0; i--)
            {
                HeapifyDown(i);
            }
        }

        private void HeapifyUp(int index)
        {
            int parentIndex = (index - 1) / 2;

            while (index > 0 && _heap[index].CompareTo(_heap[parentIndex]) < 0)
            {
                Swap(index, parentIndex);
                index = parentIndex;
                parentIndex = (index - 1) / 2;
            }
        }

        public void HeapifyDown(int index)
        {
            int leftChildIndex = (2 * index) + 1;
            int rightChildIndex = (2 * index) + 2;

            int smallestIndex = index;

            if (leftChildIndex < _heap.Count && _heap[leftChildIndex].CompareTo(_heap[smallestIndex]) > 0)
            {
                smallestIndex = leftChildIndex;
            }

            if (rightChildIndex < _heap.Count && _heap[rightChildIndex].CompareTo(_heap[smallestIndex]) > 0)
            {
                smallestIndex = rightChildIndex;
            }

            if (smallestIndex != index)
            {
                Swap(index, smallestIndex);
                HeapifyDown(smallestIndex);
            }
        }
        public T ExtractMin()
        {
            if (_heap.Count == 0)
            {
                throw new Exception("Heap is empty");
            }

            T minItem = _heap[0];
            int lastIndex = _heap.Count - 1;

            _heap[0] = _heap[lastIndex];
            _heap.RemoveAt(lastIndex);

            if (_heap.Count > 1)
            {
                HeapifyDowm(0);
            }

            return minItem;
        }

        private void HeapifyDowm(int index)
        {
            int leftChildIndex = (2 * index) + 1;
            int rightChildIndex = (2 * index) + 2;

            int smallestIndex = index;

            if (leftChildIndex < _heap.Count && _heap[leftChildIndex].CompareTo(_heap[smallestIndex]) > 0)
            {
                smallestIndex = leftChildIndex;
            }

            if (rightChildIndex < _heap.Count && _heap[rightChildIndex].CompareTo(_heap[smallestIndex]) > 0)
            {
                smallestIndex = rightChildIndex;
            }

            if (smallestIndex != index)
            {
                Swaps(index, smallestIndex);
                HeapifyDowm(smallestIndex);
            }
        }

        public void Swaps(int i, int j)
        {
            T temp = _heap[i];
            _heap[i] = _heap[j];
            _heap[j] = temp;
        }

        public void Swap(int i, int j)
        {
            T temp = _heap[i];
            _heap[i] = _heap[j];
            _heap[j] = temp;
        }
    }
}
