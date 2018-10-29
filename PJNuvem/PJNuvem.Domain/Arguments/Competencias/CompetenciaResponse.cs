using PJNuvem.Domain.Interfaces.Arguments;
using System;

namespace PJNuvem.Domain.Arguments.Competencias
{
    public class CompetenciaResponse : IResponse
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }

        public static explicit operator CompetenciaResponse(Model.Competencia model)
        {
            return new CompetenciaResponse()
            {
                Id = model.Id,
                Descricao = model.Descricao
            };
        }
    }
}