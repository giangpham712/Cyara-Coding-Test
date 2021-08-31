using System;
using System.Collections.Generic;
using System.Text;

namespace CyaraCodingTest.Application.Contracts.Dtos
{
    public class ApiData
    {
        public string ApiToken { get; set; }
        public DateTime ValidTo { get; set; }
        public string AppUrl { get; set; }
        public bool IsActive { get; set; }
    }
}
