using ArrayCalculatorAPI.Services;
using Xunit;

namespace ArrayCalculatorAPI.Tests
{
    public class ArrayServiceTest
    {
        [Theory]
        //True Expected Result is produced
        [InlineData("productIds=6&productIds=5&productIds=4&productIds=3&productIds=2&productIds=1", new int[] { 1, 2, 3, 4, 5, 6 })]
        //True Test with different size of parameters
        [InlineData("productIds=5&productIds=4&productIds=3&productIds=2&productIds=1", new int[] { 1, 2, 3, 4, 5 })]
        //True Test with non integer
        [InlineData("productIds=6&productIds=5&productIds=4&productIds=3&productIds=2&productIds=abcd", new int[] { 0, 2, 3, 4, 5, 6 })]
        public void CanReverseArray_ReveseArray_ResultInArrayFormat(string query, int[] expecatations)
        {
            // Arrange
            ArrayService arrayService = new ArrayService();

            // Act
            var result = arrayService.ReverseArray(query);

            // Assert
            Assert.Equal(expecatations, result);
        }


        [Theory]
        //Removing an element withing an array
        [InlineData("position=3&productIds=1&productIds=2&productIds=3&productIds=4&productIds=5", new int[] { 1, 2, 4, 5 }, 3)]
        [InlineData("position=5&productIds=1&productIds=2&productIds=3&productIds=4&productIds=5", new int[] { 1, 2, 3, 4 }, 5)]
        //Removing an element at zero position
        [InlineData("position=0&productIds=1&productIds=2&productIds=3&productIds=4&productIds=5", new int[] { 1, 2, 3, 4, 5 }, 0)]
        //Removing non existing elelment position
        [InlineData("position=6&productIds=1&productIds=2&productIds=3&productIds=4&productIds=5", new int[] { 1, 2, 3, 4, 5 }, 6)]
        public void CanRemoveElement_DeletePartArray_ResultInArrayFormat(string query, int[] expecatations, int position)
        {
            // Arrange
            ArrayService arrayService = new ArrayService();

            // Act
            var result = arrayService.DeletePartArray(query, position);

            // Assert
            Assert.Equal(expecatations, result);

        }
    }
}
