using EmailService;
using EmailService.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace EmailTest1
{
    [TestClass]
    public class EmailTest
    {

        private SMTP smtp;
        private string senha = "teste1234mudar";

        private EnderecoEmail enderecoEmailValido;
        private Remetente remetente;

        private IEnumerable<Destinatario> destinatarios;
        private IEnumerable<Destinatario> comCopia;
        private IEnumerable<Destinatario> comCopiaOculta;
        private IEnumerable<Anexo> anexos;

        private string assunto = "Teste de criação de e-mail";
        private string textoMensagem = "Teste de texto de e-mail. Este texto foi criado para teste.";

        public EnderecoEmail criaEnderecoEmailValido()
        {
            string endereco = "teste@yahoo.com.br";
            Mock<IValidadorEmail> validador = new Mock<IValidadorEmail>();
            validador.Setup(v => v.EmailValido(endereco)).Returns(true);
            return new EnderecoEmail(endereco, validador.Object);
        }       
            
        public IEnumerable<Destinatario> criaDestinatarios()
        {
            Mock<IValidadorEmail> validador = new Mock<IValidadorEmail>();
            string endereco1 = "teste@yahoo.com.br";
            string endereco2 = "jose@gmail.com";
            string endereco3 = "joao@terra.com.br";


            List<Destinatario> lista = new List<Destinatario>();           
                                    
            validador.Setup(v => v.EmailValido(endereco1)).Returns(true);
            Destinatario dest1 = new Destinatario(new EnderecoEmail(endereco1, validador.Object));

            validador.Setup(v => v.EmailValido(endereco2)).Returns(true);
            Destinatario dest2 = new Destinatario(new EnderecoEmail(endereco2, validador.Object));

            validador.Setup(v => v.EmailValido(endereco3)).Returns(true);
            Destinatario dest3 = new Destinatario(new EnderecoEmail(endereco3, validador.Object));

            lista.Add(dest1);
            lista.Add(dest2);
            lista.Add(dest3);

            return lista;
        }
        public IEnumerable<Destinatario> criaComCopia()
        {
            Mock<IValidadorEmail> validador = new Mock<IValidadorEmail>();
            string endereco1 = "manoel_qualquer@yahoo.com.br";
            
            List<Destinatario> lista = new List<Destinatario>();

            validador.Setup(v => v.EmailValido(endereco1)).Returns(true);
            Destinatario dest1 = new Destinatario(new EnderecoEmail(endereco1, validador.Object));
            
            lista.Add(dest1);
            
            return lista;
        }
        public IEnumerable<Anexo> criaAnexos()
        {
            List<Anexo> listaAnexo = new List<Anexo>();

            Anexo anexo1 = new Anexo(@"c:\windows\temp\a.txt");
            Anexo anexo2 = new Anexo(@"c:\windows\temp\teste.xls");

            listaAnexo.Add(anexo1);
            listaAnexo.Add(anexo2);

            return listaAnexo;
        }
        
        [TestInitialize]
        public void Inicializa()
        {
            enderecoEmailValido = criaEnderecoEmailValido();
            smtp = new SMTP("smtp.gmail.com", 465, true);
            remetente = new Remetente(enderecoEmailValido, smtp, senha);
            destinatarios = criaDestinatarios();
            comCopia = criaComCopia();
            comCopiaOculta = new List<Destinatario>();
            anexos = criaAnexos();
        }
        

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), AllowDerivedTypes = true)]
        public void DeveRetornarExcessaoQuandoEmailForCriadoSemRemetente()
        {
            Email email = new Email(null, destinatarios, assunto, textoMensagem, anexos, comCopia, comCopiaOculta);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), AllowDerivedTypes = true)]
        public void DeveRetornarExcessaoQuandoEmailForCriadoSemListaDeDestinatario()
        {
            Email email = new Email(remetente, null, assunto, textoMensagem, anexos, comCopia, comCopiaOculta);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), AllowDerivedTypes = true)]
        public void DeveRetornarExcessaoQuandoEmailForCriadoComListaDeDestinarioSemElementos()
        {
            Email email = new Email(remetente, new List<Destinatario>(), assunto, textoMensagem, anexos, comCopia, comCopiaOculta);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), AllowDerivedTypes = true)]
        public void DeveRetornarExcessaoQuandoEmailForCriadoComListaDeAnexoNula()
        {
            Email email = new Email(remetente, new List<Destinatario>(), assunto, textoMensagem, null, comCopia, comCopiaOculta);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), AllowDerivedTypes = true)]
        public void DeveRetornarExcessaoQuandoEmailForCriadoComListaDeComCopiaNula()
        {
            Email email = new Email(remetente, new List<Destinatario>(), assunto, textoMensagem, anexos, null, comCopiaOculta);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), AllowDerivedTypes = true)]
        public void DeveRetornarExcessaoQuandoEmailForCriadoComListaDeComCopiaOcultaNula()
        {
            Email email = new Email(remetente, new List<Destinatario>(), assunto, textoMensagem, anexos, comCopia, null);
        }

        [TestMethod]
        public void DeveCriarEmailComAtributosIguaisAosParametrosPassadosNoConstrutor()
        {
            Email email = new Email(remetente, destinatarios, assunto, textoMensagem, anexos, comCopia, comCopiaOculta);

            Assert.AreEqual(remetente, email.Remetente);
            Assert.AreEqual(destinatarios, email.Destinatarios);
            Assert.AreEqual(assunto, email.Assunto);
            Assert.AreEqual(textoMensagem, email.Texto);
            Assert.AreEqual(anexos, email.Anexos);
            Assert.AreEqual(comCopia, email.ComCopia);
            Assert.AreEqual(comCopiaOculta, email.ComCopiaOculta);
        }
    }
}
