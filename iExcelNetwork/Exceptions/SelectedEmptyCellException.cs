﻿using System;

namespace iExcelNetwork.Exceptions
{
    public class SelectedEmptyCellException : Exception
    {
        public SelectedEmptyCellException()
        {
        }

        public SelectedEmptyCellException(string message) : base(message)
        {
        }

        public SelectedEmptyCellException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
