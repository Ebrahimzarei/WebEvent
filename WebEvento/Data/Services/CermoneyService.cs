using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebEventoo_DomainClasses.Model;
using WebEventoo_DomainClasses.Services;

namespace WebEvento.Data.Services
{
    public class CermoneyServic : IExhibitionServices
    {
        private readonly WebDbContext context;
        public CermoneyServic(WebDbContext Context)
        {
            context = Context;
        }
        public async Task<Ceremony> AddAsync(Ceremony Cermoney)
        {
            context.Cermoney.Add(Cermoney);
            await context.SaveChangesAsync();
            return Cermoney;
        }

        public async Task DeleteConfirmedAsync(int id)
        {
            var obj = await context.Cermoney.FindAsync(id);
            context.Cermoney.Remove(obj);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Ceremony>> GetAllCermoneyAsync()
        {
            return await context.Cermoney.ToListAsync();
        }

        public async Task<Ceremony> GetCermoneyAsync(int? id)
        {
            return await context.Cermoney.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Ceremony> UpdateAsync(Ceremony Cermoney)
        {
            context.Update(Cermoney);
            await context.SaveChangesAsync();
            return Cermoney;
        }
    }
}
