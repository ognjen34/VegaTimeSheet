
using TimeSheet.Domain.Models;
using TimeSheet.Domain.Interfaces.Services;
using DinkToPdf.Contracts;
using DinkToPdf;

namespace TimeSheet.Application.Services
{
    public class PdfGenerationService: IPdfGenerationService
    {
        private readonly IConverter _converter;

        public PdfGenerationService(IConverter converter)
        {
            _converter = converter;
        }

        public byte[] GeneratePdf(Report report)
        {
            string html = string.Empty;
            foreach (ReportInstance ri in report.ReportInstance)
            {
                html += $"Date: {ri.Date.ToString()} Worker: {ri.TeamMember} Client: {ri.ProjectName} Category: {ri.CategoryName} Time: {ri.Time}";
            }
            var document = new HtmlToPdfDocument
            {
                GlobalSettings = {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Landscape,
                PaperSize = PaperKind.A4,
            },
                Objects = {
                new ObjectSettings
                {
                    PagesCount = true,
                    HtmlContent = html,
                    WebSettings = { DefaultEncoding = "utf-8" },
                }
            }
            };

            return _converter.Convert(document);
        }
    }
}
