using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileCalc.Services
{
    /// <summary>
    /// Thank you https://gist.github.com/alexsimo/cfb154d0502e683af00b
    /// </summary>
    public static class ServiceContainer
    {
        static readonly Dictionary<Type, Lazy<object>> services = new Dictionary<Type, Lazy<object>>();

        public static void Register<T>(Func<T> function)
        {
            services[typeof(T)] = new Lazy<object>(() => function());
        }

        public static T Resolve<T>()
        {
            return (T)Resolve(typeof(T));
        }

        public static object Resolve(Type type)
        {
            Lazy<object> service;
            if (services.TryGetValue(type, out service))
            {
                return service.Value;
            }
            throw new Exception("Service not found! (ServiceContainer.Resolve)");
        }

    }
}
