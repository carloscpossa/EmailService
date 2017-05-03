using EmailService.Interfaces;
using System.Collections.Generic;

namespace EmailService
{
    public class EnvioEmailApp : IEnvioEmailApp
    {
        private readonly IEnvioEmail _envioEmail;
        private readonly IValidadorEmail _validadorEmail;
        private readonly IDestinatarioFactory _destinatarioFactory;
        private readonly IAnexoFactory _anexoFactory;

        public EnvioEmailApp(IEnvioEmail envioEmail, IValidadorEmail validadorEmail, IDestinatarioFactory destinatarioFactory, IAnexoFactory anexoFactory)
        {
            _envioEmail = envioEmail;
            _validadorEmail = validadorEmail;
            _destinatarioFactory = destinatarioFactory;
            _anexoFactory = anexoFactory;
        }

        public void EnviarEmail(string enderecoEmailRemetente, string smtpRemetente, string senhaRemente, int portaSmtp, bool habilitaSSL, string[] destinatarios, string[] comCopia, string[] comCopiaOculta, string[] anexos, string assunto, string textoEmail)
        {            
            EnderecoEmail enderecoRemetente = new EnderecoEmail(enderecoEmailRemetente, _validadorEmail);
            SMTP smtp = new SMTP(smtpRemetente, portaSmtp, habilitaSSL);

            Remetente remetente = new Remetente(enderecoRemetente, smtp, senhaRemente);

            List<Destinatario> listaDestinatarios = _destinatarioFactory.criarDestinatarios(destinatarios);
            
            List<Destinatario> listaComCopia = _destinatarioFactory.criarDestinatarios(comCopia);

            List<Destinatario> listaComCopiaOculta = _destinatarioFactory.criarDestinatarios(comCopiaOculta);

            List<Anexo> listaAnexos = _anexoFactory.criarAnexos(anexos);
            
            Email email = new Email(remetente, listaDestinatarios, assunto, textoEmail, listaAnexos, listaComCopia, listaComCopiaOculta);

            _envioEmail.EnviarEmail(email);

        }
    }
}
