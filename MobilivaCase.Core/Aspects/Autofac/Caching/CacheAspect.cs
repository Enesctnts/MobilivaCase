using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using MobilivaCase.Core.CrossCuttingConcerns.Caching;
using MobilivaCase.Core.Utilities.Interceptors;
using MobilivaCase.Core.Utilities.IoC;

namespace MobilivaCase.Core.Aspects.Autofac.Caching
{
    public class CacheAspect : MethodInterception
    {
        private int _duration;
        private ICacheManager _cacheManager;

        public CacheAspect(int duration = 60)
        {
            _duration = duration;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        public override void Intercept(IInvocation invocation)
        {
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");//Namespaceyi al , sonra metod ismini al
            var arguments = invocation.Arguments.ToList();//parametreleri listeye çevir
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})";//metodun parametrelerini gez
            if (_cacheManager.IsAdd(key))
            {
                invocation.ReturnValue = _cacheManager.Get(key);//cache de yoksa return yap çık
                return;
            }
            invocation.Proceed();//metodu devam ettir
            _cacheManager.Add(key, invocation.ReturnValue, _duration);//cache ekle
        }
    }
}
