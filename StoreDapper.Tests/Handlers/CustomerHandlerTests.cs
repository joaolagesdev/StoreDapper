using Microsoft.VisualStudio.TestTools.UnitTesting;
using StoreDapper.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using StoreDapper.Domain.StoreContext.Handlers;
using StoreDapper.Tests.Fakes;

namespace StoreDapper.Tests.Handlers
{
    [TestClass]
    public class CustomerHandlerTests
    {
        [TestMethod]
        public void ShouldRegisterCustomerWhenCommandIsValid()
        {
             var command = new CreateCustomerCommand();
            command.FirstName = "João";
            command.LastName = "Lages";
            command.Document = "73733365070";
            command.Email = "joao.lages@gmail.com";
            command.Phone = "31987765645";

            Assert.AreEqual(true, command.IsValid());

            var handler = new CustomerHandler(new FakeCustomerRepository(), new FakeEmailService());
        }
    }
}