using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebEventoo_DomainClasses.Model;

namespace WebEvento.Data.Config
{
    public class CermoneyConfig : IEntityTypeConfiguration<Ceremony>
    {
        readonly ModelBuilder Modelbuilder;
        public CermoneyConfig(ModelBuilder Builder)
        {
            Modelbuilder = Builder;
        }
   


        public void Configure(EntityTypeBuilder<Ceremony> builder)
        {
          //  Modelbuilder.Entity<Ceremony>()
            //.HasOne<Event>(s => s.Event)
            //.WithOne(ad => ad.Cermoney)
            //.HasForeignKey<Event>(ad => ad.CermoneyOfId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
