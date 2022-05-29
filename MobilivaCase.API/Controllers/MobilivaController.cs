using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using MobilivaCase.Business.Abstract;
using MobilivaCase.Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobilivaCase.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MobilivaController : ControllerBase
    {
        private readonly IProductService _getProductService;
        private readonly IMemoryCache _memoryCache;
        private readonly IOrderService _createOrderService;


        public MobilivaController(IProductService getProductService, IMemoryCache memoryCache, IOrderService createOrderService)
        {
            _getProductService = getProductService;
            _memoryCache = memoryCache;
            _createOrderService = createOrderService;
        }

        [HttpGet("GetProducts")]
        public IActionResult GetProduct(string category)
        {
            var result = _getProductService.OnProcess();
            if (result!=null)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("CreateOrder")]
        public IActionResult CreateOrder(CreateOrderRequestDto createOrderRequestDto)
        {
            //var result = _createOrderService.OnProcess(createOrderRequestDto);
            var result = _carService.Add(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}

