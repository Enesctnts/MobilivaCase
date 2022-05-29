using MobilivaCase.Business.Abstract;
using MobilivaCase.Business.Constants;
using MobilivaCase.Business.ValidationRules.FluentValidation;
using MobilivaCase.Core.Aspects.Autofac.Caching;
using MobilivaCase.Core.Aspects.Autofac.Validation;
using MobilivaCase.Core.Utilities.Business;
using MobilivaCase.Core.Utilities.Result;
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

namespace MobilivaCase.Business.Concrete
{
    public class OrderManager : IOrderService
    {
        private readonly IProductDal _productDal;
        private readonly IOrderDal _orderDal;
        private readonly IMapper _mapper;
        private readonly ISmtpConfiguration _smtpConfig;
        private readonly IPublisherService _publisherService;


        public OrderManager(IProductDal productDal, IOrderDal orderDal, ISmtpConfiguration smtpConfig, IPublisherService publisherService, IMapper mapper)
        {
            _productDal = productDal;
            _orderDal = orderDal;
            _smtpConfig = smtpConfig;
            _publisherService = publisherService;
            _mapper = mapper;
        }
        private MailMessageData PrepareMessages(PostMailViewModel post, string email)
        {
            var message = new MailMessageData()
            {
                To = email.ToString(),
                From = _smtpConfig.User,
                Subject = post.Post.Title,
                Body = post.Post.Content
            };

            return message;
        }

        [CacheRemoveAspect("IProductService.Get")]
        public int Add(CreateOrderRequestDto orderRequest)
        {

            var orderList = _orderDal.GetAll();
            decimal TotalPrice = 0;
            var post = new PostMailViewModel();


            var detail = new OrderDetail();
            var order1 = new Order();
            foreach (var product in orderRequest.ProductDetails)
            {
                var pro = _productDal.GetAll().FirstOrDefault(x => x.Id == product.ProductId);
                if (pro!=null)
                {
                    var detailPrice = product.Amount * product.UnitPrice;
                    TotalPrice += detailPrice;
                    detail.Product = pro;
                    detail.UnitPrice = detailPrice;
                    order1.OrderDetails.Add(detail);
                }
                
                
            }
            var order = _mapper.Map<Order>(orderRequest);
            _orderDal.Add(order);

            post.Post.Content = "Sipariş Başarılı bir şekilde oluşturulmuştur.";
            post.Post.Title = "Sipariş Detayı";
            //_publisherService.Enqueue(
            //                          PrepareMessages(post, request.CustomerEmail),
            //                          RabbitMQConsts.RabbitMqConstsList.QueueNameEmail.ToString()
            //                        );
            return order.Id;
        }

        #region BusinessRules

        private IResult CheckIfGsmExists(string tel)
        {
            var result = _orderDal.GetAll(c => c.CustomerGSM == tel).Any();
            if (result)
            {
                return new ErrorResult(Messages.NumberAlreadyExists);
            }

            return new SuccessResult();
        }

        #endregion
    }
}
