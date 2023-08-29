using ClosedXML.Excel;
using DocumentFormat.OpenXml.Office2013.Word;
using DocumentFormat.OpenXml.Spreadsheet;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.Tests.Commands
{
    public class GenerateExcelCommand : IRequest<byte[]>
    {
    }

    public class GenerateExcelCommandHandler : IRequestHandler<GenerateExcelCommand, byte[]>
    {
        public GenerateExcelCommandHandler()
        {
        }

        Task<byte[]> IRequestHandler<GenerateExcelCommand, byte[]>.Handle(GenerateExcelCommand request, CancellationToken cancellationToken)
        {
            try
            {
                IXLWorkbook workbook = new XLWorkbook();
                IXLWorksheet worksheet = workbook.Worksheets.Add("Sample Sheet");
                List<TestData> testData = new List<TestData>()
                {
                    new TestData
                    {
                        No = 1,
                        Name = "Jane Doe",
                        Currency = 1000000,
                        Date = new DateTime(1991,05,07)
                    },
                    new TestData
                    {
                        No = 2,
                        Name = "John Doe",
                        Currency = 1000000,
                        Date = new DateTime(1991,05,07)
                    }
                };
                worksheet.Cell(1, 1).InsertTable(testData);
                int row = 2;
                foreach (var item in testData)
                {
                    worksheet.Cell(row, 3).Style.NumberFormat.NumberFormatId = 3;
                    worksheet.Cell(row, 4).Style.DateFormat.Format = "dddd MMMM yyyy";
                    row++;
                }
                using (MemoryStream fs = new MemoryStream())
                {
                    workbook.SaveAs(fs);
                    fs.Position = 0;
                    return Task.FromResult(fs.ToArray());
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }

    public class TestData
    {
        [DisplayName("No")]
        public int No { get; set; }
        [DisplayName("Nama")]
        public string Name { get; set; }
        [DisplayName("Nominal")]
        public double Currency { get; set; }
        [DisplayName("Tanggal")]
        public DateTime Date { get; set; }
    }
}
