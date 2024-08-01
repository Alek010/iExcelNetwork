﻿// Ignore Spelling: Json
using System;

namespace VisJsNetworkLibrary.Exceptions
{
    public class JsonStringIsNullException : Exception
    {
        public JsonStringIsNullException()
        {
        }

        public JsonStringIsNullException(string message) : base(message)
        {
        }

        public JsonStringIsNullException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
