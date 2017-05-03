using EmailService;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmailTest1
{
    [TestClass]
    public class ValidadorEmailTest
    {
        private ValidadorEmail validador;

        [TestInitialize]
        public void Inicializacao()
        {
            validador = new ValidadorEmail();
        }

        [TestMethod]                
        public void DeveRetornarFalsoSeEmailForVazio()
        {            
            validador.EmailValido("");
        }        

        [TestMethod]        
        public void DeveRetornarFalsoSeEmailForEspacosBrancos()
        {
            validador.EmailValido("          ");
        }

        [TestMethod]        
        public void DeveRetornarFalsoSeEmailTiverApenasUmArroba()
        {
            Assert.IsFalse(validador.EmailValido("@"));
        }

        [TestMethod]
        public void DeveRetornarFalsoSeEmailTiverApenasMaiDeUmArroba()
        {
            Assert.IsFalse(validador.EmailValido("@@"));
            Assert.IsFalse(validador.EmailValido("@@@"));
            Assert.IsFalse(validador.EmailValido("@@@@"));
            Assert.IsFalse(validador.EmailValido("@@@@@@@@@@@@@"));
        }

        [TestMethod]
        public void DeveRetornarFalsoSeEmailNaoTiverArroba()
        {
            Assert.IsFalse(validador.EmailValido("carlos_cpossa.com.br"));
        }

        [TestMethod]
        public void DeveRetornarFalsoSeEmailComecarComArroba()
        {
            Assert.IsFalse(validador.EmailValido("@gmail.com"));
        }

        [TestMethod]
        public void DeveRetornarFalsoSeEmailTerminarComArroba()
        {
            Assert.IsFalse(validador.EmailValido("carlos@"));
        }

        [TestMethod]
        public void DeveRetornarFalsoSeHouverPontoLogoAposArroba()
        {
            Assert.IsFalse(validador.EmailValido("carlos@.gmail"));
        }

        [TestMethod]
        public void DeveRetornarFalsoSeNaoHouverCaracteresEPontoDepoisDoArroba()
        {
            Assert.IsFalse(validador.EmailValido("carlos@gmail"));
        }

        [TestMethod]
        public void DeveRetornarFalsoSeNaoHouverPontoAposONomeDoDominio()
        {
            Assert.IsFalse(validador.EmailValido("carlos@gmail"));
        }

        [TestMethod]
        public void DeveRetornarFalsoSeNaoHouverPontoECaracteresAposONomeDoDominio()
        {
            Assert.IsFalse(validador.EmailValido("carlos@gmail."));
        }

        [TestMethod]
        public void DeveRetornarFalsoSeHouverCarcteresEspeciaisNoDominio()
        {
            Assert.IsFalse(validador.EmailValido("carlos@gmail#.com"));
            Assert.IsFalse(validador.EmailValido("carlos@gmail!.com"));
            Assert.IsFalse(validador.EmailValido("carlos@gmail$.com"));
            Assert.IsFalse(validador.EmailValido("carlos@gmail%.com"));
            Assert.IsFalse(validador.EmailValido("carlos@gmail*.com"));
            Assert.IsFalse(validador.EmailValido("carlos@gmail&.com"));
        }

        [TestMethod]
        public void DeveRetornaVerdadeiroQuandoEmailPossuirNomeArrobaDominioNaOrdemCorreta()
        {
            Assert.IsTrue(validador.EmailValido("manuel@hotmail.com"));
            Assert.IsTrue(validador.EmailValido("manuel_silva@yahoo.com.br"));
            Assert.IsTrue(validador.EmailValido("carlos@terra.com.br"));
            Assert.IsTrue(validador.EmailValido("carlos@gmail.com.br"));
            Assert.IsTrue(validador.EmailValido("carlos@uol.com.br"));
            Assert.IsTrue(validador.EmailValido("josesilva@josesilva.net"));
            Assert.IsTrue(validador.EmailValido("josesilva@josesilva.net.net.net"));
            Assert.IsTrue(validador.EmailValido("adm.sede@empresaj3.com.br"));
        }
    }
}
