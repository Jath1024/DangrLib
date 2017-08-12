// -----------------------------------------------------------------------
//  <copyright file="StringExtensions.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------
namespace Dangr.Core.Util
{
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Provides string utility methods
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Converts a string from ALL_CAPS to PascalCase.
        /// </summary>
        /// <param name="capsString">The caps string.</param>
        /// <returns>
        /// The PascalCase representation of the given string.
        /// </returns>
        public static string CapsToPascalCase(this string capsString)
        {
            if (!capsString.IsCapsCase())
            {
                return capsString;
            }

            StringBuilder sb = new StringBuilder();

            bool nextIsCaps = true;
            foreach (char c in capsString)
            {
                if (c == '_')
                {
                    nextIsCaps = true;
                }
                else
                {
                    if (nextIsCaps)
                    {
                        sb.Append(c);
                        nextIsCaps = false;
                    }
                    else
                    {
                        sb.Append(char.ToLowerInvariant(c));
                    }
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// Determines whether the specified string is caps case.
        /// </summary>
        /// <param name="capsString">The caps string.</param>
        /// <returns>
        /// <c> true </c> if the specified string is caps case; otherwise, <c> false </c> .
        /// </returns>
        public static bool IsCapsCase(this string capsString)
        {
            return capsString.All(c => !char.IsLetter(c) || !char.IsLower(c));
        }

        /// <summary>
        /// Escapes a string for use as verbatim string, replacing all " characters with "".
        /// </summary>
        /// <param name="verbatimString">The string to escape.</param>
        /// <returns>The escaped string.</returns>
        public static string EscapeVerbatimString(this string verbatimString)
        {
            return verbatimString.Replace("\"", "\"\"");
        }

        /// <summary>
        /// Escapes the double quotes within a string, replacing all " characters with \".
        /// </summary>
        /// <param name="quoteString">The string to escape.</param>
        /// <returns>The escaped string.</returns>
        public static string EscapeStringQuotes(this string quoteString)
        {
            return quoteString.Replace("\"", "\\\"");
        }
    }
}