using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheet.Application.Services.PdfGenerationStrategies;
using TimeSheet.Domain.Interfaces.Repositories;
using TimeSheet.Domain.Interfaces.Services;
using TimeSheet.Domain.Models;

namespace TimeSheet.Application.Services
{
    public  class ReportService :IReportService 
    {
        private readonly IWorkHourService _workHourService;
        private readonly IMapper _mapper;
        private readonly IPdfGenerationService _pdfGenerationService;

        public ReportService(IWorkHourService workHourService,IMapper mapper, IPdfGenerationService pdfGenerationService)
        {
            _workHourService = workHourService;
            _mapper = mapper;
            _pdfGenerationService = pdfGenerationService;
        }

        public async Task<Report> GenerateReport(CreateReport reportParams)
        {
            IEnumerable<WorkHour> workHours = await _workHourService.GetUsersWorkHoursForReports(reportParams);
            Report report = new Report();
            report.ReportInstance = _mapper.Map<IEnumerable<ReportInstance>>(workHours).ToList();
            return report;
        }

        public async Task<byte[]> GenerateReportPdf(CreateReport reportParams)
        {
            IEnumerable<WorkHour> workHours = await _workHourService.GetUsersWorkHoursForReports(reportParams);
            Report report = new Report();
            report.ReportInstance = _mapper.Map<IEnumerable<ReportInstance>>(workHours).ToList();

            var pdfGenerationStrategy = new ReportGenerationStrategy<Report>(report);

            return _pdfGenerationService.GeneratePdf(pdfGenerationStrategy);
        }
    }
}
