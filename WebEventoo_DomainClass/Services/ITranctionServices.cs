using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebEventoo_DomainClasses.Model;

namespace WebEventoo_DomainClasses.Services
{
 public   interface ITranctionServices
    {
        Task<EventResultBank> AddAsync(Model.EventResultBank TranctionEvent);
        Task<IEnumerable<EventResultBank>> GetTranctionEventAsync();
        
    }
}
