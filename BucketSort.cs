namespace Bucket_Count_Radix_Sort
{
    public static class BucketSort
    {
        public static void BucketSorting(int[] array)
        {

            var buckets = new LinkedList<int>[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                buckets[i] = new LinkedList<int>();
            }

            var maxElement = FindMax();
            
            for (int i = 0; i < array.Length; i++)
            {
                var index = (array[i] * array.Length) / maxElement;
                if(buckets[index].Count > 0)
                {
                    Sort(buckets[index], array[i]);
                }
                else
                {
                    buckets[index].AddFirst(array[i]);
                }
            }

            RewriteArray();
            //return array;

            int FindMax()
            {
                var maxElement = 0;
                for (int i = 0; i < array.Length - 1; i++)
                {
                    if (array[i] > maxElement)
                    {
                        maxElement = array[i];
                    }
                }
                return ++maxElement;
            }

            void Sort(LinkedList<int> list, int value)
            {
                var valueAdded = false;
                var currentNode = list.First;
                while (currentNode != null)
                {
                    if(value < currentNode.Value)
                    {
                        var swap = currentNode.Value;
                        currentNode.Value = value;
                        list.AddAfter(currentNode, swap);
                        valueAdded = true;
                        break;
                    }
                    currentNode = currentNode.Next;
                }
                if(valueAdded == false)
                {
                    list.AddLast(new LinkedListNode<int>(value));
                }
            }

            void RewriteArray()
            {
                var indArr = 0;
                foreach(var list in buckets)
                {
                    if(list.Count > 1)
                    {
                        var currentNode = list.First;
                        while (currentNode != null)
                        {
                            array[indArr++] = currentNode.Value;
                            currentNode = currentNode.Next;
                        }
                    }
                    else if(list.Count == 1)
                    {
                        array[indArr++] = list.First.Value;
                    }
                }
            }
        }
    }
}
