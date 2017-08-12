// -----------------------------------------------------------------------
//  <copyright file="RegistryException.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------
namespace Dangr.Internal.Registry
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