using TimeSheet.Domain.Models;

namespace TimeSheet.WebApi.DTOs.Responses
{
    public class ReportResponse
    {
        public List<ReportInstanceDTO> ReportInstance { get; set; }
        public ReportResponse()
        {
            ReportInstance = new List<ReportInstanceDTO>();
        }
    }
}
