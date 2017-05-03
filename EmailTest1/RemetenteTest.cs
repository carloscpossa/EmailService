using EmailService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EmailTest1
{
    [TestClass]
    public class RemetenteTest
    {
        private SMTP SMTPValido;

        [TestInitialize]
        public void Inicializa()
        {
            SMTPValido = new SMTP("smtp.locaweb.com.br", 587, false);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException),AllowDerivedTypes = true)]
        public void DeveRetornarExcessaoQuandoCriarRemetenteSemEnderecoDeEmail()
        {
            Remetente remetente = new Remetente(null, SMTPValido, "1234");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), AllowDerivedTypes = true)]
        public void DeveRetornarExcessaoQuandoCriarRemetenteSemServidorSMTP()
        {
            EnderecoEmail endereco = new EnderecoEmail("carlos@terra.com.br", new ValidadorEmail());
            Remetente remetente = new Remetente(endereco, null, "1234");
        }        

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), AllowDerivedTypes = true)]
        public void DeveRetornarExcessaoQuandoCriarRemetenteSemSenhaDeEmail()
        {
            EnderecoEmail endereco = new EnderecoEmail("carlos@yahoo.com.br", new ValidadorEmail());
            Remetente remetente = new Remetente(endereco, SMTPValido, "");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), AllowDerivedTypes = true)]
        public void DeveRetornarExcessaoQuandoCriarRemetenteComSenhaDeEmailComEspacos()
        {
            EnderecoEmail endereco = new EnderecoEmail("carlos@terra.com.br", new ValidadorEmail());
            Remetente remetente = new Remetente(endereco, SMTPValido, "     ");
        }

        [TestMethod]
        public void VerificaAtributosDoRemetenteConformeArgumentosDoConstrutorSenha1234()
        {
            EnderecoEmail endereco = new EnderecoEmail("carlos@uol.com.br", new ValidadorEmail());
            Remetente remetente = new Remetente(endereco, SMTPValido, "1234");

            Assert.AreEqual(endereco, remetente.EnderecoEmail);
            Assert.AreEqual(SMTPValido, remetente.SMTP);
            Assert.AreEqual("1234", remetente.SenhaEmail);
        }

        [TestMethod]
        public void VerificaAtributosDoRemetenteConformeArgumentosDoConstrutorSenhaString()
        {
            EnderecoEmail endereco = new EnderecoEmail("mateus@yahoo.com.br", new ValidadorEmail());
            Remetente remetente = new Remetente(endereco, SMTPValido, "senha!1234*");

            Assert.AreEqual(endereco, remetente.EnderecoEmail);
            Assert.AreEqual(SMTPValido, remetente.SMTP);
            Assert.AreEqual("senha!1234*", remetente.SenhaEmail);
        }
    }
}
