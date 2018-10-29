using prmToolkit.NotificationPattern;
using System;

namespace PJNuvem.Domain.Model.Base
{
    public class ModelBase : Notifiable
    {
        protected ModelBase()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
    }
}
