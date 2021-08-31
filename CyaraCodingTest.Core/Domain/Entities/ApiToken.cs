using System;

namespace CyaraCodingTest.Core.Domain.Entities
{
    public class ApiToken
    {
        public string Token { get; set; }
        public string AppUrl { get; set; }
        public DateTime ValidTo { get; set; }
        public bool IsActive { get; set; }
    }
}
