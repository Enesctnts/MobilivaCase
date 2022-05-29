using MobilivaCase.Business.Abstract;
using MobilivaCase.Business.ValidationRules.FluentValidation;
using MobilivaCase.Core.Aspects.Autofac.Validation;
using MobilivaCase.DataAccess.Abstract;
using MobilivaCase.Entity.Concrete;
using MobilivaCase.Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilivaCase.Business.Concrete
{
    public class CreateOrderService : ICreateOrderService
    {
        private readonly IProductDal _productDal;
        private readonly IOrderDal _orderDal;
        private readonly ISmtpConfiguration _smtpConfig;
        private readonly IPublisherService _publisherService;


        public CreateOrderService(IProductDal productDal, IOrderDal orderDal, ISmtpConfiguration smtpConfig, IPublisherService publisherService)
        {
            _productDal = productDal;
            _orderDal = orderDal;
            _smtpConfig = smtpConfig;
            _publisherService = publisherService;
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

        [ValidationAspect(typeof(OrderValidator))]
        public string OnProcess(CreateOrderRequestDto request = null)
        {
            decimal TotalPrice = 0;
            var order = new Order();
            var post = new PostMailViewModel();
            order.CustomerEmail = request.CustomerEmail;
            order.CustomerGSM = request.CustomerGSM;
            order.CustomerName = request.CustomerName;

            foreach (var product in request.ProductDetails)
            {
                var detail = new OrderDetail();
                var pro = _productDal.GetAll().FirstOrDefault(x => x.Id == product.ProductId);
                var detailPrice = product.Amount * product.UnitPrice;
                TotalPrice += detailPrice;
                detail.Product = pro;
                detail.UnitPrice = detailPrice;

            }
            order.TotalAmount = TotalPrice;
            _orderDal.Add(order);
            _orderDal.Save();
            post.Post.Content = "Sipariş oluşturuldu.";
            post.Post.Title = "Sipariş Detayı";
            _publisherService.Enqueue(
                                      PrepareMessages(post, request.CustomerEmail),
                                      RabbitMQConsts.RabbitMqConstsList.QueueNameEmail.ToString()
                                    );
            return order.Id;
        }
    }
}
