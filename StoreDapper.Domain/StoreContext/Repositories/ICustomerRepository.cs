using StoreDapper.Domain.StoreContext.Entities;

namespace StoreDapper.Domain.StoreContext.Repositories
{
    public interface ICustomerRepository
    {
         bool CheckDocument(string document);
         bool CheckEmail(string email);
         void Save(Customer customer);
    }
}