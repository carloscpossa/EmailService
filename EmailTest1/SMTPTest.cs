using EmailService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EmailTest1
{
    [TestClass]
    public class SMTPTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), AllowDerivedTypes = true)]
        public void DeveRetornarExcessaoAoCriarSMTPSemEndereco()
        {
            SMTP smtp = new SMTP("  ", 587, true);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), AllowDerivedTypes = true)]
        public void DeveRetornarExcessaoAoCriarSMTPSemPorta()
        {
            SMTP smtp = new SMTP("smtp.locaweb.com.br", 0, true);
        }

        [TestMethod]
        public void DeveCriarSMTPSemHabilitarSSL()
        {
            SMTP smtp = new SMTP("smtp.terra.com.br", 587, false);
            Assert.AreEqual("smtp.terra.com.br", smtp.servidorSMTP);
            Assert.AreEqual(587, smtp.Porta);
            Assert.IsFalse(smtp.HabilitarSSL);
        }

        [TestMethod]
        public void DeveCriarSMTPComHabilitarSSL()
        {
            SMTP smtp = new SMTP("smtp.gmail.com", 465, true);
            Assert.AreEqual("smtp.gmail.com", smtp.servidorSMTP);
            Assert.AreEqual(465, smtp.Porta);
            Assert.IsTrue(smtp.HabilitarSSL);
        }

    }
}
