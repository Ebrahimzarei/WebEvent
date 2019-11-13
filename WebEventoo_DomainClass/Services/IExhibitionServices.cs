using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebEventoo_DomainClasses.Model;

namespace WebExhibitionoo_DomainClasses.Services
{
  public  interface IExhibitionServices
    {
        Task<IEnumerable<Exhibition>> GetAllExhibitionAsync();
        Task<Exhibition> GetExhibitionAsync(int? id);

        Task<Exhibition> AddAsync(Exhibition Exhibition);
        Task<Exhibition> UpdateAsync(Exhibition Exhibition);
        Task DeleteConfirmedAsync(int id);
    }
}
