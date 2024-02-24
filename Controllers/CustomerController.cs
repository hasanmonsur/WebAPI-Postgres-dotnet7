using System.Collections.Generic;
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
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customers = await _customerService.GetCustomersAsync();
            var customersResponse = _mapper.Map<List<CustomerResponse>>(customers);
            return Ok(customersResponse);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllData([FromRoute] int customerId)
        {
            var customer = await _customerService.GetCustomerAsync(customerId);

            if (customer == null) return NotFound("No record found");

            var customerResponse = _mapper.Map<List<CustomerResponse>>(customer);
            return Ok(customerResponse);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCustomerRequest createCustomerRequest)
        {
            var customer = new Customer
            {
                FirstName = createCustomerRequest.FirstName,
                LastName = createCustomerRequest.LastName
            };
            try
            {
                await _customerService.CreateCustomerAsync(customer);
                var customerResponse = _mapper.Map<CustomerResponse>(customer);

                var uri = "api/v1/customers/" + customer.CustomerId;
                return Created(uri, customerResponse);
            }
            catch (Exception ex)
            {
                return null;
            }           
            
        }
    }
}
