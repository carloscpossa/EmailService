using EmailService;
using EmailService.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace EmailTest1
{
    [TestClass]
    public class EnvioEmailAppTest
    {                
        private string emailRemetente = "email@email.com.br";
        private string smtpRemetente = "smtp.locaweb.com.br";
        private string senhaRemetente = "1234";
        private int porta = 587;
        private string assunto = "Assunto do e-mail";
        private string texto = "Texto do e-mail";

        [TestMethod]
        public void DeveEnviarEmailSemAnexo()
        {
            Mock<IEnvioEmail> envioEmail = new Mock<IEnvioEmail>();            

            ValidadorEmail validador = new ValidadorEmail();
            DestinatarioFactory destFactory = new DestinatarioFactory(validador);
            AnexoFactory anexoFactory = new AnexoFactory();

            EnvioEmailApp envioEmailApp = new EnvioEmailApp(envioEmail.Object, validador, destFactory, anexoFactory);

            string[] emailDest = new string[1];
            emailDest[0] = emailRemetente;

            envioEmailApp.EnviarEmail(emailRemetente, smtpRemetente, senhaRemetente, porta, false, emailDest, emailDest, emailDest, new string[0], assunto, texto);            
        }
    }
}
