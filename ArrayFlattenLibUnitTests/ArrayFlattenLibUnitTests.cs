using System;
using Xunit;

namespace ArrayFlattenLibUnitTests
{
    public class ArrayFlattenTests
    {
        private static readonly int[] expected = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        [Fact]
        public void NullPassedTest()
        {
            var returnVal = ArrayFlattenLib.ArrayFlattenLib.ArrayIntOnlyFlatten(null);

            Assert.Null(returnVal);
        }

        [Fact]
        public void FlatArrayPassed()
        {
            var inputVal = new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var returnVal = ArrayFlattenLib.ArrayFlattenLib.ArrayIntOnlyFlatten(inputVal);

            Assert.Equal(expected, returnVal);
        }

        [Fact]
        public void ArbitrarilyNestedArrayTest()
        {
            var inputVal = new object[] { 1, new object[] { 2 }, new object[] { 3, 4, new object[] { 5, 6, new object[] { 7, 8 } } }, 9, 10 };

            var returnVal = ArrayFlattenLib.ArrayFlattenLib.ArrayIntOnlyFlatten(inputVal);

            Assert.Equal(expected, returnVal);
        }

        [Fact]
        public void ArbitrarilyNestedArrayWithStringTest()
        {
            var inputVal = new object[] { 1, new object[] { "2" }, new object[] { 3, 4, new object[] { 5, 6, new object[] { 7, 8 } } }, 9, 10 };

            var ex = Assert.Throws<Exception>(() => ArrayFlattenLib.ArrayFlattenLib.ArrayIntOnlyFlatten(inputVal));

            Assert.Equal("A non-Interger element of the array was included", ex.Message);
        }
    }
}
