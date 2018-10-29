using PJNuvem.Domain.Interfaces.Arguments;
using PJNuvem.Domain.Model;
using System;

namespace PJNuvem.Domain.Arguments.ClassesProcessuaisCompetencias
{
    public class ClasseProcessualCompetenciaResponse : IResponse
    {
        public Guid Id { get; set; }
        public Guid ClasseProcessualId { get; set; }
        public virtual ClasseProcessual ClasseProcessual { get; set; }
        public Guid CompetenciaId { get; set; }
        public virtual Competencia Competencia { get; set; }

        public static explicit operator ClasseProcessualCompetenciaResponse(Model.ClasseProcessualCompetencia model)
        {
            return new ClasseProcessualCompetenciaResponse()
            {
                Id = model.Id,
                ClasseProcessualId = model.ClasseProcessualId,
                ClasseProcessual = model.ClasseProcessual,
                CompetenciaId = model.CompetenciaId,
                Competencia = model.Competencia
            };
        }
    }
}
