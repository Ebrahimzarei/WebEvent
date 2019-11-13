using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebEventoo_DomainClasses.Model;

namespace WebEvento.Data.Services
{
    public class InformationServices : WebEventoo_DomainClasses.Services.IInformationService
    {
        private readonly WebDbContext context;
        public InformationServices(WebDbContext Context)
        {
            context = Context;
        }
        public async Task<Information> AddAsync(Information Information)
        {
            context.Information.Add(Information);
            await context.SaveChangesAsync();
            return Information;
        }

        public async Task DeleteConfirmedAsync(int id)
        {
            var obj = await context.Information.FindAsync(id);
            context.Information.Remove(obj);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Information>> GetAllInformationAsync()
        {
            return await context.Information.ToListAsync();
        }
        public async Task<List<Information>> GetAllInformationListAsync()
        {
            var item = await context.Information.Include(x => x.User).ThenInclude(x => x.information).ToListAsync();
           
            return item;
        }
        //GetAllInformationListAsync

        public async Task<Information> GetInformationAsync(int? id)
        {
            return await context.Information.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Information> UpdateAsync(Information Information)
        {
            context.Update(Information);
            await context.SaveChangesAsync();
            return Information;
        }
    }
}
