using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebEventoo_DomainClasses.Model;
using WebEventoo_DomainClasses.Services;

namespace WebEvento.Data.Services
{
    public class AddressService : IAddresServices
    {
        private readonly WebDbContext context;
        public AddressService()
        {

        }
     
        public AddressService(WebDbContext Context)  
        {
            context = Context;
        }
        public async Task<Address> AddAsync(Address Address)
        {
            context.Address.Add(Address);
            await context.SaveChangesAsync();
            return Address;
        }

        public async Task DeleteConfirmedAsync(int id)
        {
            var obj = await context.Address.FindAsync(id);
            context.Address.Remove(obj);
            await context.SaveChangesAsync();
        }

        public async Task<Address> GetAddressAsync(int? id)
        {
            return await context.Address.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<Address>> GetAllAddressAsync()
        {
            return await context.Address.ToListAsync();
        }

        public async Task<Address> UpdateAsync(Address Address)
        {
            context.Update(Address);
            await context.SaveChangesAsync();
            return Address;
        }
    }
}
