using PJNuvem.Domain.Interfaces.Arguments;
using System;

namespace PJNuvem.Domain.Arguments.Base
{
    public class ResponseBase : IResponse
    {
        public Guid? Id { get; set; }
        public string Mensagem { get; set; }

        public static explicit operator ResponseBase(Guid id)
        {
            return new ResponseBase()
            {
                Id = id,
                Mensagem = Resources.Messages_PT_BR.OPERACAO_REALIZADA_COM_SUCESSO
            };
        }
    }
}
