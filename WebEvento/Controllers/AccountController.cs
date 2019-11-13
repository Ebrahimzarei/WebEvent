using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using WebEvento.Data;
using WebEventoo_DomainClasses.Model;
 

namespace WebEvento.Controllers
{
    

    public class AccountController :Controller

    {
        private readonly  WebDbContext _context;
        public readonly UserManager<Users> _userManager;
        private readonly SignInManager<Users> signInManager;
        ViewModel.InformationViewModel Vmodel;
        private readonly IEmailSender emailSender;
        bool isAjax;
        public AccountController(WebDbContext context,IEmailSender emailSender, UserManager<Users> userManager, SignInManager<Users> signInManager)
        {
            this.signInManager = signInManager;
            _context = context;
            _userManager = userManager;
            Vmodel = new ViewModel.InformationViewModel();
            this.emailSender = emailSender;
            _context.Database.EnsureCreated();
        }
        public IActionResult Login()
        {
        
           
            return View(Vmodel);
        }
        [Microsoft.AspNetCore.Mvc.HttpPost]
        public async Task<IActionResult> Login(ViewModel.InformationViewModel Vmodel )
        {
             isAjax = HttpContext.Request.IsAjax("POST");  
            //test ajax

            if (isAjax)
            {
                if (ModelState.IsValid)
                {
                    string Username = Vmodel.Users.UserName;
                    string Password = Vmodel.Users.Password;
                    var result = await this.signInManager.PasswordSignInAsync(
          Username, Password,
           isPersistent: false, lockoutOnFailure: false);
                    if (result.Succeeded)
                    {

                        return Json( new { Succeeded = true },serializerSettings:new Newtonsoft.Json.JsonSerializerSettings());
                    }  
                    else
                    {
                        //    bool notactive = false;
                        return Json(new { Succeeded = false }, serializerSettings: new Newtonsoft.Json.JsonSerializerSettings());
                    }



                }
            }



            return new JsonResult("خطا در درخواست!");
        }
        [Authorize]
        public IActionResult Index()
        {

            ModelState.Clear();
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(ViewModel.InformationViewModel Vmodel)
        {

            isAjax = HttpContext.Request.IsAjax("POST");


            if (isAjax)
            {
              //  DateTime dt = new DateTime();
              
                if (ModelState.IsValid)
                {
                    var user = new Users
                    {
                        UserName = Vmodel.Users.UserName,
                        Password = Vmodel.Users.Password,
                     //   Email = Vmodel.Users.Email,
                     EmailUser=Vmodel.Users.EmailUser,
                     EmailConfirmed=true,
                     
                     //Email= Vmodel.Users.EmailUser,
                        Type =Users.UserType.UserWeb,
             
                      
                        
                    };
                    try
                    {
                        var result = await this._userManager.CreateAsync(user, Vmodel.Users.Password);
                        if (result.Succeeded)
                        {
                            //  await signInManager.SignInAsync(user, false);
                            return new JsonResult("ثبت نام شما با موفقیت انجام شد");

                        }
                    }
                    catch (Exception ex)
                    {

                        string e = ex.Message;
                    }
                   

                  

                }
            }
      
            return new JsonResult("خطا در ارسال درخواست" ) ;
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
                return new JsonResult("خطا در ارسال اطلاعات");
            var user = await this._userManager.FindByIdAsync(userId);
            if (user == null)
                return new JsonResult("چنین کاربری در دیتابیس یافت نشد");
            var result = await this._userManager.ConfirmEmailAsync(user, code);
            if (result.Succeeded)
            { 
                return new JsonResult("ثبت نام با موفقیت انجام شد لطفا به صفحه ورود مراجعه کنید");
            }
            return new JsonResult("خطا در ارسال اطلاعات");
        }
        //Forget
        [HttpGet]
        public IActionResult ForgetPassword()
        {

            return View();
         
        }
      
        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ViewModel.InformationViewModel Vmodel)
        {

            isAjax = HttpContext.Request.IsAjax("POST");
            if (isAjax)
            {
                if (ModelState.IsValid)
                {

                    var user = await _userManager.FindByNameAsync(Vmodel.Users.UserName);
                    if (user==null)
                    {
                        return Json(new { Succeeded = false,Message="چنین کاربری یافت نشد" }, serializerSettings: new Newtonsoft.Json.JsonSerializerSettings());
                  
                    }
                    var newPassword = _userManager.PasswordHasher.HashPassword(user, Vmodel.Users.Password);
                    user.PasswordHash = newPassword;
                    user.Password = Vmodel.Users.Password;
                    var res = await _userManager.UpdateAsync(user);
                    if (res.Succeeded) {
                        return Json(new { Succeeded = true, Message = " تغییر رمز عبور با موفقیت انجام شد" }, serializerSettings: new Newtonsoft.Json.JsonSerializerSettings());

                    }
                    else { /**/
                        return Json(new { Succeeded = false, Message = "خطا در عملیات" }, serializerSettings: new Newtonsoft.Json.JsonSerializerSettings());


                    }
                }
            }
            return Json(new { Succeeded = false, Message = "خطا در عملیات" }, serializerSettings: new Newtonsoft.Json.JsonSerializerSettings());

        }
        public async Task<IActionResult> Logout()
        {
            
            await signInManager.SignOutAsync();
            return RedirectToAction("Login","Account");
        }

    }
   

  
}