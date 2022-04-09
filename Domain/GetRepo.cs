
using Microsoft.Extensions.DependencyInjection;

namespace App.Domain
{
    public static class GetRepo  {
        private static IServiceProvider? service;

        public static TRepo? Instance<TRepo> () where TRepo : class
            => service?.CreateScope()?.ServiceProvider?.GetService<TRepo> ();
        public static void SetService(IServiceProvider s) => service = s;
    }
}
