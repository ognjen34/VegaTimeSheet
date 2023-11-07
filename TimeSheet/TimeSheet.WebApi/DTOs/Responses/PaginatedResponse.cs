using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheet.WebApi.DTOs.Requests;

namespace TimeSheet.WebApi.DTOs.Responses
{
    public class PaginationResponse<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }

        public PaginationResponse(IEnumerable<T> items, PaginationFilterRequest filter)
        {
            Items = items;
            Page = filter.PageNumber;
            PageSize = filter.PageSize;
            TotalItems = items.Count();
        }
        public PaginationResponse(IEnumerable<T> items, PaginationRequest filter)
        {
            Items = items;
            Page = filter.PageNumber;
            PageSize = filter.PageSize;
            TotalItems = items.Count();
        }
        public PaginationResponse() { }
    }
}
