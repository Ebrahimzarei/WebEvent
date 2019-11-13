using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebEventoo_DomainClasses.Model;

namespace WebEvento.Data.Config
{

    public class EductionConfig : IEntityTypeConfiguration<Eduction>
    {
        readonly ModelBuilder Modelbuilder;
        public EductionConfig(ModelBuilder Builder)
        {
            Modelbuilder = Builder;
        }
        public void Configure(EntityTypeBuilder<Eduction> builder)
        {
  //          Modelbuilder.Entity<Eduction>()
  //.HasOne<Event>(s => s.Event)
  //.WithOne(ad => ad.Eduction)
  //.HasForeignKey<Event>(ad => ad.EductionOfId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
