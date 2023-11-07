namespace TimeSheet.WebApi.DTOs.Requests
{
    public class PaginationFilterRequest :PaginationRequest
    {

        public string StringQuery {  get; set; }
        public string FirstLetter {  get; set; }
        public PaginationFilterRequest()
        {
        
            StringQuery = string.Empty;
            FirstLetter = string.Empty;

        }
        public PaginationFilterRequest(int pageNumber, int pageSize) :base(pageNumber, pageSize) 
        {
            
        }
    }
}
