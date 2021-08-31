using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CyaraCodingTest.Core.Token
{
    public class DefaultApiTokenProvider : IApiTokenProvider
    {
        const string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private readonly Random _random;

        public DefaultApiTokenProvider()
        {
            _random = new Random();
        }

        public string Generate(int minLength, int maxLength)
        {
            var length = _random.Next(minLength, maxLength + 1);
            
            return new string(Enumerable.Repeat(Chars, length)
                .Select(s => s[_random.Next(s.Length)]).ToArray());
        }
    }
}
