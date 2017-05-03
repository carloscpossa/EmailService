using EmailService;
using EmailService.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace EmailTest1
{
    [TestClass]
    public class EnderecoEmailTest
    {

        private List<string> emailsValidos;
        private List<string> emailsInvalidos;

        private List<string> criaEmailsValidos()
        {
            List<string> lista = new List<string>();
            lista.Add("joao@yahoo.com.br");
            lista.Add("eduardo@terra.com.br");
            lista.Add("maria_silva@hotmail.com");
            lista.Add("josedasilva@josedasilva.com");

            return lista;
        }

        private List<string> criaEmailsInvalidos()
        {
            List<string> lista = new List<string>();
            lista.Add(" ");
            lista.Add("@");
            lista.Add("12336482376548");
            lista.Add("soiglsdkgsldkg");

            return lista;
        }

        [TestInitialize]
        public void Inicializa()
        {
            emailsValidos = criaEmailsInvalidos();
            emailsInvalidos = criaEmailsInvalidos();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
        public void DeveRetornarExcessaoQuandoCriarEnderecoEmailComValidadorNull()
        {            
            EnderecoEmail endereco = new EnderecoEmail("", null);            
        }
                

        [TestMethod]
        [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
        public void DeveRetornarExcessaoSeEnderecoEmailAserCriadoForInvalido()
        {
            foreach (string email in emailsInvalidos)
            {
                Mock<IValidadorEmail> validador = new Mock<IValidadorEmail>();
                validador.Setup(v => v.EmailValido(email)).Returns(false);
                EnderecoEmail endereco = new EnderecoEmail(email, validador.Object);
                validador.Verify(v => v.EmailValido(email));
            }
        }

        [TestMethod]
        public void DeveRetornaObjetoCriadoComEnderecoCorretoParaEmailsValidos()
        {
            foreach (string email in emailsValidos)
            {
                Mock<IValidadorEmail> validador = new Mock<IValidadorEmail>();
                validador.Setup(v => v.EmailValido(email)).Returns(true);
                EnderecoEmail endereco = new EnderecoEmail(email, validador.Object);
                validador.Verify(v => v.EmailValido(email));

                Assert.AreEqual(email, endereco.enderecoEmail);
            }
        }
    }
}
