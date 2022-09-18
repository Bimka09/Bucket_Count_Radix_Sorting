using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bucket_Count_Radix_Sort
{
    public static class RadixSort
    {
        public static void RadixSorting(int[] array)
        {
            var maxElement = FindMax();

            var rankMax = maxElement.ToString().Length - 1;
            var rankIter = rankMax;
            while(rankIter >= 0)
            {
                SortLap(rankIter, rankMax);
                rankIter--;
            }
            
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

            void SortLap(int rank, int rankMax)
            {
                var resultArray = new int[array.Length];
                var diffRangeArr = new int[10];
                for (int i = 0; i < array.Length; i++)
                {
                    var value = array[i].ToString();
                    if(value.Length <= rankMax)
                    {
                        while(value.Length != rankMax + 1)
                        {
                            value = "0" + value;
                        }
                    }
                    var rankValue = Convert.ToInt32(value.ToString().Substring(rank, 1));
                    diffRangeArr[rankValue]++;
                }

                for (int i = 1; i < diffRangeArr.Length; i++)
                {
                    diffRangeArr[i] += diffRangeArr[i - 1];
                }

                for (int j = array.Length - 1; j >= 0; j--)
                {
                    var value = array[j].ToString();
                    if (value.Length <= rankMax)
                    {
                        while (value.Length != rankMax + 1)
                        {
                            value = "0" + value;
                        }
                    }
                    var rankValue = Convert.ToInt32(value.ToString().Substring(rank, 1));
                    diffRangeArr[rankValue]--;
                    var index = diffRangeArr[rankValue];
                    resultArray[index] = Convert.ToInt32(value);
                }
                array = new List<int>(resultArray.AsEnumerable()).ToArray();
            }
        }
    }
}
