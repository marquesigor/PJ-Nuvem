using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PJNuvem.Domain.ValueObjects;

namespace PJNuvem.Test.Domain.ValueObjects
{
    [TestCategory("Nome")]
    [TestClass]
    public class NomeTest
    {
        [TestCategory("Construtor")]
        [TestMethod]
        public void NaoDeveRetornarUmaNotificacaoPorInformarCorretamenteONomeESobrenome()
        {
            var classe = new Nome("Nome", "Sobrenome");
            classe.Notifications.Count.Should().Be(0);
        }

        [TestCategory("Construtor")]
        [TestMethod]
        public void DeveRetornarDuasNotificacoesPorNaoInformarCorretamenteONomeESobrenome()
        {
            var classe = new Nome("", "");
            classe.Notifications.Count.Should().Be(2);
        }

        [TestCategory("Construtor")]
        [TestMethod]
        public void DeveRetornarUmaNotificacaoPorNaoInformarCorretamenteONome()
        {
            var classe = new Nome("", "Sobrenome");
            classe.Notifications.Count.Should().Be(1);
        }

        [TestCategory("Construtor")]
        [TestMethod]
        public void DeveRetornarUmaNotificacaoPorNaoInformarCorretamenteOSobrenome()
        {
            var classe = new Nome("Nome", "");
            classe.Notifications.Count.Should().Be(1);
        }
    }
}
