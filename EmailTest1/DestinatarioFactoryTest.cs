using EmailService;
using EmailService.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailTest1
{
    [TestClass]
    public class DestinatarioFactoryTest
    {

        private IValidadorEmail validadorEmail;

        [TestInitialize]
        public void Inicializa()
        {
            validadorEmail = new ValidadorEmail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), AllowDerivedTypes = true)]
        public void DeveRetornarExcessaoNaCriacaoDeListaDeDestinatarioSeArrayDeEnderecoDeEmailForNulo()
        {            
            DestinatarioFactory destinatarioFactory = new DestinatarioFactory(validadorEmail);
            destinatarioFactory.criarDestinatarios(null);
        }

        [TestMethod]
        public void DeveRetornarListaDeDestinatarioVaziaSeInformarArrayDeEnderecodeEmailVazio()
        {
            string[] destinatarios = new string[0];
            
            DestinatarioFactory destinatarioFactory = new DestinatarioFactory(validadorEmail);
            List<Destinatario> listaDestinatarios = destinatarioFactory.criarDestinatarios(destinatarios);
            Assert.AreEqual(0, listaDestinatarios.Count);
        }
        
        [TestMethod]
        public void DeveDesconsiderarElementoVazioParaCriacaoDaLista()
        {
            string[] destinatarios = new string[3];
            destinatarios[0] = "";
            destinatarios[1] = "jose@yahoo.com.br";
            destinatarios[2] = "      ";

            DestinatarioFactory destinatarioFactory = new DestinatarioFactory(validadorEmail);
            List<Destinatario> listaDestinatarios = destinatarioFactory.criarDestinatarios(destinatarios);
            Assert.AreEqual(1, listaDestinatarios.Count);
            Assert.AreEqual(destinatarios[1], listaDestinatarios[0].EnderecoEmail.enderecoEmail);
        }

        [TestMethod]
        public void DeveDesconsiderarElementoNuloParaCriacaoDaListaDeDestinatario()
        {
            string[] destinatarios = new string[3];
            destinatarios[0] = null;
            destinatarios[1] = "manoel@uol.com.br";
            destinatarios[2] = "      ";

            DestinatarioFactory destinatarioFactory = new DestinatarioFactory(validadorEmail);
            List<Destinatario> listaDestinatarios = destinatarioFactory.criarDestinatarios(destinatarios);
            Assert.AreEqual(1, listaDestinatarios.Count);
            Assert.AreEqual(destinatarios[1], listaDestinatarios[0].EnderecoEmail.enderecoEmail);
        }


        [TestMethod]
        public void DeveRetornarListaDeDestinatarioComOMesmoNumeroDeElementosDoArrayDeEnderecoDeEmail()
        {
            string[] destinatarios = new string[5];
            destinatarios[0] = "manoel@yahoo.com.br";
            destinatarios[1] = "jose@terra.com.br";
            destinatarios[2] = "mateus@uol.com.br";
            destinatarios[3] = "carloscpossa@gmail.com";
            destinatarios[4] = "josedasilva@hotmail.com"; 
                       
            DestinatarioFactory destinatarioFactory = new DestinatarioFactory(validadorEmail);
            List<Destinatario> listaDestinatarios = destinatarioFactory.criarDestinatarios(destinatarios);
            Assert.AreEqual(destinatarios.Length, listaDestinatarios.Count);

            Assert.AreEqual(destinatarios[0], listaDestinatarios[0].EnderecoEmail.enderecoEmail);
            Assert.AreEqual(destinatarios[1], listaDestinatarios[1].EnderecoEmail.enderecoEmail);
            Assert.AreEqual(destinatarios[2], listaDestinatarios[2].EnderecoEmail.enderecoEmail);
            Assert.AreEqual(destinatarios[3], listaDestinatarios[3].EnderecoEmail.enderecoEmail);
            Assert.AreEqual(destinatarios[4], listaDestinatarios[4].EnderecoEmail.enderecoEmail);
        }
    }
}
