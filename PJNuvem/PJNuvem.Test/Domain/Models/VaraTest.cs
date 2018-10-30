using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PJNuvem.Domain.Model;
using System;

namespace PJNuvem.Domain.Test.Domain.Models
{
    [TestCategory("Vara")]
    [TestClass]
    public class VaraTest
    {
        [TestCategory("Incluir")]
        [TestMethod]
        public void DeveRetornarUmaNotificacaoPorNaoInformarADescricaoAoIncluir()
        {
            var classe = new Vara();
            classe.Incluir(Guid.NewGuid(), "");
            classe.Notifications.Count.Should().Be(1);
        }

        [TestCategory("Incluir")]
        [TestMethod]
        public void NaoDeveRetornarUmaNotificacaoPorInformarADescricaoAoIncluir()
        {
            var classe = new Vara();
            classe.Incluir(Guid.NewGuid(), "Descrição");
            classe.Notifications.Count.Should().Be(0);
        }

        [TestCategory("Incluir")]
        [TestMethod]
        public void DeveRetornarUmaNotificacaoPorInformarADescricaoMaiorQueValorLimiteAoIncluir()
        {
            var classe = new Vara();
            classe.Incluir(Guid.NewGuid(), "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type an");
            classe.Notifications.Count.Should().Be(1);
        }

        [TestCategory("Alterar")]
        [TestMethod]
        public void DeveRetornarUmaNotificacaoPorNaoInformarADescricaoAoAlterar()
        {
            var classe = new Vara();
            classe.Alterar(Guid.NewGuid(),Guid.NewGuid(), "");
            classe.Notifications.Count.Should().Be(1);
        }

        [TestCategory("Alterar")]
        [TestMethod]
        public void NaoDeveRetornarUmaNotificacaoPorInformarADescricaoAoAlterar()
        {
            var classe = new Vara();
            classe.Alterar(Guid.NewGuid(),Guid.NewGuid(), "Descrição");
            classe.Notifications.Count.Should().Be(0);
        }

        [TestCategory("Alterar")]
        [TestMethod]
        public void DeveRetornarUmaNotificacaoPorInformarADescricaoMaiorQueValorLimiteAoAlterar()
        {
            var classe = new Vara();
            classe.Alterar(Guid.NewGuid(),Guid.NewGuid(), "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type an");
            classe.Notifications.Count.Should().Be(1);
        }
    }
}
