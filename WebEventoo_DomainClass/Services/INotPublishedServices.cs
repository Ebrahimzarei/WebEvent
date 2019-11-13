using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebEventoo_DomainClasses.Model;

namespace WebEventoo_DomainClasses.Services
{
  public  interface INotPublishedServices
    {
        Task<IEnumerable<NotPublished>> GetAllAsync( );
      
        int GetCount();
        Task<NotPublished> AddAsync(Model.NotPublished NotPublished);
    }
}
