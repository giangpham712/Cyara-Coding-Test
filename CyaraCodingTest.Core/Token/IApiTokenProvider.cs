using System;
using System.Collections.Generic;
using System.Text;

namespace CyaraCodingTest.Core.Token
{
    public interface IApiTokenProvider
    {
        string Generate(int minLength, int maxLength);
    }
}
