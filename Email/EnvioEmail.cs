using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Net.Mime;
using System.Net;
using EmailService.Interfaces;
using System.Linq;
using System.Text;

namespace EmailService
{
    public class EnvioEmail : IEnvioEmail
    {                
        public void EnviarEmail(Email email)
        {
            if (email == null)
            {
                throw new ArgumentException("Favor informar um objeto e-mail válido para ser enviado.");
            }

            try
            {
                MailMessage mensagemEmail = new MailMessage();

                foreach (Destinatario destinatario in email.Destinatarios)
                {
                    mensagemEmail.To.Add(destinatario.EnderecoEmail.enderecoEmail);
                }

                foreach (Destinatario comCopia in email.ComCopia)
                {
                    mensagemEmail.CC.Add(comCopia.EnderecoEmail.enderecoEmail);
                }

                foreach (Destinatario comCopiaOculta in email.ComCopiaOculta)
                {
                    mensagemEmail.CC.Add(comCopiaOculta.EnderecoEmail.enderecoEmail);
                }
                
                foreach (Anexo anexo in email.Anexos)
                {
                    Attachment anex = new Attachment(anexo.CaminhoArquivo, MediaTypeNames.Application.Octet);
                    mensagemEmail.Attachments.Add(anex);
                }

                mensagemEmail.Subject = email.Assunto;
                mensagemEmail.Body = email.Texto;
                mensagemEmail.From = new MailAddress(email.Remetente.EnderecoEmail.enderecoEmail);

                mensagemEmail.SubjectEncoding = Encoding.GetEncoding("UTF-8");
                mensagemEmail.BodyEncoding = Encoding.GetEncoding("UTF-8");

                SmtpClient client = new SmtpClient(email.Remetente.SMTP.servidorSMTP);
                client.Port = email.Remetente.SMTP.Porta;                
                client.EnableSsl = email.Remetente.SMTP.HabilitarSSL;
                client.Timeout = 10000000;
                client.UseDefaultCredentials = false;
                NetworkCredential cred = new NetworkCredential(email.Remetente.EnderecoEmail.enderecoEmail, email.Remetente.SenhaEmail);                                
                client.Credentials = cred;
                                               
                client.Send(mensagemEmail);                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
