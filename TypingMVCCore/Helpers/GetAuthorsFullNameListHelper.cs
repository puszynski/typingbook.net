using System.Collections.Generic;
using TypingMVCCore.DomainModels;

namespace TypingMVCCore.Helpers
{
    public class GetAuthorsFullNameListHelper
    {
        public string Get(List<Author> authorsList)
        {
            var result = "";
            
            if (authorsList != null)
            {
                foreach (var item in authorsList)
                {
                    if (authorsList.IndexOf(item) == authorsList.Count - 1) 
                        result += item.FirstName + " " + item.LastName; // the last item
                    else
                        result += item.FirstName + " " + item.LastName + ", ";
                }
            }
            return result;
        }
    }
}
