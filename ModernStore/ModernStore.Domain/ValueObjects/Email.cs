using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidator;

namespace ModernStore.Domain.ValueObjects
{
    public class Email : Notifiable
    {
        protected Email() { }
        public Email(string adress)
        {
            Adress = adress;

            new ValidationContract<Email>(this)
                .IsRequired(x => x.Adress, "E-mail obrigatório")
                .IsEmail(x => x.Adress, "E-mail inválido")
                .HasMinLenght(x => x.Adress, 3, "E-mail deve ter no mínimo 3 caracteres");
        }

        public string Adress { get; private set; }
    }
}
