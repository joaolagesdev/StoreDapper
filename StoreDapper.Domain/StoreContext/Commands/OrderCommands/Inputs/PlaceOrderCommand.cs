using System;
using System.Collections.Generic;
using Flunt.Notifications;
using Flunt.Validations;
using StoreDapper.Shared.Commands;

namespace StoreDapper.Domain.StoreContext.Commands.OrderCommands.Inputs
{
    public class PlaceOrderCommand : Notifiable, ICommand
    {
        public PlaceOrderCommand()
        {
            OrderItems = new List<OrderItemCommand>();
        }
        public Guid Customer {get; set;}
        public IList<OrderItemCommand> OrderItems {get; set;}
         public bool IsValid()
        {
            AddNotifications(new Contract()
                .HasLen(Customer.ToString(), 36, "Customer", "Identificador do Cliente inválido")
                .IsGreaterThan(OrderItems.Count, 0, "Items", "Nenhum item do pedido foi encontrado")
            );
            return IsValid();
        }
    }

    public class OrderItemCommand
    {
        public Guid Product {get; set;}
        public decimal Quantity {get; set;}
    }
}