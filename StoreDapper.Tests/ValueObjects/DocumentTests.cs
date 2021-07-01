using Microsoft.VisualStudio.TestTools.UnitTesting;
using StoreDapper.Domain.StoreContext.ValueObjects;

namespace StoreDapper.Tests.ValueObjects
{
    [TestClass]
    public class DocumentTests
    {
        private Document validDocument;
        private Document invalidDocument;
        public DocumentTests()
        {
            validDocument = new Document("72490832018");
            invalidDocument = new Document("12345678910");
        }

        [TestMethod]
        public void ShouldReturnNotificationWhenDocumentIsNotValid()
        {
            Assert.AreEqual(false, invalidDocument.Valid);
            // Or
            Assert.AreEqual(1, invalidDocument.Notifications.Count);
        }

        [TestMethod]
        public void ShouldReturnNotNotificationWhenDocumentIsValid()
        {
            Assert.AreEqual(true, validDocument.Valid);
            Assert.AreEqual(0, validDocument.Notifications.Count);
        }
    }
}

// O flunt já valida o e-mail e o name, não é necessário testar