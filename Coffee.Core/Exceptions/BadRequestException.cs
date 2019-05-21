using System;

namespace Coffee.Core.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException() { }

        public BadRequestException(string exception) : base(exception) { }
    }
}