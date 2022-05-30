using MobilivaCase.Business.Abstract;
using MobilivaCase.DataAccess.Abstract;
using MobilivaCase.Entity.Concrete;
using MobilivaCase.Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapster;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MobilivaCase.Core.Utilities.Results;

namespace MobilivaCase.Business.Concrete
{
    public class OrderManager : IOrderService
    {
        private readonly IProductDal _productDal;
        private readonly IOrderDal _orderDal;
        private readonly IOrderDetailDal _orderDetailDal;
        private readonly IMapper _mapper;
        //private readonly ISmtpConfiguration _smtpConfig;
        //private readonly IPublisherService _publisherService;


        public OrderManager(IProductDal productDal, IOrderDal orderDal,/* ISmtpConfiguration smtpConfig, IPublisherService publisherService,*/ IMapper mapper, IOrderDetailDal orderDetailDal)
        {
            _productDal = productDal;
            _orderDal = orderDal;
            _mapper = mapper;
            _orderDetailDal = orderDetailDal;
            //_smtpConfig = smtpConfig;
            //_publisherService = publisherService;
        }
        //private MailMessageData PrepareMessages(PostMailViewModel post, string email)
        //{
        //    var message = new MailMessageData()
        //    {
        //        To = email.ToString(),
        //        From = _smtpConfig.User,
        //        Subject = post.Post.Title,
        //        Body = post.Post.Content
        //    };

        //    return message;
        //}


        public async Task<ApiResponse> CreateOrder([FromBody] CreateOrderRequestDto createOrderRequest)
        {
            ApiResponse apiResponse = new ApiResponse();
            OrderDetail orderDetail = new OrderDetail();

            var order = _mapper.Map<Order>(createOrderRequest);



            if (createOrderRequest.ProductDetails == null)
            {
                apiResponse.ResultMessage = "Ürün Detay Bilgileri Zorunludur";
                apiResponse.Status = ApiResponse.StatusCode.Failed;
                apiResponse.ErrorCode = 400;
                //return Task.FromResult(new ApiResponse()); 
                return apiResponse; 
            }

            order.TotalAmount = createOrderRequest.ProductDetails.Sum(x => x.Amount);
            _orderDal.AddAsync(order);




            foreach (var productDetail in createOrderRequest.ProductDetails)
            {
                var getProduct = _productDal.Get(x => x.Id == productDetail.ProductId);
                if (productDetail.ProductId == 0 || productDetail.Amount == 0 || productDetail.UnitPrice == 0)
                {
                    apiResponse.ResultMessage = "Ürün Detay Bilgileri Geçersiz";
                    apiResponse.Status = ApiResponse.StatusCode.Failed;
                    apiResponse.ErrorCode = 400;
                    //return Task.FromResult(new ApiResponse()); 
                    return apiResponse;
                }

                orderDetail.OrderId = order.Id;
                orderDetail.ProductId = productDetail.ProductId;
                orderDetail.UnitPrice = productDetail.UnitPrice;

            }
            _orderDetailDal.AddAsync(orderDetail);

            //_rabbitMQProducer.Send(name, mail, "Sipariş oluşturuldu");


            apiResponse.ResultMessage = "Success";
            apiResponse.Status = ApiResponse.StatusCode.Success;
            apiResponse.ErrorCode = 0;
            apiResponse.Data = order.Id;

            //return (ApiResponse)apiResponse.Data;
            return apiResponse;
        }


    }
}
