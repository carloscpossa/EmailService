using EmailService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailTest1
{
    [TestClass]
    public class AnexoFactoryTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), AllowDerivedTypes = true)]
        public void DeveRetornarExcessaoNaCriacaoDeListaDeAnexoSeArrayDeCaminhoDoAnexoForNula()
        {
            AnexoFactory anexoFactory = new AnexoFactory();
            anexoFactory.criarAnexos(null);
        }

        [TestMethod]
        public void DeveRetornarListaDeAnexoVaziaQuandoInformarArrayDeCaminhoDeArquvioVazio()
        {
            string[] arrayVazio = new string[0];
            AnexoFactory anexoFactory = new AnexoFactory();
            List<Anexo> listaAnxeo = anexoFactory.criarAnexos(arrayVazio);
            Assert.AreEqual(0, listaAnxeo.Count);
        }

        [TestMethod]
        public void DeveDesconsiderarElementoVazioParaCriacaoDaListaDeAnexo()
        {
            string[] anexos = new string[3];
            anexos[0] = "";
            anexos[1] = "e:\a.txt";
            anexos[2] = "      ";

            AnexoFactory anexoFactory = new AnexoFactory();
            List<Anexo> listaAnexos = anexoFactory.criarAnexos(anexos);
            Assert.AreEqual(1, listaAnexos.Count);
            Assert.AreEqual(anexos[1], listaAnexos[0].CaminhoArquivo);
        }

        [TestMethod]
        public void DeveDesconsiderarElementoNuloParaCriacaoDaListaDeDestinatario()
        {
            string[] anexos = new string[3];
            anexos[0] = null;
            anexos[1] = "e:\a.txt";
            anexos[2] = "      ";

            AnexoFactory anexoFactory = new AnexoFactory();
            List<Anexo> listaAnexos = anexoFactory.criarAnexos(anexos);
            Assert.AreEqual(1, listaAnexos.Count);
            Assert.AreEqual(anexos[1], listaAnexos[0].CaminhoArquivo);
        }

        [TestMethod]
        public void DeveRetornarListaDeAnexosComOMesmoNumeroDeElementosDoArrayDeCaminhoArquivo()
        {
            string[] anexos = new string[3];
            anexos[0] = @"e:\a.txt";
            anexos[1] = @"e:\Carlos.jpg";
            anexos[2] = @"E:\Bancos Clientes\log.txt";
            

            AnexoFactory anexoFactory = new AnexoFactory();
            List<Anexo> listaAnexos = anexoFactory.criarAnexos(anexos);
            Assert.AreEqual(anexos.Length, listaAnexos.Count);

            Assert.AreEqual(anexos[0], listaAnexos[0].CaminhoArquivo);
            Assert.AreEqual(anexos[1], listaAnexos[1].CaminhoArquivo);
            Assert.AreEqual(anexos[2], listaAnexos[2].CaminhoArquivo);            
        }
    }
}
