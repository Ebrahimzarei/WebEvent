using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebEventoo_DomainClasses.Model;

namespace WebEvento.Data.Config
{
    public class PlaceConfig : IEntityTypeConfiguration<Place>
    {
        readonly ModelBuilder ModelBuilder;
        public PlaceConfig(ModelBuilder Builder)
        {
            ModelBuilder = Builder;
        }
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Place> builder)
        {
//            ModelBuilder.Entity<Place>()
//.HasOne<Event>(s => s.Event)
//.WithOne(ad => ad.Place)
//.HasForeignKey<Event>(ad => ad.PlaceOfId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
