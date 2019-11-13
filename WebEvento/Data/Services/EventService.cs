using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebEventoo_DomainClasses.Model;
using WebEventoo_DomainClasses.Services;

namespace WebEvento.Data.Services
{
    public class EventService : IEventServices
    {
        private readonly WebDbContext context;
        public EventService(WebDbContext Contextv)
        {
            context = Contextv;
        }
        public async Task<Event> AddAsync(Event Event)
        {
            context.Event.Add(Event);
            await context.SaveChangesAsync();
            return Event;
        }

        public async Task DeleteConfirmedAsync(int id)
        {
            var ex = await context.Event.FindAsync(id);
            context.Event.Remove(ex);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Event>> GetAllEventAsync()
        {
            return await context.Event.ToListAsync();
        }
        public async Task<List<Event>> GetAllEventListAsync()
        {
            return await context.Event.Include(x => x.Image).ToListAsync();
         // return await context.Event.ToListAsync();
        }

        public async Task<Event> GetEventAsync(int? id)
        {
            var item= context.Event
                .Include(x=>x.Image)
                .Include(c=>c.Address)
                .Include(c=>c.Eduction)
                .Include(c => c.Exhibotion)
                .Include(c=>c.Place)
                .SingleOrDefaultAsync(x=>x.Id==id);

            
           
            return await item;
        }

        public async Task<Event> UpdateAsync(Event Event)
        {
            context.Update(Event);
            await context.SaveChangesAsync();
            return Event;
        }
    }
}
