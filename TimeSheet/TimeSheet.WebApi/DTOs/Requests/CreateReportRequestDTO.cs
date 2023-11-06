using Microsoft.AspNetCore.Mvc;

namespace TimeSheet.WebApi.DTOs.Requests
{
    public class CreateReportRequestDTO
    {

        public string? UserId { get; set; }
        public string? ClientId { get; set; }
        public string? ProjectId { get; set; }
        public string? CategoryId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
