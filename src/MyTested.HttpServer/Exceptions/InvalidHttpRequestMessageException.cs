﻿namespace MyTested.HttpServer.Exceptions
{
    using System;

    /// <summary>
    /// Exception for invalid HTTP request message.
    /// </summary>
    public class InvalidHttpRequestMessageException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the InvalidHttpRequestMessageException class.
        /// </summary>
        /// <param name="message">Message for System.Exception class.</param>
        public InvalidHttpRequestMessageException(string message)
            : base(message)
        {
        }
    }
}
