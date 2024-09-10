using Microsoft.AspNetCore.Mvc;
using GeradorAtack.Models;
using GeradorAtack.Services;

namespace GeradorAtack.Controllers
{
    public class GerarDadosController : Controller
    {
        private readonly ExcelFileService _excelFileService;
        private readonly EmailService _emailService;

        public GerarDadosController(ExcelFileService excelFileService, EmailService emailService)
        {
            _excelFileService = excelFileService;
            _emailService = emailService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        
        [HttpPost]
        public async Task<IActionResult> EnviarDados(int quantidade)
        {
            if (quantidade < 10 || quantidade > 1000)
            {
                ViewBag.Mensagem = "A quantidade de registros deve estar entre 10 e 1000.";
                return View("Index");
            }

            
            var clientes = GerarClientes(quantidade);

            
            var excelBytes = await _excelFileService.GerarExcelAsync(clientes);

          
            var fileName = "clientes.xlsx";
            var assunto = "Dados Gerados";
            var corpo = "Segue o arquivo gerado em anexo.";

            
            await _emailService.EnviarEmailComAnexoAsync(
                destinatario: "vitor.brito.braga@hotmail.com",
                assunto: assunto,
                corpo: corpo,
                anexoBytes: excelBytes,
                nomeArquivoAnexo: fileName
            );

            ViewBag.Mensagem = "Arquivo gerado e enviado para a diretoria com sucesso!";
            return View("Index");
        }

        
        [HttpPost]
        public async Task<IActionResult> DownloadDados(int quantidade)
        {
            if (quantidade < 10 || quantidade > 1000)
            {
                ViewBag.Mensagem = "A quantidade de registros deve estar entre 10 e 1000.";
                return View("Index");
            }

            
            var clientes = GerarClientes(quantidade);

            
            var excelBytes = await _excelFileService.GerarExcelAsync(clientes);

            
            var fileName = "clientes.xlsx";
            return File(excelBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
        }

        
        private List<Cliente> GerarClientes(int quantidade)
        {
            var clientes = new List<Cliente>();
            for (int i = 0; i < quantidade; i++)
            {
                clientes.Add(new Cliente
                {
                    Nome = $"Cliente {i + 1}",
                    Email = $"cliente{i + 1}@exemplo.com",
                    Telefone = $"(11) 99999-000{i % 10}",
                    DataNascimento = new DateTime(2000, 1, 1).AddDays(i)
                });
            }
            return clientes;
        }
    }
}
