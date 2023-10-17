using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryHeapVisuallization
{
    public class Binary<T> where T : IComparable<T>
    {

        public List<T> _heap;

        public Binary()
        {
            _heap = new List<T>();
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
                HeapifyDown(0);
            }

            return minItem;
        }

        private void HeapifyDown(int index)
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

        public void HeapSort()
        {
            int n = _heap.Count;

            for (int i = n / 2 - 1; i >= 0; i--)
            {
                HeapifyDown(i);
            }

            for (int i = n - 1; i >= 1; i--)
            {
                Swap(0, i);
                HeapifyDown(0, i);
            }
        }

        private void HeapifyDown(int index, int size)
        {
            int leftChildIndex = (2 * index) + 1;
            int rightChildIndex = (2 * index) + 2;

            int largestIndex = index;

            if (leftChildIndex < size && _heap[leftChildIndex].CompareTo(_heap[largestIndex]) > 0)
            {
                largestIndex = leftChildIndex;
            }

            if (rightChildIndex < size && _heap[rightChildIndex].CompareTo(_heap[largestIndex]) > 0)
            {
                largestIndex = rightChildIndex;
            }

            if (largestIndex != index)
            {
                Swap(index, largestIndex);
                HeapifyDown(largestIndex, size);
            }
        }

        public void Swap(int i, int j)
        {
            T temp = _heap[i];
            _heap[i] = _heap[j];
            _heap[j] = temp;
        }

    }
}
