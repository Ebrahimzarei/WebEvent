using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebEventoo_DomainClasses.Model;

namespace WebEvento.Data.Config
{
    public class EventConfig : IEntityTypeConfiguration<Event>
    {
        readonly ModelBuilder ModelBuilder;
        public EventConfig(ModelBuilder Builder)
        {
            ModelBuilder = Builder;
        }
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            //Config One To  Many

         //   ModelBuilder.Entity<Users>()
         //.HasOne<Event>(s => s.Ev)
         //.WithMany(g => g.Event)
         //.HasForeignKey(s => s.UserofId).OnDelete(DeleteBehavior.Cascade);




        }
    }
}
