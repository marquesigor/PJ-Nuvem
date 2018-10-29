using PJNuvem.Domain.Model.Base;
using PJNuvem.Domain.Resources;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System;

namespace PJNuvem.Domain.Model
{
    public class Vara : ModelBase
    {
        public Guid ComarcaId { get; private set; }
        public virtual Comarca Comarca { get; private set; }
        public string Descricao { get; private set; }

        public void Incluir(Guid comarcaId, string descricao)
        {
            ComarcaId = comarcaId;
            Descricao = descricao;
            new AddNotifications<Vara>(this).IfNullOrInvalidLength(item => item.Descricao, 1, 200, Messages_PT_BR.X0_OBRIGATORIA_E_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERES.ToFormat("Descrição", "1", "200"));
        }

        public void Alterar(Guid id, Guid comarcaId, string descricao)
        {
            Id = id;
            ComarcaId = comarcaId;
            Descricao = descricao;

            new AddNotifications<Vara>(this).IfNullOrInvalidLength(item => item.Descricao, 1, 200, Messages_PT_BR.X0_OBRIGATORIA_E_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERES.ToFormat("Descrição", "1", "200"));
        }
    }
}
