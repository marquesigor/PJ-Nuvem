using PJNuvem.Domain.Interfaces.Arguments;

namespace PJNuvem.Domain.Arguments.ClassesProcessuais
{
    public class ClasseProcessualIncluirRequest : IRequest
    {
        public string Descricao { get; set; }
    }
}
