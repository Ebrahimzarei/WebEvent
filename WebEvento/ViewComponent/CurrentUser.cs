using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebEventoo_DomainClasses.Model;

namespace WebEvento.ViewComponents
{
    public class CurrentUser: ViewComponent
    {
      //بدست اوردن نام کاربری لاگین شده
        //string UserId;
        public readonly UserManager<Users> _userManager;
        private readonly SignInManager<Users> signInManager;
        public CurrentUser(IHttpContextAccessor httpContextAccessor, UserManager<Users> userManager, SignInManager<Users> _signInManager)
        {
          
            //UserId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            _userManager = userManager;
            signInManager = _signInManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
 
            string names = await GetCurrentUser();
            return Content(names);


        }
        public async Task<string> GetCurrentUser()
        {
            var usr = await GetCurrentUserAsync();
            return usr?.UserName;
        }
        private Task<Users> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

    }
}
