﻿using PJNuvem.Domain.Model;
using System.Data.Entity.ModelConfiguration;

namespace PJNuvem.Infra.Data.Map
{
    public class CompetenciaMap : EntityTypeConfiguration<Competencia>
    {
        public CompetenciaMap()
        {
            ToTable("Competencia");
            Property(item => item.Descricao).IsRequired().HasMaxLength(200);
        }
    }
}
