using System.Collections.Generic;
using TypingMVCCore.DomainModels;
using TypingMVCCore.Helpers;
using Xunit;

namespace XUnitTestTypingMVCCore
{
    public class GetAuthorsFullNameListTest : BaseTestApplicationDbContext
    {
        //[Fact] TODO
        public void Test()
        {
            // Arrange
            var authorNamesHelper = new GetAuthorsFullNameListHelper(_context);

            // Act
            var bookID = 1;
            var bookAuthors = authorNamesHelper.Get(bookID);

            // Assert
            Assert.Equal("Bob Code, John Travolta", bookAuthors); 
        }



    }
}
