using MailKit.Net.Smtp;
using MimeKit;
using System.Threading.Tasks;

namespace GeradorAtack.Services
{
    public class EmailService
    {
        private readonly string _smtpServer = "mail.turmadableia.com.br";
        private readonly int _smtpPort = 465; 
        private readonly string _smtpUser = "teste@turmadableia.com.br";
        private readonly string _smtpPassword = "dd!RcK6O%DjUm#^p"; 

        public async Task EnviarEmailComAnexoAsync(string destinatario, string assunto, string corpo, byte[] anexoBytes, string nomeArquivoAnexo)
        {
            var mensagem = new MimeMessage();
            mensagem.From.Add(new MailboxAddress("Weslei Rafael", _smtpUser));
            
            mensagem.To.Add(new MailboxAddress("Rafael", destinatario));
            mensagem.Subject = assunto;

            var corpoMensagem = new BodyBuilder
            {
                TextBody = corpo
            };

            
            if (anexoBytes != null)
            {
                corpoMensagem.Attachments.Add(nomeArquivoAnexo, anexoBytes);
            }

            mensagem.Body = corpoMensagem.ToMessageBody();

            using (var cliente = new SmtpClient())
            {
                
                await cliente.ConnectAsync(_smtpServer, _smtpPort, MailKit.Security.SecureSocketOptions.SslOnConnect);
                await cliente.AuthenticateAsync(_smtpUser, _smtpPassword);
                await cliente.SendAsync(mensagem);
                await cliente.DisconnectAsync(true);
            }
        }
    }
}
