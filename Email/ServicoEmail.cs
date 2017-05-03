using System;
using EmailService.Interfaces;
using System.Runtime.InteropServices;

namespace EmailService
{
    [ClassInterface(ClassInterfaceType.None),
     Guid("E37B8919-8152-4A0C-8723-1F8252E75BD9"),
     ComVisible(true),
     ProgId("EmailService.ServicoEmail")]    

    public class ServicoEmail : IServicoEmail
    {
        private IEnvioEmailApp _envioEmailApp;        

        public ServicoEmail()
        {
            IEnvioEmail envioEmail = new EnvioEmail();
            IValidadorEmail validadorEmail = new ValidadorEmail();
            IDestinatarioFactory destinatarioFactory = new DestinatarioFactory(validadorEmail);
            IAnexoFactory anexoFactory = new AnexoFactory();

            _envioEmailApp = new EnvioEmailApp(envioEmail, validadorEmail, destinatarioFactory, anexoFactory);
        }

        public void EnviarEmail(string enderecoEmailRemetente, string smtpRemetente, string senhaRemente, int portaSmtp, bool habilitaSSL, string destinatarios, string comCopia, string comCopiaOculta, string anexos, string assunto, string textoEmail)
        {
            /*string[] listaDestinatarios = new string[0];
            string[] listaComCopia = new string[0];
            string[] listaComCopiaOculta = new string[0];
            string[] listaAnexos = new string[0];*/

            string[] listaDestinatarios = destinatarios.Split(';');
            string[] listaComCopia = comCopia.Split(';');
            string[] listaComCopiaOculta = comCopiaOculta.Split(';');
            string[] listaAnexos = anexos.Split(';');

            _envioEmailApp.EnviarEmail(enderecoEmailRemetente, smtpRemetente, senhaRemente, portaSmtp, habilitaSSL, listaDestinatarios, listaComCopia, listaComCopiaOculta, listaAnexos, assunto, textoEmail);
        }
    }
}
