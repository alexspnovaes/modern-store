using System;
using FluentValidator;
using ModernStore.Domain.CommandResults;
using ModernStore.Domain.Commands.Inputs;
using ModernStore.Domain.Commands.Results;
using ModernStore.Domain.Entities;
using ModernStore.Domain.Repositories;
using ModernStore.Domain.Resources;
using ModernStore.Domain.Services;
using ModernStore.Domain.ValueObjects;
using MordenStore.Share.Commands;

namespace ModernStore.Domain.Commands.Handlers
{
    public class CustomerCommandHandler : Notifiable,
        ICommandHandler<RegisterCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IEmailService _emailService;
        public CustomerCommandHandler(ICustomerRepository customerRepository, IEmailService emailService)
        {
            customerRepository = _customerRepository;
            emailService = _emailService;
        }

        public ICommandResult Handle(RegisterCustomerCommand command)
        {
            //verificar se o cpf já existe
            if (_customerRepository.DocumentExists(command.Documment))
            {
                AddNotification("Document", "Este CPF já está em uso");
                return null;
            }

            //gerar novo cliente
            var name = new Name(command.FirstName, command.LastName);
            var email = new Email("alexandresp_novaes@hotmail.com");
            var documment = new Document("35718362866");
            var user = new User("alexandre", "123mudar", "123mudar");
            var customer = new Customer(name, email, documment, user);

            //Adicionar notificação
            AddNotifications(name.Notifications);
            AddNotifications(documment.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(user.Notifications);
            AddNotifications(customer.Notifications);

            //inserir no banco
            if (IsValid())
                _customerRepository.Save(customer);

            //enviar e-mail de boas vindas
            _emailService.Send(
                customer.Name.ToString(),
                customer.Email.Adress,
                string.Format(EmailTemplate.WelcomeEmailTitle, customer.Name),
                string.Format(EmailTemplate.WelcomeEmailBody, customer.Name)
            );

            //retornar algo
            return new RegisterCostumerCommandResult
            {
                Id = customer.Id,
                Name = customer.Name.ToString()
            };
        }

        public ICommandResult Handle(UpdateCustomerCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
