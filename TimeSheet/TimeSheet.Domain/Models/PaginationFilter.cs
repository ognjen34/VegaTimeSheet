using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheet.Domain.Models
{
    public class PaginationFilter
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string StringQuery { get; set; }
        public string FirstLetter { get; set; }
        public PaginationFilter()
        {
            PageNumber = 1;
            PageSize = 10;
            StringQuery = string.Empty;
            FirstLetter = string.Empty;
        }
        public PaginationFilter(int pageNumber, int pageSize,string query,string letter)
        {
            PageNumber = pageNumber < 1 || pageNumber == null ? 1 : pageNumber;
            PageSize = pageSize > 10 || pageSize == null ? 10 : pageSize;
            StringQuery = query == null ? "" : query;
            FirstLetter = letter == null ? "" : letter;
        }
    }
}
