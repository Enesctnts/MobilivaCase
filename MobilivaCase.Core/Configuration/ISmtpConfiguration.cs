using MobilivaCase.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilivaCase.Core.Entities.Abstract
{
    public interface ISmtpConfiguration
    {
        string Host { get; }
        int Port { get; }
        string User { get; }
        string Password { get; }
        bool UseSSL { get; }
        SmtpConfig GetSmtpConfig();
    }
}
