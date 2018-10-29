using System;

namespace PJNuvem.Domain.Arguments.Varas
{
    public class RetornaVarasQueTenhamAsCompetenciasDaClasseProcessual
    {
        public Guid Id { get; set; }
        public Guid ClasseProcessualId { get; set; }
        public int QuantidadeProcessos { get; set; }
    }
}
