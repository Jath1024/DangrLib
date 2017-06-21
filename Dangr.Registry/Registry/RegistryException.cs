// -----------------------------------------------------------------------
//  <copyright file="RegistryException.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
//  <dateCreated>2017-04-24</dateCreated>
//  <dateModified>2017-06-20</dateModified>
//  <lastModifiedBy>Dan Garvey</lastModifiedBy>
// -----------------------------------------------------------------------

namespace Dangr.Registry
{
    using System;

    internal static class RegistryException
    {
        public static ArgumentException RegistryValueNotFoundException(string key, Type expectedType)
        {
            string message = $"Registry value '{key}' of type '{expectedType.Name}' not found.";

            return new ArgumentException(message);
        }

        public static ArgumentException InvalidKeyException(string key)
        {
            string message = $"Key '{key ?? "[null]"}' is not a valid registry key.";

            return new ArgumentException(message);
        }
    }
}