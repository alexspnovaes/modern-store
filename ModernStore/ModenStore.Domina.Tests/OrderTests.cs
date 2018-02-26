using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModernStore.Domain.Entities;
using ModernStore.Domain.ValueObjects;

namespace ModenStore.Domina.Tests
{
    [TestClass]
    public class OrderTests
    {
        [TestMethod]
        [TestCategory("Order - New Order")]
        public void GivenAnOutOfStockProductItShouldReturnAnError()
        {
            var user = new User("alexandre", "123mudar", "123mudar");
            var name = new Name("Alexandre", "Spreafico");
            var email = new Email("alexandresp_novaes@hotmail.com");
            var doc = new Document("35718362866");
            var customer = new Customer(name, email,doc, user);
            var mouse = new Product("Mouse",299,"mouse.jpg",0);

            var order = new Order(customer,8,10);
            order.AddItem(new OrderItem(mouse,2));

            Assert.IsFalse(order.IsValid());
        }

        [TestMethod]
        [TestCategory("Order - New Order")]
        public void GiveInStockProductItShouldUpdateQuantityOnHand()
        {
            var user = new User("alexandre", "123mudar", "123mudar");
            var name = new Name("Alexandre", "Spreafico");
            var email = new Email("alexandresp_novaes@hotmail.com");
            var doc = new Document("35718362866");
            var customer = new Customer(name, email, doc, user);
            var mouse = new Product("Mouse", 299, "mouse.jpg", 20);

            var order = new Order(customer, 8, 10);
            order.AddItem(new OrderItem(mouse, 2));

            Assert.IsTrue(mouse.QuantityOnHand == 18);
        }
    }
}
