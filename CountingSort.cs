namespace Bucket_Count_Radix_Sort
{
    public static class CountingSort
    {
        public static void CountingSorting(int[] array)
        {
            var maxElement = FindMax();
            var resultArray = new int[array.Length];

            var diffRangeArr = new int[maxElement];
            for (int i = 0; i < array.Length; i++)
            {
                diffRangeArr[array[i]]++;
            }

            for (int i = 1; i < diffRangeArr.Length; i++)
            {
                diffRangeArr[i] += diffRangeArr[i - 1];
            }

            for(int j = array.Length - 1; j >= 0; j--)
            {
                var value = array[j];
                diffRangeArr[value]--;
                var index = diffRangeArr[value];
                resultArray[index] = value;

            }

            //return resultArray;

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
        }
    }
}
