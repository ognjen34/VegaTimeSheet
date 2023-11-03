using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TimeSheet.Domain.Interfaces.Services;
using TimeSheet.Domain.Models;
using TimeSheet.WebApi.DTOs.Requests;
using TimeSheet.WebApi.DTOs.Responses;

namespace TimeSheet.WebApi.Controllers
{
    [ApiController]
    [Route("reports")]
    public class ReportController:ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IWorkHourService _workHourService;
        private readonly IPdfGenerationService _pdfGenerationService;
        

        public ReportController(IMapper mapper, IWorkHourService workHourService, IPdfGenerationService pdfGenerationService)
        {
            _mapper = mapper;
            _workHourService = workHourService;
            _pdfGenerationService = pdfGenerationService;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetProductsByCategoryAndPrice([FromQuery] CreateReportRequest reportRequest)
        {
            IEnumerable<WorkHour> workHours= await _workHourService.GetUsersWorkHoursForReports(reportRequest.UserId,reportRequest.ClientId,reportRequest.ProjectId, reportRequest.CategoryId,reportRequest.StartDate,reportRequest.EndDate);
            Report report = new Report();
            report.ReportInstance = workHours.Select(workHour => _mapper.Map<ReportInstance>(workHour)).ToList();
            return Ok(_mapper.Map<ReportResponse>(report));
        }

        [HttpGet("download")]
        public async Task<IActionResult> DownloadPDF([FromQuery] CreateReportRequest reportRequest)
        {

            IEnumerable<WorkHour> workHours = await _workHourService.GetUsersWorkHoursForReports(reportRequest.UserId, reportRequest.ClientId, reportRequest.ProjectId, reportRequest.CategoryId, reportRequest.StartDate, reportRequest.EndDate);
            Report report = new Report();
            report.ReportInstance = workHours.Select(workHour => _mapper.Map<ReportInstance>(workHour)).ToList();

            var pdfBytes = _pdfGenerationService.GeneratePdf(report);

            Response.Headers.Add("Content-Disposition", "attachment; filename=report.pdf");
            return File(pdfBytes, "application/pdf");
        }
    }
}
