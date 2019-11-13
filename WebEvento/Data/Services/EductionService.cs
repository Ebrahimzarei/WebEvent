using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebEventoo_DomainClasses.Model;
using WebEventoo_DomainClasses.Services;

namespace WebEvento.Data.Services
{
    public class EductionService : IEductionservices
    {
        private readonly WebDbContext context;
        public EductionService(WebDbContext Context)
        {
            context = Context;
        }
        public async Task<Eduction> AddAsync(Eduction Eduction)
        {
            context.Eduction.Add(Eduction);
            await context.SaveChangesAsync();
            return Eduction;
        }

        public async Task DeleteConfirmedAsync(int id)
        {
            var op = await context.Eduction.FindAsync(id);
            context.Eduction.Remove(op);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Eduction>> GetAllEductionAsync()
        {
            return await context.Eduction.ToListAsync();

        }

        public async Task<Eduction> GetEductionAsync(int? id)
        {
            return await context.Eduction.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Eduction> UpdateAsync(Eduction Eduction)
        {
            context.Update(Eduction);
            await context.SaveChangesAsync();
            return Eduction;
        }
    }
}
