using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DotnetCamp.Instagram.Storage.Disk
{
    public static class Guard
    {
        internal static void StringNullOrEmpty(string argument, string argumentName)
        {
            if (string.IsNullOrEmpty(argument))
                throw new ArgumentNullException(argumentName);
        }

        internal static void Null(object argument, string argumentName)
        {
            if (ReferenceEquals(argument, null))
                throw new ArgumentNullException(argumentName);
        }

        internal static void FileFormat(string argument, string argumentName)
        {
            if (!Regex.IsMatch(argument, @"^[\w\d]+\.\w{3}", RegexOptions.Singleline))
                throw new ArgumentException("Argument using incorrect format", argumentName);
        }
    }
}
