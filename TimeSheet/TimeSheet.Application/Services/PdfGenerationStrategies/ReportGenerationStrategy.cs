using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheet.Domain.Models;
using TimeSheet.Domain.Strategy;

namespace TimeSheet.Application.Services.PdfGenerationStrategies
{
    public class ReportGenerationStrategy<T> : IPdfGenerationStrategy<T> where T : Report
    {
        private T Value { get; set; }

        public ReportGenerationStrategy(T value)
        {
            Value = value;
        }

        public string GenerateHTML()
        {
            return string.Join("<br>", Value.ReportInstance.Select(ri => $"Date: {ri.Date.ToString()} Worker: {ri.TeamMember} Client: {ri.ProjectName} Category: {ri.CategoryName} Time: {ri.Time}"));
        }
    }
}
