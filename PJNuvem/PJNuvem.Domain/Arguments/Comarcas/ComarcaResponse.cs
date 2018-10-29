using PJNuvem.Domain.Interfaces.Arguments;
using System;

namespace PJNuvem.Domain.Arguments.Comarcas
{
    public class ComarcaResponse : IResponse
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }

        public static explicit operator ComarcaResponse(Model.Comarca model)
        {
            return new ComarcaResponse()
            {
                Id = model.Id,
                Descricao = model.Descricao
            };
        }
    }
}