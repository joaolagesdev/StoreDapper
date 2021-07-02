using Flunt.Validations;
using Flunt.Notifications;

namespace StoreDapper.Domain.StoreContext.ValueObjects
{
    public class Email : Notifiable
    {
        public Email(string address)
        {
            Address = address;

            AddNotifications(new Contract()
                .Requires()
                .IsEmail(Address, "Email", "O E-mail é inválido")   
            );
        }
        public string Address { get; private set; }
        
        public override string ToString()
        {
            return Address;
        }
    }
}