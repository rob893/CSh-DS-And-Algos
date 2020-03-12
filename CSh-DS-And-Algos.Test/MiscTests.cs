using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CSh_DS_And_Algos.Test
{
    public class MiscTests
    {
        [Fact]
        public void ReverseString()
        {
            //Arrange
            string str1 = "abcd";
            string str2 = "";
            string str3 = "dddd";
            string str4 = "sdf3 22v";

            //Act
            str1 = Misc.ReverseString(str1);
            str2 = Misc.ReverseString(str2);
            str3 = Misc.ReverseString(str3);
            str4 = Misc.ReverseString(str4);

            //Assert
            Assert.Equal("dcba", str1);
            Assert.Equal("", str2);
            Assert.Equal("dddd", str3);
            Assert.Equal("v22 3fds", str4);
        }

        [Fact]
        public void FindMissingNumber()
        {
            var arr1 = new int[] {0, 4, -1, 3, 2};
            var arr2 = new int[] {0, 1, 2, 3, 4, 5, 6, 8, 9, 10};
            var arr3 = new int[] {-9, -6, -7, -5, -4, -3, -2, -1};
            var arr4 = new int[] {int.MaxValue, int.MaxValue - 3, int.MaxValue - 2, int.MaxValue - 4, int.MaxValue - 5};
            var arr5 = new int[] {int.MinValue, int.MinValue + 3, int.MinValue + 2, int.MinValue + 4, int.MinValue + 5};
            var arr6 = Enumerable.Range(-1000, 200000).Where(x => x != 789).ToArray();
            var arr7 = new int[] {-2, 1, -1, 3, 2};


            int missingNumber1 = Misc.FindMissingNumber(arr1);
            int missingNumber2 = Misc.FindMissingNumber(arr2);
            int missingNumber3 = Misc.FindMissingNumber(arr3);
            int missingNumber4 = Misc.FindMissingNumber(arr4);
            int missingNumber5 = Misc.FindMissingNumber(arr5);
            int missingNumber6 = Misc.FindMissingNumber(arr6);
            int missingNumber7 = Misc.FindMissingNumber(arr7);

            Assert.Equal(1, missingNumber1);
            Assert.Equal(7, missingNumber2);
            Assert.Equal(-8, missingNumber3);
            Assert.Equal(int.MaxValue - 1, missingNumber4);
            Assert.Equal(int.MinValue + 1, missingNumber5);
            Assert.Equal(789, missingNumber6);
            Assert.Equal(0, missingNumber7);
        }
    }
}
