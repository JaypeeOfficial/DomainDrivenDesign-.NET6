using Domain.Customers;
using Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Orders;

public class Order
{
    private readonly HashSet<LineItem> _lineItems = new(); 
    private Order()
    {

    }
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }

    public static Order Create(Customer customer)
    {
        var order = new Order
        {
            Id = Guid.NewGuid(),
            CustomerId = customer.Id,
        };

        return order;
    }

    public void Add(Product product)
    {
        var lineItem = new LineItem(Guid.NewGuid(), Id, product.Id, product.Price);

        _lineItems.Add(lineItem);
    }
}


public class LineItem
{
    internal LineItem(
                Guid id,
                Guid orderId, 
                Guid proudctId, 
                Money price)
    {
        Id = id;
        OrderId = orderId;
        ProductId = proudctId;
        Price = price;
    }
    public Guid Id { get; private set;  }
    public Guid OrderId { get; private set;}
    public Guid ProductId { get; private set; }

    public Money Price { get; private set; }

}