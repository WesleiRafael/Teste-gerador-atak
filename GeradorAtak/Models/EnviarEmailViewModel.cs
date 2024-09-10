using System.ComponentModel.DataAnnotations;

public class EnviarEmailViewModel
{
    [Required]
    [EmailAddress]
    public string Destinatario { get; set; }

    [Required]
    public string Assunto { get; set; }

    [Required]
    public string Corpo { get; set; }

    public IFormFile Anexo { get; set; }
}
