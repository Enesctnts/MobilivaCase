using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilivaCase.Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {
        T Get<T>(string key);
        object Get(string key);
        void Add(string key, object value, int duration);//duration:cache de ne kadar kalıcak
        bool IsAdd(string key);//Cache' de var mı?
        void Remove(string key);//Cache uçur
        void RemoveByPattern(string pattern);//Başında Get olan metodları uçur

    }
}
