using FluentValidator;
using ModernStore.Domain.CommandResults;
using ModernStore.Domain.Commands.Inputs;
using ModernStore.Domain.Commands.Results;
using ModernStore.Domain.Entities;
using ModernStore.Domain.Repositories;
using MordenStore.Share.Commands;

namespace ModernStore.Domain.Commands.Handlers
{
    public class OrderCommandHandler : Notifiable,
        ICommandHandler<RegisterOrderCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;

        public OrderCommandHandler(
            ICustomerRepository customerRepository, 
            IProductRepository productRepository,
            IOrderRepository orderRepository)
        {
            _customerRepository = customerRepository;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }

        public ICommandResult Handle(RegisterOrderCommand command)
        {
            var customer = _customerRepository.Get(command.Customer);
            var order = new Order(customer, command.DeliveryFee, command.Discount);
            foreach (var item in command.Items)
            {
                var product = _productRepository.Get(item.Product);
                order.AddItem(new OrderItem(product, item.Quantity));
            }

            //Adiciona as notificações do pedido no handler
            AddNotifications(order.Notifications);

            //Persiste no banco
            if (IsValid())
                _orderRepository.Save(order);
            return new RegisterOrderCommandResult(order.Number);
        }
    }
}
