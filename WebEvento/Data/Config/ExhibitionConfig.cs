using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebEventoo_DomainClasses.Model;

namespace WebEvento.Data.Config
{
    public class ExhibitionConfig : IEntityTypeConfiguration<Exhibition>
    {
        readonly ModelBuilder ModelBuilder;
        public ExhibitionConfig(ModelBuilder Builder)
        {
            ModelBuilder = Builder;
        }
        public void Configure(EntityTypeBuilder<Exhibition> builder)
        {
       //     ModelBuilder.Entity<Exhibition>()
       //.HasOne<Event>(s => s.Event)
       //.WithOne(ad => ad.Exhibotion)
       //.HasForeignKey<Event>(ad => ad.ExhibotionOfId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
