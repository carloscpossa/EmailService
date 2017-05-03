using EmailService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EmailTest1
{
    [TestClass]
    public class EnvioEmailTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), AllowDerivedTypes = true)]
        public void DeveRetornarExcessaoSeEmailForNulo()
        {
            EnvioEmail envioEmail = new EnvioEmail();
            envioEmail.EnviarEmail(null);
        }
    }
}
