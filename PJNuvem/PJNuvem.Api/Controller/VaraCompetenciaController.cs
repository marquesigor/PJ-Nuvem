using PJNuvem.Api.Controllers.Base;
using PJNuvem.Domain.Arguments.VarasCompetencias;
using PJNuvem.Domain.Interfaces.Services;
using PJNuvem.Infra.Transactions;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;


namespace PJNuvem.Api.Controller
{
    [Authorize]
    [RoutePrefix("api/v1/varaCompetencia")]
    public class VaraCompetenciaController : ControllerBase
    {
        private readonly IServiceVaraCompetencia _serviceVaraCompetencia;

        public VaraCompetenciaController(IUnitOfWork unitOfWork, IServiceVaraCompetencia serviceVaraCompetencia) : base(unitOfWork)
        {
            _serviceVaraCompetencia = serviceVaraCompetencia;
        }

        [Route("Adicionar")]
        [HttpPost]
        public async Task<HttpResponseMessage> Adicionar(VaraCompetenciaIncluirRequest request)
        {
            try
            {
                var response = _serviceVaraCompetencia.Adicionar(request);
                return await ResponseAsync(response, _serviceVaraCompetencia);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        [Route("Alterar")]
        [HttpPut]
        public async Task<HttpResponseMessage> Alterar(VaraCompetenciaAlterarRequest request)
        {
            try
            {
                var response = _serviceVaraCompetencia.Alterar(request);
                return await ResponseAsync(response, _serviceVaraCompetencia);
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
                var response = _serviceVaraCompetencia.Excluir(id);
                return await ResponseAsync(response, _serviceVaraCompetencia);
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
                var response = _serviceVaraCompetencia.Listar();
                return await ResponseAsync(response, _serviceVaraCompetencia);
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
                var response = _serviceVaraCompetencia.ListarFiltrado(filtro);
                return await ResponseAsync(response, _serviceVaraCompetencia);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }
    }
}