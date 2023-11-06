using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheet.Domain.Models;

namespace TimeSheet.Domain.Interfaces.Repositories
{
    public interface IReportService
    {
        Task<Report> GenerateReport(CreateReport reportParams);
        Task<byte[]> GenerateReportPdf(CreateReport reportParams);
    }
}
