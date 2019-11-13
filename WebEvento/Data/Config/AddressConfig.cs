using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebEventoo_DomainClasses.Model;

namespace WebEvento.Data.Config
{
    public class AddressConfig : IEntityTypeConfiguration<Address>
    {
        readonly ModelBuilder Modelbuilder;
        public AddressConfig(ModelBuilder _modelbuilder)
        {
            Modelbuilder = _modelbuilder;
        }
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Address_Eventoo");
            builder.HasKey(c => c.Id);
        //    Modelbuilder.Entity<Address>()
        //.HasOne<Event>(s => s.Event)
        //.WithOne(ad => ad.Address)
        //.HasForeignKey<Event>(ad => ad.AddressOfId).OnDelete(DeleteBehavior.Cascade);
            //.HasForeignKey<StudentAddress> (ad => ad.AddressOfStudentId);

            //builder.Property(c => c.Username).HasMaxLength(255).IsRequired();
        }
    }
}
