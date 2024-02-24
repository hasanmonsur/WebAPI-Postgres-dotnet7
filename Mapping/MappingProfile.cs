using AutoMapper;
using AutoMapProject.Contracts.Responses;
using AutoMapProject.Domain;

namespace AutoMapProject.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerResponse>();

            CreateMap<Order, OrderResponse>();

            CreateMap<OrderItem, OrderItemResponse>();

            CreateMap<Product, ProductResponse>();
            // Add other mappings if needed
        }
    }
}
