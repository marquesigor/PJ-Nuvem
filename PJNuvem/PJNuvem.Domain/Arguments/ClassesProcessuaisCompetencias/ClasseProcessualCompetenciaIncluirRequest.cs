using PJNuvem.Domain.Interfaces.Arguments;
using System;

namespace PJNuvem.Domain.Arguments.ClassesProcessuaisCompetencias
{
    public class ClasseProcessualCompetenciaIncluirRequest : IRequest
    {
        public Guid ClasseProcessualId { get; set; }
        public Guid CompetenciaId { get; set; }
    }
}
