using PJNuvem.Domain.Interfaces.Arguments;

namespace PJNuvem.Domain.Arguments.Competencias
{
    public class CompetenciaIncluirRequest : IRequest
    {
        public string Descricao { get; set; }
    }
}
