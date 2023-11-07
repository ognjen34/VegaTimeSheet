namespace TimeSheet.WebApi.DTOs.Requests
{
    public class PaginationRequest
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public PaginationRequest()
        {
            PageNumber = 1;
            PageSize = 10;
        }
        public PaginationRequest(int pageNumber, int pageSize)
        {
            this.PageNumber = pageNumber < 1 ? 1 : pageNumber;
            this.PageSize = pageSize > 10 ? 10 : pageSize;
        }
    }
}
