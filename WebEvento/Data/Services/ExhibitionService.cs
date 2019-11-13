using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebEventoo_DomainClasses.Model;
using WebExhibitionoo_DomainClasses.Services;

namespace WebEvento.Data.Services
{
    public class ExhibitionService : IExhibitionServices

    {
        private readonly WebDbContext context;
        public ExhibitionService(WebDbContext Context)
        {
            context = Context;
        }
        public async Task<Exhibition> AddAsync(Exhibition Exhibition)
        {

            context.Exhibition.Add(Exhibition);
            await context.SaveChangesAsync();
            return Exhibition;
        }

        public async Task DeleteConfirmedAsync(int id)
        {
            var ex = await context.Exhibition.FindAsync(id);
            context.Exhibition.Remove(ex);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Exhibition>> GetAllExhibitionAsync()
        {
            return await context.Exhibition.ToListAsync();
        }

        public async Task<Exhibition> GetExhibitionAsync(int? id)
        {
            return await context.Exhibition.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Exhibition> UpdateAsync(Exhibition Exhibition)
        {
            context.Update(Exhibition);
            await context.SaveChangesAsync();
            return Exhibition;
        }
    }
}
