using StoreDapper.Domain.StoreContext.Entities;
using StoreDapper.Domain.StoreContext.Queries;
using StoreDapper.Domain.StoreContext.Repositories;

namespace StoreDapper.Tests.Fakes
{
    public class FakeCustomerRepository : ICustomerRepository
    {
        public bool CheckDocument(string document)
        {
            return false;
        }

        public bool CheckEmail(string email)
        {
            return false;
        }

        public CustomerOrdersCountResult GetCustomerOrdersCountResult(string document)
        {
            throw new System.NotImplementedException();
        }

        public void Save(Customer customer)
        {
            
        }
    }
}