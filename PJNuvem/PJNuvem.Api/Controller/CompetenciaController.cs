using PJNuvem.Api.Controllers.Base;
using PJNuvem.Domain.Arguments.Competencias;
using PJNuvem.Domain.Interfaces.Services;
using PJNuvem.Infra.Transactions;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace PJNuvem.Api.Controller
{
    [Authorize]
    [RoutePrefix("api/v1/competencia")]
    public class CompetenciaController : ControllerBase
    {
        private readonly IServiceCompetencia _serviceCompetencia;

        public CompetenciaController(IUnitOfWork unitOfWork, IServiceCompetencia serviceCompetencia) : base(unitOfWork)
        {
            _serviceCompetencia = serviceCompetencia;
        }

        [Route("Adicionar")]
        [HttpPost]
        public async Task<HttpResponseMessage> Adicionar(CompetenciaIncluirRequest request)
        {
            try
            {
                var response = _serviceCompetencia.Adicionar(request);
                return await ResponseAsync(response, _serviceCompetencia);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        [Route("Alterar")]
        [HttpPut]
        public async Task<HttpResponseMessage> Alterar(CompetenciaAlterarRequest request)
        {
            try
            {
                var response = _serviceCompetencia.Alterar(request);
                return await ResponseAsync(response, _serviceCompetencia);
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
                var response = _serviceCompetencia.Excluir(id);
                return await ResponseAsync(response, _serviceCompetencia);
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
                var response = _serviceCompetencia.Listar();
                return await ResponseAsync(response, _serviceCompetencia);
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
                var response = _serviceCompetencia.ListarFiltrado(descricao);
                return await ResponseAsync(response, _serviceCompetencia);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }
    }
}