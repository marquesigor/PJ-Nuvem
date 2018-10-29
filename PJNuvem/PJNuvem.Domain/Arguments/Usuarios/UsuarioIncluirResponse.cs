using PJNuvem.Domain.Interfaces.Arguments;
using PJNuvem.Domain.Resources;
using System;

namespace PJNuvem.Domain.Arguments.Usuarios
{
    public class UsuarioIncluirResponse : IResponse
    {
        public Guid Id { get; set; }

        public string Message { get; set; }

        public static explicit operator UsuarioIncluirResponse(Guid id)
        {
            return new UsuarioIncluirResponse()
            {
                Id = id,
                Message = Messages_PT_BR.OPERACAO_REALIZADA_COM_SUCESSO
            };
        }
    }
}
