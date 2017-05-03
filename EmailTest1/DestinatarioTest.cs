using EmailService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


namespace EmailTest1
{
    [TestClass]
    public class DestinatarioTest
    {        

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),AllowDerivedTypes = true)]
        public void DeveRetornarExcessaoQuandoCriarDestinatarioSemEnderecoEmail()
        {
            Destinatario destinatario = new Destinatario(null);
        }

        [TestMethod]
        public void EnderecoEmailDoDestinatarioDeveSerIgualAoEnderecoInformadoNaCriacaoDoDestinatario()
        {
            string email = "maria_joana@ig.com.br";

            EnderecoEmail endereco = new EnderecoEmail(email, new ValidadorEmail());            
            Destinatario destinatario = new Destinatario(endereco);

            Assert.AreEqual(endereco, destinatario.EnderecoEmail);
        }
    }
}
