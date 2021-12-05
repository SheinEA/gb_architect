using System;

namespace OrderService
{
    public class Order
    {
        public int Id { get; set; }

        public int CustomerId {get; set; }

        public DateTime Date { get; set; }

        public decimal Price { get; set; }
    }
}
