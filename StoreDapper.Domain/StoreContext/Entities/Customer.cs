using System.Collections.Generic;
using StoreDapper.Domain.StoreContext.ValueObjects;

namespace StoreDapper.Domain.StoreContext.Entities
{
    public class Customer
    {
        public Customer(
            Name name,
            Document document, 
            Email email, 
            string phone, 
            string address)
        {
            Name = name;
            Document = document;
            Email = email;
            Phone = phone;
            Addresses = new List<Address>();
        }

        public Name Name {get; private set;}
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public string Phone { get; private set; }
        public IReadOnlyCollection<Address> Addresses { get; private set; }

        public override string ToString()
        {
            return Name.ToString();
        }
    }
}