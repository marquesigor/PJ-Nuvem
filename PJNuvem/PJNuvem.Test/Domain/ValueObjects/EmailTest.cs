using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PJNuvem.Domain.ValueObjects;

namespace PJNuvem.Test.Domain.ValueObjects
{
    [TestCategory("Email")]
    [TestClass]
    public class EmailTest
    {
        [TestCategory("Construtor")]
        [TestMethod]
        public void DeveRetornarUmaNotificacaoPorNaoInformarUmEmailValido()
        {
            var classe = new Email("email");
            classe.Notifications.Count.Should().Be(1);
        }

        [TestCategory("Construtor")]
        [TestMethod]
        public void DeveRetornarDuasNotificacoesPorNaoSerUmEmailEPassarVazio()
        {
            var classe = new Email("");
            classe.Notifications.Count.Should().Be(2);
        }

        [TestCategory("Construtor")]
        [TestMethod]
        public void DeveRetornarUmaNotificacaoPorNaoInformarAQuantidadeCorretaDeCaracteres()
        {
            var classe = new Email("email@dominiodominiodominiodominiodominiodominiodominiodominiodominiodominiodominiodominiodominiodominiodominiodominiodominiodominiodominiodominiodominiodominiodominiodominiodominiodominiodominio.com.br");
            classe.Notifications.Count.Should().Be(1);
        }

        [TestCategory("Construtor")]
        [TestMethod]
        public void NaoDeveRetornarNotificacaoPornformarCorretamente()
        {
            var classe = new Email("email@dominio.com.br");
            classe.Notifications.Count.Should().Be(0);
        }
    }
}