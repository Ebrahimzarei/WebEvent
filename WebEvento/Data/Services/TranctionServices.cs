using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebEventoo_DomainClasses.Model;
using WebEventoo_DomainClasses.Services;

namespace WebEvento.Data.Services
{
    public class TranctionServices : ITranctionServices
    {
        private readonly WebDbContext context;
        public TranctionServices(WebDbContext Context)
        {
            context = Context;
        }

        public async Task<EventResultBank> AddAsync(EventResultBank TranctionEvent)
        {
            context.TranctionEvent.Add(TranctionEvent);
            await context.SaveChangesAsync();
            return TranctionEvent;
        }

        public async Task<IEnumerable<EventResultBank>> GetTranctionEventAsync()
        {
            return await context.TranctionEvent.ToListAsync();
        }
    }
}
