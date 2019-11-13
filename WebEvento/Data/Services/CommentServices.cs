using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebEventoo_DomainClasses.Model;
using WebEventoo_DomainClasses.Services;

namespace WebEvento.Data.Services
{
    public class CommentServices : ICommentService
    {
        private readonly WebDbContext context;
        public CommentServices(WebDbContext Context)
        {
            context = Context;
        }
        public async Task<Comment> AddAsync(Comment Comment)
        {
            context.Comment.Add(Comment);
            await context.SaveChangesAsync();
            return Comment;
        }

        public async Task DeleteConfirmedAsync(int id)
        {
            var obj = await context.Comment.FindAsync(id);
            context.Comment.Remove(obj);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Comment>> GetAllCommentAsync()
        {
            return await context.Comment.Include(x=>x.Event).ThenInclude(x=>x.Comment).ToListAsync();
        }

        public async Task<Comment> GetCommentAsync(int? id)
        {
            return await context.Comment.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Comment> UpdateAsync(Comment Comment)
        {
            context.Update(Comment);
            await context.SaveChangesAsync();
            return Comment;
        }
    }
}
