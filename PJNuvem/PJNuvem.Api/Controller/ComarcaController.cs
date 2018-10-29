using PJNuvem.Api.Controllers.Base;
using PJNuvem.Domain.Arguments.Comarcas;
using PJNuvem.Domain.Interfaces.Services;
using PJNuvem.Infra.Transactions;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace PJNuvem.Api.Controller
{
    [Authorize]
    [RoutePrefix("api/v1/comarca")]
    public class ComarcaController :  ControllerBase
    {
        private readonly IServiceComarca _serviceComarca;

        public ComarcaController(IUnitOfWork unitOfWork, IServiceComarca serviceComarca) : base(unitOfWork)
        {
            _serviceComarca = serviceComarca;
        }

        [Route("Adicionar")]
        [HttpPost]
        public async Task<HttpResponseMessage> Adicionar(ComarcaIncluirRequest request)
        {
            try
            {
                var response = _serviceComarca.Adicionar(request);
                return await ResponseAsync(response, _serviceComarca);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        [Route("Alterar")]
        [HttpPut]
        public async Task<HttpResponseMessage> Alterar(ComarcaAlterarRequest request)
        {
            try
            {
                var response = _serviceComarca.Alterar(request);
                return await ResponseAsync(response, _serviceComarca);
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
                var response = _serviceComarca.Excluir(id);
                return await ResponseAsync(response, _serviceComarca);
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
                var response = _serviceComarca.Listar();
                return await ResponseAsync(response, _serviceComarca);
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
                var response = _serviceComarca.ListarFiltrado(descricao);
                return await ResponseAsync(response, _serviceComarca);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }
    }
}