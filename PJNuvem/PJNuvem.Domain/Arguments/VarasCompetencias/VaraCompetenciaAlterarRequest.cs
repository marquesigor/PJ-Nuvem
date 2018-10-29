using PJNuvem.Domain.Interfaces.Arguments;
using System;

namespace PJNuvem.Domain.Arguments.VarasCompetencias
{
    public class VaraCompetenciaAlterarRequest : IRequest
    {
        public Guid Id { get; set; }
        public Guid VaraId { get; set; }
        public Guid CompetenciaId { get; set; }
    }
}
