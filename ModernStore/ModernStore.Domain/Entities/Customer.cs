using FluentValidator;
using MordenStore.Share.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModernStore.Domain.ValueObjects;

namespace ModernStore.Domain.Entities
{
    public class Customer : Entity
    {
        protected Customer() { }
        public Customer(
            Name name,
            Email email,
            Document document,
            User user)
        {
            Name = name;
            this.Email = email;
            this.Document = document;
            this.User = user;

            AddNotifications(name.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(Document.Notifications);
        }

        public Name Name { get; private set; }
        public DateTime BirthDate { get; private set; }
        public Email Email { get; private set; }
        public User User { get; private set; }
        public Document Document { get; private set; }

        public void Update(Name name, DateTime birthDate)
        {
            Name = name;
            BirthDate = birthDate;
        }
    }
}
