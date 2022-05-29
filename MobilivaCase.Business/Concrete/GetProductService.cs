using MobilivaCase.Business.Abstract;
using MobilivaCase.DataAccess.Abstract;
using MobilivaCase.Entity.Concrete;
using MobilivaCase.Entity.DTOs;
using MobilivaCase.Entity.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilivaCase.Business.Concrete
{
    public class GetProductService : IGetProductService
    {
        private readonly IProductDal _productDal;
        public GetProductService(IProductDal productDal)
        {
            _productDal = productDal;
        }
        public ApiResponseDto<Product> OnProcess(string request = null)
        {
            var response = new ApiResponseDto<Product>();
            try
            {
                if (string.IsNullOrEmpty(request))
                {
                    response.Data = _productDal.GetAll().ToList();
                }
                else
                {
                    response.Data = _productDal.GetAll().Where(x => x.Category == request).ToList();
                }

                response.ResultMessage = "İşlem Başarılı";
                response.Status = Status.Success;
            }
            catch (Exception e)
            {
                response.ResultMessage = "İşlem Başarısız";
                response.Status = Status.Failed;
                response.ErrorCode = e.Message;
            }

            return response;
        }

    }
}
