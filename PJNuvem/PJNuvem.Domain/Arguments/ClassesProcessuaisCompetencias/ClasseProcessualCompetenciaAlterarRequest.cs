using PJNuvem.Domain.Interfaces.Arguments;
using System;

namespace PJNuvem.Domain.Arguments.ClassesProcessuaisCompetencias
{
    public class ClasseProcessualCompetenciaAlterarRequest : IRequest
    {
        public Guid Id { get; set; }
        public Guid ClasseProcessualId { get; set; }
        public Guid CompetenciaId { get; set; }
    }
}
