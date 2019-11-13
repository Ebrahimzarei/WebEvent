using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebEventoo_DomainClasses.Model;

namespace WebEvento.Data.Config
{
    public class CommentConfig : IEntityTypeConfiguration<Comment>
    {
        ModelBuilder Modelbuilder;
        public CommentConfig(ModelBuilder _modelbuilder)
        {
            Modelbuilder = _modelbuilder;
        }
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comment_Eventoo");
            builder.HasKey(c => c.Id);
            Modelbuilder.Entity<Users>()
       .HasMany(c => c.Comment)
       .WithOne(e => e.User);

            Modelbuilder.Entity<Users>()
.HasOne<Information>(s => s.information)
.WithOne(ad => ad.User);
//.HasForeignKey<Event>(ad => ad.EductionOfId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
