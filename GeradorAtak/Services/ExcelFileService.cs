using OfficeOpenXml;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using GeradorAtack.Models;

namespace GeradorAtack.Services
{
    public class ExcelFileService
    {
        
        public ExcelFileService()
        {
            
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }

        public async Task<byte[]> GerarExcelAsync(List<Cliente> clientes)
        {
            using var package = new ExcelPackage();
            var worksheet = package.Workbook.Worksheets.Add("Clientes");

            
            worksheet.Cells[1, 1].Value = "Nome";
            worksheet.Cells[1, 2].Value = "Email";
            worksheet.Cells[1, 3].Value = "Telefone";
            worksheet.Cells[1, 4].Value = "Data de Nascimento";

            for (int i = 0; i < clientes.Count; i++)
            {
                worksheet.Cells[i + 2, 1].Value = clientes[i].Nome;
                worksheet.Cells[i + 2, 2].Value = clientes[i].Email;
                worksheet.Cells[i + 2, 3].Value = clientes[i].Telefone;
                worksheet.Cells[i + 2, 4].Value = clientes[i].DataNascimento.ToShortDateString();
            }

            return await Task.FromResult(package.GetAsByteArray());
        }
    }
}
