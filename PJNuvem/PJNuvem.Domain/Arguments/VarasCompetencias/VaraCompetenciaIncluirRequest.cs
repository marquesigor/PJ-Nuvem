using PJNuvem.Domain.Interfaces.Arguments;
using System;

namespace PJNuvem.Domain.Arguments.VarasCompetencias
{
    public class VaraCompetenciaIncluirRequest : IRequest
    {
        public Guid VaraId { get; set; }
        public Guid CompetenciaId { get; set; }
    }
}
