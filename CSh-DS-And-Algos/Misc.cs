using System;
using System.Collections.Generic;
using System.Linq;

namespace CSh_DS_And_Algos
{
    public static class Misc
    {
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
