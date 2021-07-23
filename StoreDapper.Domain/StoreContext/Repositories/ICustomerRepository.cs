using StoreDapper.Domain.StoreContext.Entities;
using StoreDapper.Domain.StoreContext.Queries;

namespace StoreDapper.Domain.StoreContext.Repositories
{
    public interface ICustomerRepository
    {
         bool CheckDocument(string document);
         bool CheckEmail(string email);
         void Save(Customer customer);
         CustomerOrdersCountResult GetCustomerOrdersCountResult(string document);
    }
}