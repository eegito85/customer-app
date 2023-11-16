using CustomerApp.Application.DTOs;
using CustomerApp.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;
        private IConfiguration _configuration;

        public AddressController(IAddressService addressService, IConfiguration configuration)
        {
            _addressService = addressService;
            _configuration = configuration;
        }

        /// <summary>
        /// Endpoint que busca através de API as informações de endereço a partir do CEP
        /// </summary>
        /// <param name="cep">Cep do cliente</param>
        /// <returns></returns>
        [HttpGet("GetAddress/{cep}")]
        public async Task<ActionResult<AddressDTO>> GetAddress(string cep)
        {
            string baseUrl = _configuration.GetSection("Apis:ViaCepApi").Value;

            if(string.IsNullOrEmpty(baseUrl))
            {
                return NotFound("Url não encontrada");
            }

            var address = await _addressService.GetAddressByApi(baseUrl, cep);

            if (address == null)
            {
                return NotFound("Endereço não encontrado");
            }

            return Ok(address);
        }

    }
}
