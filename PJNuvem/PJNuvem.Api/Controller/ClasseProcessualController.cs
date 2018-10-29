using PJNuvem.Api.Controllers.Base;
using PJNuvem.Domain.Arguments.ClassesProcessuais;
using PJNuvem.Domain.Interfaces.Services;
using PJNuvem.Infra.Transactions;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace PJNuvem.Api.Controller
{
    [Authorize]
    [RoutePrefix("api/v1/classeProcessual")]
    public class ClasseProcessualController : ControllerBase
    {
        private readonly IServiceClasseProcessual _serviceClasseProcessual;

        public ClasseProcessualController(IUnitOfWork unitOfWork, IServiceClasseProcessual serviceClasseProcessual) : base(unitOfWork)
        {
            _serviceClasseProcessual = serviceClasseProcessual;
        }

        [Route("Adicionar")]
        [HttpPost]
        public async Task<HttpResponseMessage> Adicionar(ClasseProcessualIncluirRequest request)
        {
            try
            {
                var response = _serviceClasseProcessual.Adicionar(request);
                return await ResponseAsync(response, _serviceClasseProcessual);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        [Route("Alterar")]
        [HttpPut]
        public async Task<HttpResponseMessage> Alterar(ClasseProcessualAlterarRequest request)
        {
            try
            {
                var response = _serviceClasseProcessual.Alterar(request);
                return await ResponseAsync(response, _serviceClasseProcessual);
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
                var response = _serviceClasseProcessual.Excluir(id);
                return await ResponseAsync(response, _serviceClasseProcessual);
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
                var response = _serviceClasseProcessual.Listar();
                return await ResponseAsync(response, _serviceClasseProcessual);
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
                var response = _serviceClasseProcessual.ListarFiltrado(descricao);
                return await ResponseAsync(response, _serviceClasseProcessual);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }
    }
}