using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidator;

namespace ModernStore.Domain.ValueObjects
{
    public class Name : Notifiable
    {
        protected Name() { }
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            new ValidationContract<Name>(this)
                .IsRequired(x => x.FirstName, "Nome obrigatório")
                .HasMaxLenght(x => x.FirstName, 60, "Nome deve ter até 60 caracteres")
                .HasMinLenght(x => x.FirstName, 3, "Nome deve ter no mínimo 3 caracteres")
                .IsRequired(x => x.LastName, "Nome obrigatório")
                .HasMaxLenght(x => x.LastName, 60, "Nome deve ter até 60 caracteres")
                .HasMinLenght(x => x.LastName, 3, "Nome deve ter no mínimo 3 caracteres");
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
