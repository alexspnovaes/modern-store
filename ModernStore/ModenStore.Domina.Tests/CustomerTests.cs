using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModernStore.Domain.Entities;
using ModernStore.Domain.ValueObjects;

namespace ModenStore.Domina.Tests
{
    [TestClass]
    public class CustomerTests
    {
        private readonly User user = new User("alexandre","123mudar", "123mudar");
        [TestMethod]
        [TestCategory("Customer  - New Customer")]
        public void GivenAnInvalidaNameShouldReturnANotification()
        {
            var user = new User("alexandre", "123mudar","123mudar");
            var name = new Name("", "Spreafico");
            var email = new Email("alexandresp_novaes@hotmail.com");
            var doc = new Document("35718362866");
            var customer = new Customer(name,email,doc,user);
            Assert.IsFalse(customer.IsValid());
        }
        [TestMethod]
        [TestCategory("Customer  - New Customer")]
        public void GivenAnInvalidaLastnameShouldReturnANotification()
        {

        }
        [TestMethod]
        [TestCategory("Customer  - New Customer")]
        public void GivenAnInvalidaEamilShouldReturnANotification()
        {
            var user = new User("alexandre", "alexandre", "123mudar");
            var name = new Name("", "Spreafico");
            var email = new Email("alexandresp");
            var doc = new Document("35718362866");
            var customer = new Customer(name, email, doc, user);
            Assert.IsFalse(customer.IsValid());
        }
    }
}
