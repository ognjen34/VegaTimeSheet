
using TimeSheet.Domain.Models;
using TimeSheet.Domain.Interfaces.Services;
using DinkToPdf.Contracts;
using DinkToPdf;
using TimeSheet.Application.Services.PdfGenerationStrategies;
using TimeSheet.Domain.Strategy;

namespace TimeSheet.Application.Services
{
    public class PdfGenerationService : IPdfGenerationService
    {
        private readonly IConverter _converter;

        public PdfGenerationService(IConverter converter)
        {
            _converter = converter;
        }

        public byte[] GeneratePdf<T>(IPdfGenerationStrategy<T> strategy)
        {
            string html = strategy.GenerateHTML();

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
