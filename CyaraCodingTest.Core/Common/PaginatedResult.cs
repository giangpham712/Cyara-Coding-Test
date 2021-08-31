using System;
using System.Collections.Generic;
using System.Text;

namespace CyaraCodingTest.Core.Common
{
    public class PaginatedResult<T>
    {
        public List<T> Items { get; set; }
        public int Total { get; set; }
    }
}
