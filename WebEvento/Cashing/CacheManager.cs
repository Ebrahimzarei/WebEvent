using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebEvento.Data;
using WebEventoo_DomainClasses.Model;

namespace WebEvento.Cashing
{
    public class CacheManager
    {
        private const string Menu = "__MenuItems__";

        private IMemoryCache _cache;
        private readonly IServiceProvider _serviceProvider;


        public CacheManager(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }


        public IMemoryCache Cache
        {
            get
            {
                if (_cache == null)
                {
                    _cache = _serviceProvider.GetRequiredService<IMemoryCache>();
                }

                return _cache;
            }
        }


        public async Task<List<Event>> GetMenuItemsAsync()
        {
            return await Cache.GetOrCreateAsync(Menu, async (entry) =>
            {
                entry.SlidingExpiration = TimeSpan.FromMinutes(8);

                using (var scope = _serviceProvider.CreateScope())
                {
                    var dataContext = scope.ServiceProvider.GetRequiredService<WebDbContext>();
                  
                    return await dataContext.Event.ToListAsync();
                }

            });
        }

        public void RemoveMenu()
        {
            Cache.Remove(Menu);
        }

    }
}
