using Bucket_Count_Radix_Sort;
using System.Diagnostics;

//int[] testArray = new int[] { 2,521, 234, 5, 23 ,125, 25 };
//var a = RadixSort.RadixSorting(testArray);
//Console.WriteLine(String.Join(",", a));

CountTime(BucketSort.BucketSorting);
CountTime(CountingSort.CountingSorting);
CountTime(RadixSort.RadixSorting);

static int[] CreateTestData(int amount)
{
    var array = new int[amount];
    Random randNum = new Random();
    for (int i = 0; i < array.Length; i++)
    {
        array[i] = randNum.Next(0, 999);
    }
    return array;
}
static void CountTime(Action<int[]> sortMethod)
{
    Stopwatch clock = new Stopwatch();
    for (int N = 100; N <= 1_000_000; N *= 10)
    {
        var testArray = CreateTestData(N);
        clock.Start();
        sortMethod(testArray);
        clock.Stop();
        Console.WriteLine($"{N} -{sortMethod.Method.Name} {clock.ElapsedMilliseconds} ms");
    }
}