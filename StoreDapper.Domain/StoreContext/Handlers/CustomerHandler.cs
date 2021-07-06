using System;
using Flunt.Notifications;
using StoreDapper.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using StoreDapper.Domain.StoreContext.Commands.CustomerCommands.Outputs;
using StoreDapper.Domain.StoreContext.Entities;
using StoreDapper.Domain.StoreContext.Repositories;
using StoreDapper.Domain.StoreContext.Services;
using StoreDapper.Domain.StoreContext.ValueObjects;
using StoreDapper.Shared.Commands;

namespace StoreDapper.Domain.StoreContext.Handlers
{
    public class CustomerHandler :
        Notifiable,
        ICommandHandler<CreateCustomerCommand>,
        ICommandHandler<AddAddressCommand>
    {
        private readonly ICustomerRepository _repository;
        private readonly IEmailService _emailService;

        // Dependências
        public CustomerHandler(ICustomerRepository repository, IEmailService emailService)
        {
            _repository = repository;
            _emailService = emailService;
        }

        public ICommandResult Handle(CreateCustomerCommand command)
        {
            // Verifica se o CPF existe na base
            if (_repository.CheckDocument(command.Document))
                AddNotification("Document", "Este CPF já está em uso");

            // Verifica se o E-mail existe na base
            if (_repository.CheckEmail(command.Email))
                AddNotification("Email", "Este E-mail já está em uso");

            // Cria os VOs
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);

            // Cria a entidade
            var customer = new Customer(name, document, email, command.Phone);

            // Valida entidades e VOs
            AddNotifications(name.Notifications);
            AddNotifications(document.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(customer.Notifications);

            if (Invalid)
                return null;
            
            // Persisti o cliente
            _repository.Save(customer);

            // Envia um E-mail de boas vindas
            _emailService.Send(email.Address, "joao.lages@dev.com", $"Bem-vindo{name.ToString()}", "Mensagem");

            // Retorna o resultado para tela
            return new CreateCustomerCommandResult(customer.Id, name.ToString(), email.Address);
        }

        public ICommandResult Handle(AddAddressCommand Command)
        {
            throw new System.NotImplementedException();
        }
    }
}