using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ModernStore.Domain.Commands;
using ModernStore.Domain.Commands.Handlers;
using ModernStore.Domain.Commands.Inputs;
using ModernStore.Domain.Entities;
using ModernStore.Domain.Repositories;
using ModernStore.Domain.ValueObjects;

namespace MordenStore
{
    class Program
    {
        static void Main(string[] args)
        {
            var command = new RegisterOrderCommand
            {

                Customer = Guid.NewGuid(),
                DeliveryFee = 9,
                Discount = 30,
                Items = new List<RegisterOrderItemCommand>
                {
                    new RegisterOrderItemCommand
                    {
                        Product = Guid.NewGuid(),
                        Quantity = 3
                    }
                }
            };
            GenerateOrder(
                new FakeCustomerRepository(),
                new FakeProductRepository(),
                new FakeOrderRepository(),
                command
            );
        }

        private static void GenerateOrder(
            ICustomerRepository customerRepository,
            IProductRepository productRepository,
            IOrderRepository orderRepository,
            RegisterOrderCommand command)
        {
            var handler = new OrderCommandHandler(customerRepository, productRepository, orderRepository);
            handler.Handle(command);
        }

        public class FakeOrderRepository : IOrderRepository
        {
            public void Save(Order order)
            {

            }
        }

        private class FakeProductRepository : IProductRepository
        {
            public Product Get(Guid id)
            {
                return new Product("Mouse", 299, "mouse.jpg", 20);
            }
        }

        private class FakeCustomerRepository : ICustomerRepository
        {
            public Customer Get(Guid id)
            {
                return null;
            }

            public Customer Get(string documment)
            {
                throw new NotImplementedException();
            }

            public Customer GetByUserId(Guid id)
            {
                return new Customer(
                    new Name("Alexandre", "Spreafico"),
                    new Email("alexandresp_novaes@hotmail.com"),
                    new Document("35718362866"),
                    new User("alexandre", "123mudar", "123mudar")
                    );
            }

            public bool DocumentExists(string document)
            {
                throw new NotImplementedException();
            }

            public void Save(Customer customer)
            {
                throw new NotImplementedException();
            }
        }
    }
}
