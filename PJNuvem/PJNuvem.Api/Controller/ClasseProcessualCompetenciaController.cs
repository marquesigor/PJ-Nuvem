using PJNuvem.Api.Controllers.Base;
using PJNuvem.Domain.Arguments.ClassesProcessuaisCompetencias;
using PJNuvem.Domain.Interfaces.Services;
using PJNuvem.Infra.Transactions;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace PJNuvem.Api.Controller
{
    [Authorize]
    [RoutePrefix("api/v1/classeProcessualCompetencia")]
    public class ClasseProcessualCompetenciaController : ControllerBase
    {
        private readonly IServiceClasseProcessualCompetencia _serviceClasseProcessualCompetencia;

        public ClasseProcessualCompetenciaController(IUnitOfWork unitOfWork, IServiceClasseProcessualCompetencia serviceClasseProcessualCompetencia) : base(unitOfWork)
        {
            _serviceClasseProcessualCompetencia = serviceClasseProcessualCompetencia;
        }

        [Route("Adicionar")]
        [HttpPost]
        public async Task<HttpResponseMessage> Adicionar(ClasseProcessualCompetenciaIncluirRequest request)
        {
            try
            {
                var response = _serviceClasseProcessualCompetencia.Adicionar(request);
                return await ResponseAsync(response, _serviceClasseProcessualCompetencia);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        [Route("Alterar")]
        [HttpPut]
        public async Task<HttpResponseMessage> Alterar(ClasseProcessualCompetenciaAlterarRequest request)
        {
            try
            {
                var response = _serviceClasseProcessualCompetencia.Alterar(request);
                return await ResponseAsync(response, _serviceClasseProcessualCompetencia);
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
                var response = _serviceClasseProcessualCompetencia.Excluir(id);
                return await ResponseAsync(response, _serviceClasseProcessualCompetencia);
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
                var response = _serviceClasseProcessualCompetencia.Listar();
                return await ResponseAsync(response, _serviceClasseProcessualCompetencia);
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
                var response = _serviceClasseProcessualCompetencia.ListarFiltrado(filtro);
                return await ResponseAsync(response, _serviceClasseProcessualCompetencia);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }
    }
}