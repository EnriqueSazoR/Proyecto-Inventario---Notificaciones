using ProyectoInventarioReportes.Services.IServices;
using System.Net;
using System.Net.Mail;

namespace ProyectoInventarioReportes.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        private readonly string _appName = "ReporteInventario";

        public EmailService(IConfiguration configuration )
        {
            _configuration = configuration;
        }
        public async Task EnviarCorreoIngresoStock(string producto, int unidades)
        {
            var toAddress = _configuration["ToAddress"];
            if (string.IsNullOrEmpty(toAddress))
                throw new InvalidOperationException("El correo destinatario no está configurado");

            var subject = $"[{_appName}] Ingreso de Stock: {producto}";
            var body = $"Se ha ingresado {unidades} unidades del producto: {producto}";

            await SendEmailAsync(toAddress, subject, body);
        }

        public async Task EnviarCorreoSalidaStock(string producto, int unidades)
        {
            var toAddress = _configuration["ToAddress"];
            if (string.IsNullOrEmpty(toAddress))
                throw new InvalidOperationException("El correo destinatario no está configurado");

            var subject = $"[{_appName}] Salida de Stock: {producto}";
            var body = $"Se ha retirado {unidades} unidades del producto: {producto}";

            await SendEmailAsync(toAddress, subject, body);
        }

        private async Task SendEmailAsync(string toAddress, string subject, string body)
        {
            var smtpHots = _configuration["SmtHost"];
            var smtpPort = int.Parse(_configuration["SmtPort"] ?? "587");
            var smtpUsername = _configuration["SmtpUsername"];
            var smtpPassword = _configuration["SmtpPassword"];
            var fromAddress = _configuration["FromAddress"];

            if(string.IsNullOrEmpty(smtpHots) || string.IsNullOrEmpty(smtpUsername) || 
               string.IsNullOrEmpty(smtpPassword) || string.IsNullOrEmpty(fromAddress))
            {
                throw new InvalidOperationException("Faltan configuraciones SMTP");
            }

            using var smtpClient = new SmtpClient(smtpHots, smtpPort)
            {
                Credentials = new NetworkCredential(smtpUsername, smtpPassword),
                EnableSsl = true
            };

            using var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };

            await smtpClient.SendMailAsync(message);
        }
    }
}
