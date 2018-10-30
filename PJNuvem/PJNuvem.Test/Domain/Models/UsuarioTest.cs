using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PJNuvem.Domain.Extensions;
using PJNuvem.Domain.Model;
using PJNuvem.Domain.ValueObjects;
using System;

namespace PJNuvem.Domain.Test.Domain.Models
{
    [TestCategory("Usuario")]
    [TestClass]
    public class UsuarioTest
    {
        [TestCategory("Incluir")]
        [TestMethod]
        public void DeveRetornarUmaNotificacaoPorNaoInformarASenhaAoIncluir()
        {
            var classe = new Usuario();
            var email = new Email("email@outlook.com");
            var nome = new Nome("Pessoa", "Teste");
            classe.Incluir(email, nome, "", Guid.NewGuid());
            classe.Notifications.Count.Should().Be(1);
        }

        [TestCategory("Incluir")]
        [TestMethod]
        public void NaoDeveRetornarUmaNotificacaoPorInformarASenhaAoIncluir()
        {
            var classe = new Usuario();
            var email = new Email("email@outlook.com");
            var nome = new Nome("Pessoa", "Teste");
            classe.Incluir(email, nome, "senhaUsuario", Guid.NewGuid());
            classe.Notifications.Count.Should().Be(0);
        }

        [TestCategory("Incluir")]
        [TestMethod]
        public void DeveRetornarUmaNotificacaoPorInformarASenhaIncorretamente()
        {
            var classe = new Usuario();
            var email = new Email("email@outlook.com");
            var nome = new Nome("Pessoa", "Teste");
            classe.Incluir(email, nome, "senha", Guid.NewGuid());
            classe.Notifications.Count.Should().Be(1);
        }

        [TestCategory("Autenticar")]
        [TestMethod]
        public void DeveRetornarUmaNotificacaoPorNaoInformarASenhaAoAlterar()
        {
            var classe = new Usuario();
            var email = new Email("email@outlook.com");
            classe.Autenticar(email, "");
            classe.Notifications.Count.Should().Be(1);
        }

        [TestCategory("Autenticar")]
        [TestMethod]
        public void NaoDeveRetornarUmaNotificacaoPorInformarASenhaAoAlterar()
        {
            var classe = new Usuario();
            var email = new Email("email@outlook.com");
            classe.Autenticar(email, "senhaUsuario");
            classe.Notifications.Count.Should().Be(0);
        }

        [TestCategory("Autenticar")]
        [TestMethod]
        public void DeveRetornarUmaNotificacaoPorInformarASenhaIncorretamenteAoAlterar()
        {
            var classe = new Usuario();
            var email = new Email("email@outlook.com");
            classe.Autenticar(email, "senha");
            classe.Notifications.Count.Should().Be(1);
        }

        [TestCategory("Senha")]
        [TestMethod]
        public void SenhaBatendoComACriptografia()
        {
            const string senhaDescriptografada = "admin1234";
            const string senhaCriptografada = "0a74b8554d010391bde93621748e5520";
            string criptografiaGerada;

            criptografiaGerada = senhaDescriptografada.Criptografa();
            criptografiaGerada.Should().Be(senhaCriptografada);
        }

    }
}