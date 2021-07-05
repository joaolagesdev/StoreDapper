using Microsoft.VisualStudio.TestTools.UnitTesting;
using StoreDapper.Domain.StoreContext.Commands.CustomerCommands.Inputs;

namespace StoreDapper.Tests.Commands
{
    [TestClass]
    public class CreateCustomerCommandTests
    {
        [TestMethod]
        public void ShouldValidateWhenCommandIsValid()
        {
            var command = new CreateCustomerCommand();
            command.FirstName = "João";
            command.LastName = "Lages";
            command.Document = "73733365070";
            command.Email = "joao.lages@gmail.com";
            command.Phone = "31987765645";

            Assert.AreEqual(true, command.IsValid());
        }
    }
}