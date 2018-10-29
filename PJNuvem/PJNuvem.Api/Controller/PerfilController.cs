using PJNuvem.Api.Controllers.Base;
using PJNuvem.Domain.Arguments.Perfis;
using PJNuvem.Domain.Interfaces.Services;
using PJNuvem.Infra.Transactions;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace PJNuvem.Api.Controller
{
    [Authorize]
    [RoutePrefix("api/v1/perfil")]
    public class PerfilController : ControllerBase
    {
        private readonly IServicePerfil _servicePerfil;

        public PerfilController(IUnitOfWork unitOfWork, IServicePerfil servicePerfil) : base(unitOfWork)
        {
            _servicePerfil = servicePerfil;
        }
        
        [Route("Adicionar")]
        [HttpPost]
        public async Task<HttpResponseMessage> Adicionar(PerfilIncluirRequest request)
        {
            try
            {
                var response = _servicePerfil.Adicionar(request);
                return await ResponseAsync(response, _servicePerfil);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        [Route("Alterar")]
        [HttpPut]
        public async Task<HttpResponseMessage> Alterar(PerfilAlterarRequest request)
        {
            try
            {
                var response = _servicePerfil.Alterar(request);
                return await ResponseAsync(response, _servicePerfil);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        [Route("Excluir")]
        [HttpDelete]
        public async Task<HttpResponseMessage> Excluir(Guid id)
        {
            try
            {
                var response = _servicePerfil.Excluir(id);
                return await ResponseAsync(response, _servicePerfil);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        [Route("Listar")]
        [HttpGet]
        public async Task<HttpResponseMessage> Listar()
        {
            try
            {
                var response = _servicePerfil.Listar();
                return await ResponseAsync(response, _servicePerfil);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        [Route("Listar")]
        [HttpPost]
        public async Task<HttpResponseMessage> ListarFiltrado(string descricao)
        {
            try
            {
                var response = _servicePerfil.ListarFiltrado(descricao);
                return await ResponseAsync(response, _servicePerfil);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }
    }
}