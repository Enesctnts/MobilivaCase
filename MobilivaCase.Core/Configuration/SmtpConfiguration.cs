using Microsoft.Extensions.Configuration;
using MobilivaCase.Core.Entities.Abstract;
using MobilivaCase.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilivaCase.Core.Configuration
{
    public class SmtpConfiguration : ISmtpConfiguration
    {
        private IConfiguration Configuration { get; }

        public SmtpConfiguration(IConfiguration configuration) => Configuration = configuration;

        public string Host => Configuration.GetSection("SmtpConfig:Host").Value;
        public int Port => Convert.ToInt32(Configuration.GetSection("SmtpConfig:Port").Value);
        public string User => Configuration.GetSection("SmtpConfig:SenderMail").Value;
        public string Password => Configuration.GetSection("SmtpConfig:Password").Value;
        public bool UseSSL => Convert.ToBoolean(Configuration.GetSection("SmtpConfig:UseSSL").Value);

        public SmtpConfig GetSmtpConfig()
        {
            return new SmtpConfig
            {
                Host = Host,
                Password = Password,
                Port = Port,
                User = User,
                UseSsl = UseSSL
            };
        }
    }
}
