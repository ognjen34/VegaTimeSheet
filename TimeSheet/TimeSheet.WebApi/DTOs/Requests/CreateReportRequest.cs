using Microsoft.AspNetCore.Mvc;

namespace TimeSheet.WebApi.DTOs.Requests
{
    public class CreateReportRequest
    {

        public string? UserId { get; set; }
        public string? ClientId { get; set; }
        public string? ProjectId { get; set; }
        public string? CategoryId { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
    }
}
