using PJNuvem.Domain.Interfaces.Arguments;
using PJNuvem.Domain.Model;
using System;

namespace PJNuvem.Domain.Arguments.Varas
{
    public class VaraResponse : IResponse
    {
        public Guid Id { get; set; }
        public Guid ComarcaId { get; set; }
        public virtual Comarca Comarca { get; set; }
        public string Descricao { get; set; }

        public static explicit operator VaraResponse(Model.Vara model)
        {
            return new VaraResponse()
            {
                Id = model.Id,
                Descricao = model.Descricao,
                ComarcaId = model.ComarcaId,
                Comarca = model.Comarca
            };
        }
    }
}
