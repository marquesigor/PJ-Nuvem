using PJNuvem.Domain.Resources;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;

namespace PJNuvem.Domain.ValueObjects
{
    public class Nome : Notifiable
    {
        protected Nome() { }
        public Nome(string primeiroNome, string ultimoNome)
        {
            PrimeiroNome = primeiroNome;
            UltimoNome = ultimoNome;

            new AddNotifications<Nome>(this)
                .IfNullOrInvalidLength(item => item.PrimeiroNome, 1, 50, Messages_PT_BR.X0_OBRIGATORIO_E_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERES.ToFormat("Primeiro nome", "1", "50"))
                .IfNullOrInvalidLength(item => item.UltimoNome, 1, 100, Messages_PT_BR.X0_OBRIGATORIO_E_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERES.ToFormat("Último nome", "1", "100"));
        }

        public string PrimeiroNome { get; private set; }

        public string UltimoNome { get; private set; }
    }
}
