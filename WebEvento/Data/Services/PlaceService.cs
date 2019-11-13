using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebEventoo_DomainClasses.Model;
using WebEventoo_DomainClasses.Services;

namespace WebEvento.Data.Services
{
    public class PlaceService : IPlaceServices
    {
        private readonly WebDbContext context;
        public PlaceService(WebDbContext Context)
        {
            context = Context;
        }
        public async Task<Place> AddAsync(Place Place)
        {
            context.Place.Add(Place);
            await context.SaveChangesAsync();
            return Place;
        }

        public async Task DeleteConfirmedAsync(int id)
        {
            var Place = await context.Place.FindAsync(id);
            context.Place.Remove(Place);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Place>> GetAllPlaceAsync()
        {
            return await context.Place.ToListAsync();
        }

        public async Task<Place> GetPlaceAsync(int? id)
        {
            return await context.Place.FirstOrDefaultAsync(m => m.Id == id);

        }

        public async Task<Place> UpdateAsync(Place Place)
        {
            context.Update(Place);
            await context.SaveChangesAsync();
            return Place;
        }
    }
}
