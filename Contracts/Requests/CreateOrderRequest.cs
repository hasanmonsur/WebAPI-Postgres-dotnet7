using System;
using System.Collections.Generic;

namespace AutoMapProject.Contracts.Requests
{
    public class CreateOrderRequest
    {
        public int CustomerId { get; set; }
        public List<CreateOrderItemRequest> OrderItems { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
