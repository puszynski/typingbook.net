﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TypingMVCApp.Extensions
{
    public static class StringExtensions
    {
        public static string RemoveSpacesFromBeginning(this string input)
        {
            var result = input;

            while (result[0].ToString() == " ")
                result = result.Substring(1, result.Length - 1);

            return result;
        }
    }
}