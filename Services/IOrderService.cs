using System.Threading.Tasks;
using AutoMapProject.Domain;

namespace AutoMapProject.Services
{
    public interface IOrderService
    {
        Task<Order> GetOrderAsync(int orderId);
        Task<bool> CreateOrderAsync(Order order);
    }
}
