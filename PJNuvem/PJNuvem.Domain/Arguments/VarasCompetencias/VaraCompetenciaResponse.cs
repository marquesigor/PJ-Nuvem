using PJNuvem.Domain.Interfaces.Arguments;
using PJNuvem.Domain.Model;
using System;

namespace PJNuvem.Domain.Arguments.VarasCompetencias
{
    public class VaraCompetenciaResponse : IResponse
    {
        public Guid Id { get; set; }
        public Guid VaraId { get; set; }
        public virtual Vara Vara { get; set; }
        public Guid CompetenciaId { get; set; }
        public virtual Competencia Competencia { get; set; }

        public static explicit operator VaraCompetenciaResponse(Model.VaraCompetencia model)
        {
            return new VaraCompetenciaResponse()
            {
                Id = model.Id,
                VaraId = model.VaraId,
                Vara = model.Vara,
                CompetenciaId = model.CompetenciaId,
                Competencia = model.Competencia
            };
        }
    }
}
