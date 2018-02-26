using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidator;
using MordenStore.Share.Entities;

namespace ModernStore.Domain.Entities
{
    public class User : Entity
    {
        protected User(){}
        public User(string username, string password, string confirmPassword)
        {
            Username = username;
            Password = password;
            Active = true;

            new ValidationContract<User>(this)
                .AreEquals(x => x.Password, confirmPassword, "As senhas não coincidem");
        }
        
        public String Username { get; private set; }
        public String Password { get; private set; }
        public bool Active { get; private set; }


        public void Activate() => Active = true;
        public void Desactivate() => Active = false;
    }

   
}
