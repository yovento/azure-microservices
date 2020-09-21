using Lil.Sales.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lil.Sales.DAL
{
    public class SalesProvider : ISalesProvider
    {
        private readonly List<Order> repo = new List<Order>();
        public SalesProvider()
        {
            repo.Add(new Order()
            {
                Id = "0001",
                CustomerId = "1",
                OrderDate = DateTime.Now.AddMonths(-1),
                Total = 100,
                Items = new List<OrderItem>() { 
                    new OrderItem() { Id = 1, OrderId ="0001", Price = 50, ProductId = "30", Quantity = 2} 
                }
            });

            repo.Add(new Order()
            {
                Id = "0002",
                CustomerId = "2",
                OrderDate = DateTime.Now.AddMonths(-2),
                Total = 230,
                Items = new List<OrderItem>() {
                    new OrderItem() { Id = 1, OrderId ="0002", Price = 40, ProductId = "30", Quantity = 2},
                    new OrderItem() { Id = 2, OrderId ="0002", Price = 150, ProductId = "20", Quantity = 1}
                }
            });

            repo.Add(new Order()
            {
                Id = "0003",
                CustomerId = "3",
                OrderDate = DateTime.Now.AddMonths(-3),
                Total = 300,
                Items = new List<OrderItem>() {
                    new OrderItem() { Id = 1, OrderId ="0003", Price = 50, ProductId = "30", Quantity = 3},
                    new OrderItem() { Id = 2, OrderId ="0003", Price = 10, ProductId = "40", Quantity = 5},
                    new OrderItem() { Id = 3, OrderId ="0003", Price = 100, ProductId = "70", Quantity = 1},
                }
            });

            repo.Add(new Order()
            {
                Id = "0004",
                CustomerId = "2",
                OrderDate = DateTime.Now.AddMonths(-4),
                Total = 40,
                Items = new List<OrderItem>() {
                     new OrderItem() { Id = 1, OrderId ="0004", Price = 10, ProductId = "40", Quantity = 4},
                }
            });
        }
        public Task<ICollection<Order>> GetAsync(string customerId)
        {
            var orders = repo.Where(o => o.CustomerId == customerId).ToList();
            return Task.FromResult((ICollection<Order>)orders);
        }
    }
}
