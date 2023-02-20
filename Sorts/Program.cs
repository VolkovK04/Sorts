using System;

namespace Sorts
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(HIndex(new int[] { 3, 0, 6, 1, 5}));
            int[] nums = new int[] { 1, 5, 1, 1, 6, 4 };
            WiggleSort(nums);
            for (int i = 0; i < nums.Length; i++)
            {
                Console.WriteLine(nums[i]);
            }
            Console.ReadLine();
        }
        public static int HIndex(int[] citations)
        {
            shellSort(citations);
            for (int i = 0; i < citations.Length; i++)
            {
                int buff = citations.Length - i;
                if (citations[i] >= buff)
                    return buff;
            }
            return 0;
        }
        public static void shellSort(int[] arr)
        {
            int[] k = new int[] { 1, 4, 10, 23, 57, 132, 301, 701 };
            for (int i = k.Length - 1; i >= 0; i--)
                kSort(arr, k[i]);
        }
        public static void kSort(int[] arr, int k)
        {
            for (int i = k; i < arr.Length; i++)
            {
                int c = arr[i];
                int buff = i % k;
                for (int j = i; j >= k; j -= k)
                {
                    if (arr[j - k] <= c)
                    {
                        buff = j;
                        break;
                    }
                    arr[j] = arr[j - k];
                }
                arr[buff] = c;
            }
        }
        public static void WiggleSort(int[] nums)
        {
            int[] buff = new int[nums.Length];
            nums.CopyTo(buff, 0);
            shellSort(buff);
            for (int i = 0; i < nums.Length; i++)
                if (i % 2 == 0)
                    nums[i] = buff[(nums.Length - 1) / 2 - i / 2];
                else
                    nums[i] = buff[nums.Length - 1 - (i - 1) / 2];
        }
    }
}
