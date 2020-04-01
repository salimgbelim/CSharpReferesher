using System.Collections.Generic;

namespace GradeBook.Tests.AdapterPattern
{
    public class ApiResult<T>
    {
        public int Count { get; set; }
        public List<T> Results { get; set; }
    }
}