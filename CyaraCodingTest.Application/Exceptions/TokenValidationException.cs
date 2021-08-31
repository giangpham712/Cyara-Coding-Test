using System;
using System.Collections.Generic;
using System.Text;

namespace CyaraCodingTest.Application.Exceptions
{
    public class TokenValidationException : Exception
    {
        public TokenValidationException(string message) : base(message)
        {
        }
    }
}
