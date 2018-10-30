using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PJNuvem.Domain.Model;
using System;

namespace PJNuvem.Domain.Test.Domain.Models
{
    [TestCategory("Perfil")]
    [TestClass]
    public class PerfilTest
    {
        [TestCategory("Incluir")]
        [TestMethod]
        public void DeveRetornarUmaNotificacaoPorNaoInformarADescricaoAoIncluir()
        {
            var classe = new Perfil();
            classe.Incluir("");
            classe.Notifications.Count.Should().Be(1);
        }

        [TestCategory("Incluir")]
        [TestMethod]
        public void NaoDeveRetornarUmaNotificacaoPorInformarADescricaoAoIncluir()
        {
            var classe = new Perfil();
            classe.Incluir("Descrição");
            classe.Notifications.Count.Should().Be(0);
        }

        [TestCategory("Incluir")]
        [TestMethod]
        public void DeveRetornarUmaNotificacaoPorInformarADescricaoMaiorQueValorLimiteAoIncluir()
        {
            var classe = new Perfil();
            classe.Incluir("Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type an");
            classe.Notifications.Count.Should().Be(1);
        }

        [TestCategory("Alterar")]
        [TestMethod]
        public void DeveRetornarUmaNotificacaoPorNaoInformarADescricaoAoAlterar()
        {
            var classe = new Perfil();
            classe.Alterar(Guid.NewGuid(), "");
            classe.Notifications.Count.Should().Be(1);
        }

        [TestCategory("Alterar")]
        [TestMethod]
        public void NaoDeveRetornarUmaNotificacaoPorInformarADescricaoAoAlterar()
        {
            var classe = new Perfil();
            classe.Alterar(Guid.NewGuid(), "Descrição");
            classe.Notifications.Count.Should().Be(0);
        }

        [TestCategory("Alterar")]
        [TestMethod]
        public void DeveRetornarUmaNotificacaoPorInformarADescricaoMaiorQueValorLimiteAoAlterar()
        {
            var classe = new Perfil();
            classe.Alterar(Guid.NewGuid(), "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type an");
            classe.Notifications.Count.Should().Be(1);
        }
    }
}
