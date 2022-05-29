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
        private readonly IGetProductService _getProductService;
        private readonly IMemoryCache _memoryCache;
        private readonly ICreateOrderService _createOrderService;


        public MobilivaController(IGetProductService getProductService, IMemoryCache memoryCache, ICreateOrderService createOrderService)
        {
            _getProductService = getProductService;
            _memoryCache = memoryCache;
            _createOrderService = createOrderService;
        }

        [HttpGet("GetProducts")]
        public IActionResult GetProduct(string category)
        {
            var key = category;
            if (string.IsNullOrEmpty(category))
            {
                key = "Product";
            }
            if (_memoryCache.TryGetValue(key, out object list))
            {
                return Ok(list);
            }
            else
            {
                var response = _getProductService.OnProcess(category);
                _memoryCache.Set(key, response.Data, new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddSeconds(20),
                    Priority = CacheItemPriority.Normal
                });
                return Ok(response);
            }
        }
        [HttpPost("CreateOrder")]
        public IActionResult CreateOrder(CreateOrderRequestDto createOrderRequestDto)
        {
            var response = _createOrderService.OnProcess(createOrderRequestDto);
            return Ok(response);
        }
    }
}

