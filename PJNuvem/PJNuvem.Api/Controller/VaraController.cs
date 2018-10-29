using PJNuvem.Api.Controllers.Base;
using PJNuvem.Domain.Arguments.Varas;
using PJNuvem.Domain.Interfaces.Services;
using PJNuvem.Infra.Transactions;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace PJNuvem.Api.Controller
{
    [Authorize]
    [RoutePrefix("api/v1/vara")]
    public class VaraController : ControllerBase
    {
        private readonly IServiceVara _serviceVara;

        public VaraController(IUnitOfWork unitOfWork, IServiceVara serviceVara) : base(unitOfWork)
        {
            _serviceVara = serviceVara;
        }

        [Route("Adicionar")]
        [HttpPost]
        public async Task<HttpResponseMessage> Adicionar(VaraIncluirRequest request)
        {
            try
            {
                var response = _serviceVara.Adicionar(request);
                return await ResponseAsync(response, _serviceVara);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        [Route("Alterar")]
        [HttpPut]
        public async Task<HttpResponseMessage> Alterar(VaraAlterarRequest request)
        {
            try
            {
                var response = _serviceVara.Alterar(request);
                return await ResponseAsync(response, _serviceVara);
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
                var response = _serviceVara.Excluir(id);
                return await ResponseAsync(response, _serviceVara);
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
                var response = _serviceVara.Listar();
                return await ResponseAsync(response, _serviceVara);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        [Route("Listar")]
        [HttpPost]
        public async Task<HttpResponseMessage> ListarFiltrado(string filtro)
        {
            try
            {
                var response = _serviceVara.ListarFiltrado( filtro);
                return await ResponseAsync(response, _serviceVara);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }
    }
}