using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebEventoo_DomainClasses.Model;

namespace WebEventoo_DomainClasses.Services
{
 public   interface IExhibitionServices
    {
        Task<IEnumerable<Ceremony>> GetAllCermoneyAsync();
        Task<Ceremony> GetCermoneyAsync(int? id);

        Task<Ceremony> AddAsync(Ceremony Cermoney);
        Task<Ceremony> UpdateAsync(Ceremony Cermoney);
        Task DeleteConfirmedAsync(int id);
    }
}
