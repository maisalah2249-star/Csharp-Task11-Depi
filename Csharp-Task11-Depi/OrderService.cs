using System;
using System.Collections.Generic;
using System.Text;

namespace Csharp_Task11_Depi
{
    public class OrderService
    {
        // Part 1
        public decimal CalculateOrderPrice(
        Order order,
        PriceCalculator calculator)
    {
        return calculator(order);
    }

    // Part 2
    public decimal CalculateOrderPriceWithFunc(
        Order order,
        Func<Order, decimal> calculator)
    {
        return calculator(order);
    }

    // Part 3
    public bool ValidateOrder(
        Order order,
        Predicate<Order> validationRule)
    {
        return validationRule(order);
    }

    // Part 4
    public void ProcessOrder(
        Order order,
        Action<Order> action)
    {
        action(order);
    }

    // Part 5
    public event Action<Order> OrderProcessed;

    public void ProcessOrderWithEvent(Order order)
    {
        Console.WriteLine(
            $"Processing Order {order.Id}..."
        );

        OrderProcessed?.Invoke(order);
    }
}
}
