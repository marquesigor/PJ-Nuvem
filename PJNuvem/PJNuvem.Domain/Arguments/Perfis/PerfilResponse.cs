using PJNuvem.Domain.Interfaces.Arguments;
using System;

namespace PJNuvem.Domain.Arguments.Perfis
{
    public class PerfilResponse : IResponse
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }

        public static explicit operator PerfilResponse(Model.Perfil model)
        {
            return new PerfilResponse()
            {
                Id = model.Id,
                Descricao = model.Descricao
            };
        }
    }
}
