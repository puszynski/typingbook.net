using TypingMVCCore.Extensions;
using Xunit;

namespace XUnitTestTypingMVCCore
{
    public class RemoveSpacesFromBeginning
    {
        [Fact]
        public void BaseTest()
        {
            // Arrange
            var testData = " Bobo ";

            // Act
            var result = testData.RemoveSpacesFromBeginning();

            // Assert
            Assert.Equal("Bobo ", result);
        }

        [Fact]
        public void EmptyStringTest()
        {
            // Arrange
            var testData = "";

            // Act
            var result = testData.RemoveSpacesFromBeginning();

            // Assert
            Assert.Equal("", result);
        }

        [Fact]
        public void WhiteSaceTest()
        {
            // Arrange
            var testData = " ";

            // Act
            var result = testData.RemoveSpacesFromBeginning();

            // Assert
            Assert.Equal("", result);
        }

        [Fact]
        public void DoubledSacesTest()
        {
            // Arrange
            var testData = "  Bob";

            // Act
            var result = testData.RemoveSpacesFromBeginning();

            // Assert
            Assert.Equal("Bob", result);
        }
    }
}
