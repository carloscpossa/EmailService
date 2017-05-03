using EmailService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EmailTest1
{
    [TestClass]
    public class AnexoTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), AllowDerivedTypes = true)]
        public void DeveRetornarExcessaoQuandoCriarAnexoSemCaminhoDoArquivo()
        {
            Anexo anexo = new Anexo("   ");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), AllowDerivedTypes = true)]
        public void DeveRetornarExcessaoQuandoCriarAnexoComCaminhoDoArquivoNulo()
        {
            Anexo anexo = new Anexo(null);
        }

        [TestMethod]
        public void DeveRetornarNovoAnexoComCaminhoIgualAoCaminhoPassadoNoConstrutor()
        {
            Anexo anexo = new Anexo(@"c:\windows\temp\a.txt");
            Assert.AreEqual(@"c:\windows\temp\a.txt", anexo.CaminhoArquivo);
        }
    }
}
