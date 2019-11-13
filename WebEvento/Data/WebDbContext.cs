using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebEventoo_DomainClasses.Model;


namespace WebEvento.Data
{
    public class WebDbContext:  IdentityDbContext<Users>
    {
        public WebDbContext(DbContextOptions<WebDbContext> options)
       : base(options)
        {


        }
        public DbSet<Colors> Color { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<NotPublished> NotPublished { get; set; }
        public DbSet<Ceremony> Cermoney { get; set; }
        public DbSet<Eduction> Eduction { get; set; }
        public DbSet<Event> Event { get; set; }
        public DbSet<Exhibition> Exhibition { get; set; }
        public DbSet<Place> Place { get; set; }
        public DbSet<Users> User { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<Information> Information { get; set; }
        public DbSet<Report> Report { get; set; }
        public DbSet<EventResultBank> TranctionEvent { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            optionsBuilder.UseSqlServer(@"Server=DESKTOP-70R2I55;Database=myDataBase;User Id=sa;
//Password = 2280854236; ");
            base.OnConfiguring(optionsBuilder);
         //   optionsBuilder.UseLazyLoadingProxies();
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new Config.CermoneyConfig(builder));
            builder.ApplyConfiguration(new Config.AddressConfig(builder));
            builder.ApplyConfiguration(new Config.EductionConfig(builder));
           // builder.ApplyConfiguration(new Config.EventConfig(builder));
            builder.ApplyConfiguration(new Config.ExhibitionConfig(builder));
            builder.ApplyConfiguration(new Config.PlaceConfig(builder));
            //  builder.ApplyConfiguration(new Config.UsersConfig(builder));
            //Config One To One
            //    builder.Entity<Address>()
            //.HasOne<Event>(s => s.Event)
            //.WithOne(ad => ad.Address)
            //.HasForeignKey<Event>(ad => ad.AddressOfId);

            //      builder.Entity<Exhibition>()
            //.HasOne<Event>(s => s.Event)
            //.WithOne(ad => ad.Exhibotion)
            //.HasForeignKey<Event>(ad => ad.ExhibotionOfId).OnDelete(DeleteBehavior.Cascade);

            //          builder.Entity<Eduction>()
            //.HasOne<Event>(s => s.Event)
            //.WithOne(ad => ad.Eduction)
            //.HasForeignKey<Event>(ad => ad.EductionOfId);

            //          builder.Entity<Place>()
            //.HasOne<Event>(s => s.Event)
            //.WithOne(ad => ad.Place)
            //.HasForeignKey<Event>(ad => ad.PlaceOfId);

            //            builder.Entity<Ceremony>()
            //.HasOne<Event>(s => s.Event)
            //.WithOne(ad => ad.Cermoney)
            //.HasForeignKey<Event>(ad => ad.CermoneyOfId);

            //   //Config One To  Many

            //   builder.Entity<Event>()
            //.HasOne<Users>(s => s.User)
            //.WithMany(g => g.Event)
            // ;
            ////      builder.Entity<Users>()
            ////.HasMany(c => c.Event)
            ////.WithOne(e => e.User);
            ////      ;
            ///
            builder.Entity<EventResultBank>()
                  .HasOne(p => p.Event)
                  .WithOne(i => i.EventResultBank)
                  .HasForeignKey<EventResultBank>(b => b.EventId);


            builder.Entity<Event>()
   .HasOne(e => e.User)
   .WithMany(c => c.Event);

            // builder.Entity<Users>()
            //.HasKey(pt => new { pt.Id, pt.UsersID });
            //    builder.Entity<Users>()
            //.HasOne(p => p.information)
            //.WithOne(i => i.User)
            //.HasForeignKey<Information>(b => b.UserForeignKey);

            builder.Entity<Users>()
      .HasOne<Information>(s => s.information)
      .WithOne(ad => ad.User)
      .HasForeignKey<Information>(ad => ad.UserForeignKey).OnDelete(DeleteBehavior.Cascade);


            builder.Entity<Report>()
    .HasOne(e => e.Event)
    .WithMany(c => c.ReportList);
    
    ;







            // base.OnModelCreating(builder);
        }
       
    }
   
}
