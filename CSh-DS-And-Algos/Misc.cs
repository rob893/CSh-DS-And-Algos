using System;
using System.Collections.Generic;
using System.Linq;

namespace CSh_DS_And_Algos
{
    public static class Misc
    {
        public static int FindMissingNumber(int[] nums)
        {
            long actualSum = 0;
            long targetSum = 0;
            int min = int.MaxValue;
            int max = int.MinValue;

            foreach (var num in nums)
            {
                actualSum += num;
                if (num < min)
                {
                    min = num;
                }

                if (num > max)
                {
                    max = num;
                }
            }

            for (long i = min; i <= max; i++)
            {
                targetSum += i;
            }

            return (int)(targetSum - actualSum);
        }

        public static int[] RemoveDuplicates1(int[] arr)
        {
            return new HashSet<int>(arr).ToArray();
        }

        public static int[] RemoveDuplicates2(int[] arr)
        {
            var set = new HashSet<int>();

            foreach (var num in arr)
            {
                set.Add(num);
            }

            int[] results = new int[set.Count];
            int i = 0;

            foreach(int num in set)
            {
                results[i] = num;
                i++;
            }

            return results;
        }

        public static string ReverseString(string str)
        {
            var arr = str.ToCharArray();
            arr.Reverse();

            return new String(arr);
        }

        public static void RemoveDuplicates3(int[] arr)
        {
            var set = new HashSet<int>();

            for (int i = 0; i < arr.Length; i++) //set duplicates to 0
            {
                if (set.Contains(arr[i]))
                {
                    arr[i] = 0;
                }

                set.Add(arr[i]);
            }

            for (int curr = 0, lastZeroIndex = 0; curr < arr.Length; curr++) //move zeros to the end
            {
                if (arr[curr] != 0)
                {
                    var temp = arr[curr];
                    arr[curr] = arr[lastZeroIndex];
                    arr[lastZeroIndex] = temp;
                    lastZeroIndex++;
                }
            }
        }
    }
}
