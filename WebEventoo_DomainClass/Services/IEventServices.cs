using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebEventoo_DomainClasses.Model;

namespace WebEventoo_DomainClasses.Services
{
    public interface IEventServices
    {
        Task<IEnumerable<Event>> GetAllEventAsync();
        Task<List<Event>> GetAllEventListAsync();
        Task<Event> GetEventAsync(int? id);
        Task<Event> AddAsync(Model.Event Event);
        Task<Event> UpdateAsync(Event Event);
        Task DeleteConfirmedAsync(int id);

    }
}
