using GeradorAtack.Services;
using Microsoft.AspNetCore.Mvc;

public class EmailController : Controller
{
    private readonly EmailService _emailService;

    public EmailController(EmailService emailService)
    {
        _emailService = emailService;
    }

    [HttpGet]
    public IActionResult EnviarEmail()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> EnviarEmail(EnviarEmailViewModel model)
    {
        if (ModelState.IsValid)
        {
            byte[] anexoBytes = null;
            string nomeArquivoAnexo = null;

            if (model.Anexo != null && model.Anexo.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await model.Anexo.CopyToAsync(memoryStream);
                    anexoBytes = memoryStream.ToArray();
                    nomeArquivoAnexo = model.Anexo.FileName;
                }
            }

            await _emailService.EnviarEmailComAnexoAsync(
                model.Destinatario,
                model.Assunto,
                model.Corpo,
                anexoBytes,
                nomeArquivoAnexo);

            ViewBag.Mensagem = "E-mail enviado com sucesso!";
            return RedirectToAction("Index", "Home"); 
        }

        
        return View(model);
    }
}
