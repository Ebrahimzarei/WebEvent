using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebEventoo_DomainClasses.Model;
using WebEventoo_DomainClasses.Services;

namespace WebEvento.Data.Services
{
    public class NotPublishedServices : INotPublishedServices
    {
        private readonly WebDbContext context;
        public NotPublishedServices(WebDbContext Context)
        {
            context = Context;
        }

        public async Task<NotPublished> AddAsync(NotPublished NotPublished)
        {
            context.NotPublished.Add(NotPublished);
            await context.SaveChangesAsync();
            return NotPublished;
        }

        public async Task<IEnumerable<NotPublished>> GetAllAsync()
        {
            return await context.NotPublished.ToListAsync();
        }

        public   int GetCount()
        {
            return    context.NotPublished.Count();
        }
    }
}
