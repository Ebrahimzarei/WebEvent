using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebEventoo_DomainClasses.Model;

namespace WebEvento.Data
{
    public class Seeder
    { 
        private readonly Data.WebDbContext _context;
        public readonly UserManager<Users> _userManager;
        public Seeder(WebDbContext context, UserManager<Users> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task Seed()
        {
            _context.Database.EnsureCreated();
            var user = await _userManager.FindByEmailAsync("BytZahra@Gmail.com");
            if (user.FirstName == null)
            {
                user = new Users()
                {
                    
                    FirstName = "Ebrahim",
                    LastName = "Zare",
                    Type=Users.UserType.UserWeb,
                   
                  UserName = "Ebrahim@Gmail.Com",
                   // Email = "Ebrahim@Gmail.com"
                };
            //var result = await _userManager.CreateAsync(user, "P@ssw0rd!");
            //    if (result != IdentityResult.Success)
            //    {
            //        throw new InvalidOperationException("Failed to create default user");
            //    }
            }
            
            
           // await _context.SaveChangesAsync();
        }
    }
}
