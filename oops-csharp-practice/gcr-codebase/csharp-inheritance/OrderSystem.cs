using System;

class Order
{
    public int OrderId;
    public string OrderDate;

    public Order(int orderId, string orderDate)
    {
        OrderId = orderId;
        OrderDate = orderDate;
    }

    public virtual string GetOrderStatus()
    {
        return "Order Placed";
    }
}

class ShippedOrder : Order
{
    public string TrackingNumber;

    public ShippedOrder(int orderId, string orderDate, string trackingNumber)
        : base(orderId, orderDate)
    {
        TrackingNumber = trackingNumber;
    }

    public override string GetOrderStatus()
    {
        return "Order Shipped";
    }
}

class DeliveredOrder : ShippedOrder
{
    public string DeliveryDate;

    public DeliveredOrder(int orderId, string orderDate, string trackingNumber, string deliveryDate)
        : base(orderId, orderDate, trackingNumber)
    {
        DeliveryDate = deliveryDate;
    }

    public override string GetOrderStatus()
    {
        return "Order Delivered";
    }
}

class OrderSystem
{
    static void Main(string[] args)
    {
        DeliveredOrder order = new DeliveredOrder(
            1001,
            "10-01-2026",
            "TRK789456",
            "12-01-2026"
        );

        Console.WriteLine("Order ID       : " + order.OrderId);
        Console.WriteLine("Order Date     : " + order.OrderDate);
        Console.WriteLine("Tracking No    : " + order.TrackingNumber);
        Console.WriteLine("Delivery Date : " + order.DeliveryDate);
        Console.WriteLine("Status         : " + order.GetOrderStatus());
    }
}
