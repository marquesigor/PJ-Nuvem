using PJNuvem.Domain.Interfaces.Arguments;
using System;

namespace PJNuvem.Domain.Arguments.Competencias
{
    public class CompetenciaAlterarRequest : IRequest
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
    }
}
