using TypingMVCCore.Extensions;
using Xunit;

namespace XUnitTestTypingMVCCore
{
    public class RemoveSpacesFromBeginning
    {
        [Fact]
        public void Test1()
        {
            // Arrange
            var testData = " Bobo ";

            // Act
            var result = testData.RemoveSpacesFromBeginning();

            // Assert
            Assert.Equal("Bobo ", result);
        }
    }
}
