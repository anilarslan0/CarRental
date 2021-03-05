using System;
using System.Collections.Generic;
using System.Text;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection; //dikkat

namespace Core.CrossCuttingConcern.Caching.Microsoft
{
    public class CacheRemoveAspect : MethodInterception
    {
        private string _pattern;
        private ICacheManager _cacheManager;

        public CacheRemoveAspect(string pattern)
        {
            _pattern = pattern;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        protected override void OnSuccess(IInvocation invocation)
        {
            _cacheManager.RemoveByPattern(_pattern); //patterne göre silme işlemi yapıyor
        }
    }
}
//CacheRemoveAspect data bozulduğunda çalışır.
//Data ne zaman bozulur?
//Yeni data eklenirse,güncellenirse,silinirse