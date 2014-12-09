namespace _9.InsertOrder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Transactions;

    using EntityFrameworkDatabaseFirst;

    class InsertingOrder
    {
        static void Main(string[] args)
        {
            var orderDetails = new List<OrderDetail>()
            {
                new OrderDetail()
                {
                    ProductId = 1,
                    Quantity = 200,
                    UnitPrice = 14.20M
                },
                new OrderDetail()
                {
                    ProductId = 2,
                    Quantity = 300,
                    UnitPrice = 40.20M
                }
            };

            InsertOrder("OCEAN", DateTime.Now, orderDetails);
        }

        private static void InsertOrder(string customerID, DateTime orderDate, IList<OrderDetail> orderDetails)
        {
            using (TransactionScope transactionScope = new TransactionScope())
            {
                using (NorthwindEntities northwindEntities = new NorthwindEntities())
                {
                    Order newOrder = new Order()
                    {
                        CustomerID = customerID,
                        OrderDate = orderDate,
                    };

                    var insertedOrder = northwindEntities.Orders.Add(newOrder);

                    foreach (var od in orderDetails)
                    {
                        northwindEntities.Order_Details.Add(
                        new Order_Detail()
                        {
                            OrderID = insertedOrder.OrderID,
                            ProductID = od.ProductId,
                            Quantity = od.Quantity,
                            UnitPrice = od.UnitPrice
                        });
                    }

                    northwindEntities.SaveChanges();
                    Console.WriteLine("Inserted order with id {0}", insertedOrder.OrderID);
                }

                transactionScope.Complete();
            }
        }

        struct OrderDetail
        {
            public int ProductId { get; set; }

            public short Quantity { get; set; }

            public decimal UnitPrice { get; set; }
        }
    }
}
