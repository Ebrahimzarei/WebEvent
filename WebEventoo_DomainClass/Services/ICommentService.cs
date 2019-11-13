using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebEventoo_DomainClasses.Model;

namespace WebEventoo_DomainClasses.Services
{
 public   interface ICommentService
    {
        Task<IEnumerable<Comment>> GetAllCommentAsync();
        Task<Comment> GetCommentAsync(int? id);

        Task<Comment> AddAsync(Model.Comment Comment);
        Task<Comment> UpdateAsync(Comment Comment);
        Task DeleteConfirmedAsync(int id);
    }
}
