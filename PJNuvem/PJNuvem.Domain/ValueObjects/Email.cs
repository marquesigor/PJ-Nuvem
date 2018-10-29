using PJNuvem.Domain.Resources;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;

namespace PJNuvem.Domain.ValueObjects
{
    public class Email : Notifiable
    {
        protected Email() { }
        public Email(string endereco)
        {
            Endereco = endereco;

            new AddNotifications<Email>(this).IfNotEmail(item => item.Endereco, Messages_PT_BR.X0_INVALIDO.ToFormat("E-mail"));
            new AddNotifications<Email>(this).IfNullOrInvalidLength(item => item.Endereco,1,200, Messages_PT_BR.X0_OBRIGATORIO_E_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERES.ToFormat("E-mail", "1", "200"));
        }

        public string Endereco { get; private set; }
    }
}
