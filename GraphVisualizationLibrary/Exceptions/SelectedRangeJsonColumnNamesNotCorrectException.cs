﻿// Ignore Spelling: Json
using System;

namespace GraphVisualizationLibrary.Exceptions
{
    public class SelectedRangeJsonColumnNamesNotCorrectException : Exception
    {
        public SelectedRangeJsonColumnNamesNotCorrectException()
        {
        }

        public SelectedRangeJsonColumnNamesNotCorrectException(string message) : base(message)
        {
        }

        public SelectedRangeJsonColumnNamesNotCorrectException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
