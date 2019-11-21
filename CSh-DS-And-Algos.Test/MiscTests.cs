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
    }
}
