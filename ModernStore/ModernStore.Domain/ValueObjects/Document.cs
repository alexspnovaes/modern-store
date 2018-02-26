using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;using FluentValidator;

namespace ModernStore.Domain.ValueObjects
{
    public class Document : Notifiable
    {
        protected Document() { }
        public Document(string number)
        {
            Number = number;

            if (!Validate((number)))
                AddNotification("Document","CPF Inválido");
        }

        public bool Validate(string cpf)
        {
            return true;
        }

        public string Number { get; private set; }
    }
}
