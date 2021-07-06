using System;
using Flunt.Notifications;
using StoreDapper.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using StoreDapper.Domain.StoreContext.Commands.CustomerCommands.Outputs;
using StoreDapper.Domain.StoreContext.Entities;
using StoreDapper.Domain.StoreContext.ValueObjects;
using StoreDapper.Shared.Commands;

namespace StoreDapper.Domain.StoreContext.Handlers
{
    public class CustomerHandler :
        Notifiable,
        ICommandHandler<CreateCustomerCommand>,
        ICommandHandler<AddAddressCommand>
    {
        public ICommandResult Handle(CreateCustomerCommand command)
        {
            // Verifica se o CPF existe na base

            // Verifica se o E-mail existe na base

            // Cria os VOs
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);

            // Cria a entidade
            var customer = new Customer(name, document, email, command.Phone);

            // Validar entidades e VOs
            AddNotifications(name.Notifications);
            AddNotifications(document.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(customer.Notifications);

            // Persisti o cliente

            // Envia um E-mail de boas vindas

            // Retorna o resultado para tela

            return new CreateCustomerCommandResult(Guid.NewGuid(), name.ToString(), email.Address);
        }

        public ICommandResult Handle(AddAddressCommand Command)
        {
            throw new System.NotImplementedException();
        }
    }
}