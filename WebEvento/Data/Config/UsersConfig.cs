using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebEventoo_DomainClasses.Model;

namespace WebEvento.Data.Config
{
    public class UsersConfig : IEntityTypeConfiguration<Users>
    {
        ModelBuilder ModelBuilder;
        public UsersConfig(ModelBuilder Builder)
        {
            ModelBuilder = Builder;
        }
        public void Configure(EntityTypeBuilder<Users> builder)
        {
           // throw new NotImplementedException();
        }
    }
}
