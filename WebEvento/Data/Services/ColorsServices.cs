using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebEventoo_DomainClasses.Model;
using WebEventoo_DomainClasses.Services;

namespace WebEvento.Data.Services
{
    public class ColorsServices : IColorService
    {
        private readonly WebDbContext context;
        public ColorsServices(WebDbContext Context)
        {
            context = Context;
        }
        public async Task<Colors> AddAsync(Colors Colors)
        {
            context.Color.Add(Colors);
            await context.SaveChangesAsync();
            return Colors;
        }
        

        public async Task DeleteConfirmedAsync(int id)
        {
            var obj = await context.Color.FindAsync(id);
            context.Color.Remove(obj);
            await context.SaveChangesAsync();
        }

        public async Task<List<Colors>> GetAllColorList()
        {
            return await context.Color.ToListAsync();
        }

        public async Task<IEnumerable<Colors>> GetAllColorsAsync()
        {
            return await context.Color.ToListAsync();
        }
      
        

        public async Task<Colors> GetColorsAsync(int? id)
        {
            return await context.Color.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Colors> UpdateAsync(Colors Colors)
        {
            context.Update(Colors);
            await context.SaveChangesAsync();
            return Colors;
        }

       
    }
}
