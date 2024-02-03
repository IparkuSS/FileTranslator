using Parser.PL.Services.Contracts;
using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;
using System.IO;
using System.Text;

namespace Parser.PL.Services
{
    public class ParserPdf : IParser
    {
        public string ReadContentFile(byte[] dataBytes)
        {
            using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(dataBytes))
            {
                StringBuilder text = new StringBuilder();

                foreach (PdfPageBase page in loadedDocument.Pages)
                {
                    text.Append(page.ExtractText());
                }

                return text.ToString();
            }
        }

        public byte[] ModifyAndCreateDocument(byte[] originalDataBytes, string modifiedText)
        {
            using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(originalDataBytes))
            {
                using (PdfDocument newDocument = new PdfDocument())
                {
                    foreach (PdfPageBase page in loadedDocument.Pages)
                    {
                        // Создание новой страницы
                        PdfPage newPage = newDocument.Pages.Add();

                        // Изменение текста
                        PdfGraphics graphics = newPage.Graphics;
                        PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 12);
                        graphics.DrawString(modifiedText, font, PdfBrushes.Black, new PointF(10, 10));
                    }

                    // Сохранение в том же формате
                    using (MemoryStream newStream = new MemoryStream())
                    {
                        newDocument.Save(newStream);
                        return newStream.ToArray();
                    }
                }
            }
        }
    }

}
