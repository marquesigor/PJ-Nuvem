using PJNuvem.Api.Controllers.Base;
using PJNuvem.Domain.Arguments.Processos;
using PJNuvem.Domain.Arguments.Varas;
using PJNuvem.Domain.Interfaces.Services;
using PJNuvem.Infra.Transactions;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace PJNuvem.Api.Controller
{
    [Authorize]
    [RoutePrefix("api/v1/Processo")]
    public class ProcessoController : ControllerBase
    {
        private readonly IServiceProcesso _serviceProcesso;
        private readonly IServiceVara _serviceVara;
        private readonly IServiceVaraCompetencia _serviceVaraCompetencia;

        public ProcessoController(IUnitOfWork unitOfWork, IServiceProcesso serviceProcesso, IServiceVara serviceVara, IServiceVaraCompetencia serviceVaraCompetencia) : base(unitOfWork)
        {
            _serviceVaraCompetencia = serviceVaraCompetencia;
            _serviceProcesso = serviceProcesso;
            _serviceVara = serviceVara;
        }

        [Route("Adicionar")]
        [HttpPost]
        public async Task<HttpResponseMessage> Adicionar(ProcessoIncluirRequest request)
        {
            try
            {
                var resultado = _serviceVara.RetornaVarasQueAtendamAsCompetencias(request.ClasseProcessualId, request.ComarcaId);
                var varaId = RetornaSequencialDaVaraComAMenorQuantidadeDeProcessos(resultado.AsQueryable(), request.ClasseProcessualId);
                _serviceProcesso.PreencheVaraId(varaId);
                var response = _serviceProcesso.Adicionar(request);
                _serviceVaraCompetencia.AtualizaQuantidadeDeProcessos(varaId);
                return await ResponseAsync(response, _serviceProcesso);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        private Guid RetornaSequencialDaVaraComAMenorQuantidadeDeProcessos(IQueryable<RetornaVarasQueTenhamAsCompetenciasDaClasseProcessual> varas, Guid classeProcessualId)
        {
            return varas.OrderBy(item => item.QuantidadeProcessos).Where(item => item.ClasseProcessualId == classeProcessualId) .Select(item => item.Id).FirstOrDefault();
        }

        [Route("Listar")]
        [HttpGet]
        public async Task<HttpResponseMessage> Listar()
        {
            try
            {
                var response = _serviceProcesso.Listar();
                return await ResponseAsync(response, _serviceProcesso);
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
                var response = _serviceProcesso.ListarFiltrado(filtro);
                return await ResponseAsync(response, _serviceProcesso);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }
    }
}