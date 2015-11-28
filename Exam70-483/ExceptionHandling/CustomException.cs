using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling
{
    // Microsoft best practices for custom exception
    class CustomException : Exception
    {
        public CustomException()
            : base()
        { }

        public CustomException(string message) 
            : base(message)
        { }

        public CustomException(string message, Exception inner)
            : base(message, inner)
        { }
    }
}
