using PJNuvem.Domain.Model.Base;
using PJNuvem.Domain.Resources;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System;

namespace PJNuvem.Domain.Model
{
    public class Perfil : ModelBase
    {
        public Perfil() { }
        public string Descricao { get; private set; }

        public void Incluir(string descricao)
        {
            Descricao = descricao;
            new AddNotifications<Perfil>(this).IfNullOrInvalidLength(item => item.Descricao, 1, 200, Messages_PT_BR.X0_OBRIGATORIA_E_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERES.ToFormat("Descrição", "1", "200"));
        }

        public void Alterar(Guid id, string descricao)
        {
            Id = id;
            Descricao = descricao;

            new AddNotifications<Perfil>(this).IfNullOrInvalidLength(item => item.Descricao, 1, 200, Messages_PT_BR.X0_OBRIGATORIA_E_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERES.ToFormat("Descrição", "1", "200"));
        }
    }
}
