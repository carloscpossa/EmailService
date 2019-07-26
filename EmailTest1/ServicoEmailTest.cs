using EmailService;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmailTest1
{
    [TestClass]
    public class ServicoEmailTest
    {
        private string emailRemetente = "carlos@mastersig.com.br";
        private string smtpRemetente = "smtp.gmail.com";
        private string senhaRemetente = "chcp9883";
        private int porta = 587;
        private bool habilitaSSL = true;
        private string assunto = "Assunto do email";
        private string texto = "Texto do email";
        

        [TestMethod]
        public void DeveEnviarEmailSemAnexo()
        {
            ServicoEmail servicoEmail = new ServicoEmail();
            servicoEmail.EnviarEmail(emailRemetente, smtpRemetente, senhaRemetente, porta, habilitaSSL, emailRemetente, emailRemetente, emailRemetente, "", assunto, texto);                        
        }

        [TestMethod]
        public void DeveEnviarEmailSemComCopia()
        {
            ServicoEmail servicoEmail = new ServicoEmail();
            servicoEmail.EnviarEmail(emailRemetente, smtpRemetente, senhaRemetente, porta, habilitaSSL, emailRemetente, "", emailRemetente, "", assunto, texto);
        }

        [TestMethod]
        public void DeveEnviarEmailComAnexo()
        {
            ServicoEmail servicoEmail = new ServicoEmail();
            servicoEmail.EnviarEmail(emailRemetente, smtpRemetente, senhaRemetente, porta, habilitaSSL, emailRemetente, emailRemetente, emailRemetente, @"e:\a.txt", assunto, texto);
        }
    }
}
