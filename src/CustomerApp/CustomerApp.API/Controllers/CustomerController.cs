using CustomerApp.Application.DTOs;
using CustomerApp.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IAddressService _addressService;
        private readonly ICustomerService _customerService;

        public CustomerController(IAddressService addressService,
            ICustomerService customerService)
        {
            _addressService = addressService;
            _customerService = customerService;
        }

        /// <summary>
        /// Endpoint que retorna os dados de todos os clientes
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetCustomers")]
        public async Task<ActionResult<CustomerDTO>> GetCustomers()
        {
            var customers = await _customerService.GetAllCustomers();
            if (customers.Count() == 0)
            {
                return NotFound("Não foi possível retornar os dados dos clientes");
            }
            
            return Ok(customers);
        }

        /// <summary>
        /// Endpoint para retornar a informação completa de um cliente
        /// </summary>
        /// <param name="id">Id do cliente</param>
        /// <returns></returns>
        [HttpGet("GetCustomer/{id}")]
        public async Task<ActionResult<CustomerDTO>> GetCustomerByCustomerId(int id)
        {
            var customer = await _customerService.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound("Não foi possível retornar os dados do cliente");
            }
            var address = await _addressService.GetAddressByCustomerId(customer.Id);
            customer.Address = address;

            return Ok(customer);
        }

        /// <summary>
        /// Endpoint para cadastrar na base de dados as informações do cliente
        /// </summary>
        /// <param name="customerDto"></param>
        /// <returns></returns>
        [HttpPost("CreateCustomer")]
        public async Task<ActionResult> Post([FromBody] CustomerDTO customerDto)
        {
            if (customerDto == null)
                return BadRequest("Data Invalid");

            await _customerService.CreateCustomer(customerDto);
            await _addressService.CreateAddress(customerDto.Address, customerDto.Id);

            return Ok(customerDto);
        }

        /// <summary>
        /// Endpoint para atualizar os dados de um cliente
        /// </summary>
        /// <param name="id"></param>
        /// <param name="customerDto"></param>
        /// <returns></returns>
        [HttpPut("UpdateCustomer/{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] CustomerDTO customerDto)
        {
            if (id != customerDto.Id)
            {
                return BadRequest("Dado invalido");
            }

            if (customerDto == null)
                return BadRequest("Dado invalido");

            await _customerService.UpdateCustomer(customerDto);
            await _addressService.UpdateAddress(customerDto.Address);

            return Ok(customerDto);
        }

        /// <summary>
        /// Endpoint para apagar o registro de um cliente na base de dados
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("DeleteCustomer/{id}")]
        public async Task<ActionResult<CustomerDTO>> Delete(int id)
        {
            var customerDto = await _customerService.GetCustomerById(id);

            if (customerDto == null)
            {
                return NotFound("Cliente não encontrado");
            }
            var address = await _addressService.GetAddressByCustomerId(id);

            await _customerService.RemoveCustomer(id);
            await _addressService.RemoveAddress(address.Id);

            return Ok(customerDto);
        }

    }
}
