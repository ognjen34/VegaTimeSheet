using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TimeSheet.Domain.Interfaces.Repositories;
using TimeSheet.Domain.Interfaces.Services;
using TimeSheet.Domain.Models;
using TimeSheet.WebApi.DTOs.Requests;
using TimeSheet.WebApi.DTOs.Responses;

namespace TimeSheet.WebApi.Controllers
{
    [ApiController]
    [Route("reports")]
    public class ReportController:BaseController
    {
        private readonly IReportService _reportService;
        

        public ReportController(IMapper mapper, IReportService reportService) : base(mapper)
        {
            _reportService = reportService;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetProductsByCategoryAndPrice([FromQuery] CreateReportRequestDTO reportRequest)
        {
            Report report = await _reportService.GenerateReport(_mapper.Map<CreateReport>(reportRequest));
            return Ok(_mapper.Map<ReportResponse>(report));
        }

        [HttpGet("download")]
        public async Task<IActionResult> DownloadPDF([FromQuery] CreateReportRequestDTO reportRequest)
        {


            var pdfBytes = await _reportService.GenerateReportPdf(_mapper.Map<CreateReport>(reportRequest));

            Response.Headers.Add("Content-Disposition", "attachment; filename=report.pdf");
            return File(pdfBytes, "application/pdf");
        }
    }
}
