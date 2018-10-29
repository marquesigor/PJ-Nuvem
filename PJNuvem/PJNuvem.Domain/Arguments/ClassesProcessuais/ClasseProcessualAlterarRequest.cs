using PJNuvem.Domain.Interfaces.Arguments;
using System;

namespace PJNuvem.Domain.Arguments.ClassesProcessuais
{
    public class ClasseProcessualAlterarRequest : IRequest
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
    }
}
