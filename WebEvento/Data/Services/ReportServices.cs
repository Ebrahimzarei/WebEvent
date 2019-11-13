using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebEventoo_DomainClasses.Model;
using WebEventoo_DomainClasses.Services;

namespace WebEvento.Data.Services
{
    public class ReportServices : IReportServices
    {
        private readonly WebDbContext context;
        public ReportServices(WebDbContext Context)
        {
            context = Context;
        }
        public async Task<Report> AddAsync(Report Reports)
        {
            context.Report.Add(Reports);
            await context.SaveChangesAsync();
            return Reports;
        }

        public async Task DeleteConfirmedAsync(int id)
        {
            var obj = await context.Report.FindAsync(id);
            context.Report.Remove(obj);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Report>> GetAllReportAsync()
        {
            return await context.Report.Include(x=>x.Event).ThenInclude(x=>x.ReportList).ToListAsync();
        }

        public async Task<Report> GetReportAsync(int? id)
        {
            return await context.Report.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Report> UpdateAsync(Report Report)
        {
            context.Update(Report);
            await context.SaveChangesAsync();
            return Report;
        }
    }
}
