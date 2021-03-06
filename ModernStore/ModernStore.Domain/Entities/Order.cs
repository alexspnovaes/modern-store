﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidator;
using ModernStore.Domain.Enums;
using MordenStore.Share.Entities;

namespace ModernStore.Domain.Entities
{
    public class Order : Entity
    {
        private readonly IList<OrderItem> _items;
        protected Order() { }
        public Order(Customer customer, decimal deliveryFee, decimal discount)
        {
            Customer = customer;
            CreateDate = DateTime.Now;
            Number = Guid.NewGuid().ToString().Substring(0, 8);
            Status = EOrderStatus.Created;
            DeliveryFee = deliveryFee;
            Discount = discount;
            _items = new List<OrderItem>();

            new ValidationContract<Order>(this)
                .IsGreaterThan(x => x.DeliveryFee, 0)
                .IsGreaterThan(x => x.DeliveryFee, -1);
        }

        public Customer Customer { get; private set; }
        public DateTime CreateDate { get; private set; }
        public string Number { get; private set; }
        public EOrderStatus Status { get; private set; }
        public ICollection<OrderItem> Items => _items.ToArray();
        public Decimal DeliveryFee { get; private set; }
        public decimal Discount { get; private set; }

        public decimal SubTotal() => Items.Sum(x => x.Total());
        public decimal Total() => SubTotal() + DeliveryFee - Discount;

        public void AddItem(OrderItem item)
        {
            AddNotifications(item.Notifications);
            if (item.IsValid())
            {
                _items.Add(item);
            }
        }

        public void Place()
        {

        }

    }
}

