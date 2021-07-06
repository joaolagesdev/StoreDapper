using System.Collections.Generic;
using System.Linq;
using StoreDapper.Domain.StoreContext.ValueObjects;
using StoreDapper.Shared.Entities;

namespace StoreDapper.Domain.StoreContext.Entities
{
    public class Customer : Entity
    {
        private readonly IList<Address> _addresses; // private => _
        public Customer(
            Name name,
            Document document,
            Email email,
            string phone )
        {
            Name = name;
            Document = document;
            Email = email;
            Phone = phone;
            _addresses = new List<Address>();
        }

        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public string Phone { get; private set; }
        public IReadOnlyCollection<Address> Addresses => _addresses.ToArray();

        public void AddAddress(Address address)
        {
            _addresses.Add(address);
        }

        public override string ToString()
        {
            return Name.ToString();
        }
    }
}