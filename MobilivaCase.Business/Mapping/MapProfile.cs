using AutoMapper;
using MobilivaCase.Entity.Concrete;
using MobilivaCase.Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilivaCase.Business.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<CreateOrderRequestDto, Order>().ReverseMap();
            CreateMap<ProductDto, Product>().ReverseMap();

        }
    }
}
