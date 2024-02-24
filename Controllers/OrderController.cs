using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapProject.Contracts.Requests;
using AutoMapProject.Contracts.Responses;
using AutoMapProject.Domain;
using AutoMapProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace AutoMapProject.Controllers
{

    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrderController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromRoute] int orderId)
        {
            var order = await _orderService.GetOrderAsync(orderId);
            var orderResponse = _mapper.Map<OrderResponse>(order);
            return Ok(orderResponse);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOrderRequest createOrderRequest)
        {
            var order = new Order
            {
                CustomerId = createOrderRequest.CustomerId,
                OrderDate = createOrderRequest.OrderDate,
                OrderItems = createOrderRequest.OrderItems.ToList().Select(s => new OrderItem
                {
                    ProductId = s.ProductId,
                    Quantity = s.Quantity
                }).ToList()
            };
            await _orderService.CreateOrderAsync(order);
            var orderResponse = _mapper.Map<OrderResponse>(order);
            var uri = "api/v1/orders/" + order.OrderId;
            return Created(uri, orderResponse);
        }
    }
}
