using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using WebEvento.Data;
using WebEvento.Data.Services;

using WebEvento.ViewModel;
using WebEventoo_DomainClasses.Services;
using WebExhibitionoo_DomainClasses.Services;

namespace WebEvento.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    public class HomeController : Controller
    {
        public static List<string> lstImage;
        readonly IAddresServices FAddressServices;
        readonly WebEventoo_DomainClasses.Services.IExhibitionServices FCermoneyServices;
        readonly IColorService FColorServices;
        readonly ICommentService FCommentServices;
        readonly IEductionservices FEductionServices;
        readonly IEventServices FEventServices;
        readonly WebExhibitionoo_DomainClasses.Services.IExhibitionServices FExhibitionServices;
        readonly IInformationService FInformtionSErvices;
        readonly IPlaceServices FPlacesServices;
        readonly IReportServices FreportServices;
        private readonly WebDbContext context;
        private static string Message;
        public static double lattiude, longtiude;
        private readonly IHostingEnvironment _hostingEnvironment;
        bool isAjax;
        public static InformationViewModel vm;

        public IActionResult IndexFromAccount()
        {
         
            return View();
        }
        public IActionResult Index()
        {
          ViewBag.Message = Message;
            return View();
        }

        public HomeController(
            WebDbContext Context,
            IAddresServices Address,
            WebEventoo_DomainClasses.Services.IExhibitionServices Cermoney,
            IColorService Color,
            ICommentService Comment,
            IEductionservices Eduction,
            IEventServices Event,
            WebExhibitionoo_DomainClasses.Services.IExhibitionServices Exhibition,
            IInformationService Information,
            IHostingEnvironment hostingEnvironment,
            IReportServices ReportServices,
            IPlaceServices Place)
        {
            FAddressServices = Address;
            FCermoneyServices = Cermoney;
            FColorServices = Color;
            FCommentServices = Comment;
            FEductionServices = Eduction;
            FEventServices = Event;
            FExhibitionServices = Exhibition;
            FInformtionSErvices = Information;
            FPlacesServices = Place;
            FreportServices = ReportServices;
            context = Context;

            this._hostingEnvironment = hostingEnvironment;


        }
        [HttpPost]
        public void GetMap(string lat, string longi)
        {


            lattiude = Convert.ToDouble(lat, CultureInfo.InvariantCulture);
            longtiude = Convert.ToDouble(longi, CultureInfo.InvariantCulture);


        }
        [HttpGet]
        public IActionResult Address()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Address(ViewModel.InformationViewModel viewmodel)
        {
            isAjax = HttpContext.Request.IsAjax("POST");
            if (isAjax)
            {
                if (ModelState.IsValid)
                {
                    WebEventoo_DomainClasses.Model.Address address = new WebEventoo_DomainClasses.Model.Address
                    {
                        AddressTwo = viewmodel.Adress.AddressTwo,
                        CaptionAddress = viewmodel.Adress.CaptionAddress,
                        Name = viewmodel.Adress.Name,
                        Lattiude = lattiude,
                        Longtiude = longtiude

                    };
                    await FAddressServices.AddAsync(address);
                    // Message = string.Format("Ok!");

                    return new JsonResult("ادرس با موفقیت ذخیره شد");


                }

            }

            return new JsonResult(" خطا در ثبت عملیات");

        }

        [HttpGet]
        public IActionResult Exhibition()
        {
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Exhibition(ViewModel.InformationViewModel viewmodel)
        {
            isAjax = HttpContext.Request.IsAjax("POST");
            if (isAjax)
            {
                if (ModelState.IsValid)
                {
                    await FExhibitionServices.AddAsync(viewmodel.Exhibition);

                    return new JsonResult("ادرس با موفقیت ذخیره شد");



                }
            }

            return new JsonResult("خطا در ثبت عملیات");


        }
        public IActionResult Eduction()
        {
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> Eduction(ViewModel.InformationViewModel vmodel)
        {
            isAjax = HttpContext.Request.IsAjax("POST");
            if (isAjax)
            {

                if (ModelState.IsValid)
                {
                    await FEductionServices.AddAsync(vmodel.Eduction);
                    return new JsonResult("ادرس با موفقیت ذخیره شد");
                }

            }
            return new JsonResult(" خطا در ثبت عملیات");


        }
        [HttpGet]
        public IActionResult Place()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Place(ViewModel.InformationViewModel vmodel)
        {
            isAjax = HttpContext.Request.IsAjax("POST");
            if (isAjax)
            {
                if (ModelState.IsValid)
                {
                    await FPlacesServices.AddAsync(vmodel.Place);
                    return new JsonResult("عملیات با موفقیت ذخیره شد");
                }
            }

            return new JsonResult("خطا در ثبت عملیات");
        }
        [HttpGet]
        public IActionResult Users()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Users(InformationViewModel viewModel)
        {
            if (ModelState.IsValid)
            {

            }
            return View();
        }
        [HttpGet]
        public IActionResult Cermoney()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Cermoney(ViewModel.InformationViewModel viewModel)
        {
            isAjax = HttpContext.Request.IsAjax("POST");
            if (isAjax)
            {
                if (ModelState.IsValid)
                {
                    await FCermoneyServices.AddAsync(viewModel.Cermoney);
                    return new JsonResult("عملیات با موفقیت ذخیره شد");
                }


            }
            return new JsonResult(" خطا در ثبت عملیات");
        }

        [HttpPost]
        public async Task<IActionResult> Comment(ViewModel.InformationViewModel vmodel)
        {
            if (ModelState.IsValid)
            {
                await FCommentServices.AddAsync(vmodel.Comment);
            }
            return View();
        }
        public IActionResult Colors()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Colors(ViewModel.InformationViewModel vmodel)
        {
            isAjax = HttpContext.Request.IsAjax("POST");
            if (isAjax)
            {
                if (ModelState.IsValid)
                {
                    await FColorServices.AddAsync(vmodel.Colors);
                    return new JsonResult("عملیات با موفقیت ذخیره شد");

                }

            }
            return new JsonResult("خطا در ثبت عملیات");
        }
        [HttpGet]
        public IActionResult Information()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Information(ViewModel.InformationViewModel vmodel)
        {
            isAjax = HttpContext.Request.IsAjax("POST");
            if (isAjax)
            {

                if (ModelState.IsValid)
                {
                    await FInformtionSErvices.AddAsync(vmodel.Information);
                    return new JsonResult("عملیات با موفقیت ذخیره شد");
                }


            }
            return new JsonResult("خطا در ثبت عملیات");
        }
        public IActionResult Event()
        {
            var vm = new ViewModel.InformationViewModel();

            var Exhibition = context.Exhibition.OrderBy(c => c.Name).Select(x => new { Id = x.Id, Value = x.Name, x.Type }).ToList();
            vm.Select = new SelectList(Exhibition, "Id", "Value");
            var Eduction = context.Eduction.OrderBy(c => c.Name).Select(x => new { Id = x.Id, Value = x.Name }).ToList();
            vm.SelectEduction = new SelectList(Eduction, "Id", "Value");
            var Place = context.Place.OrderBy(c => c.Name).Select(x => new { Id = x.Id, Value = x.Name }).ToList();
            vm.SelectPlace = new SelectList(Place, "Id", "Value");
            var Address = context.Address.OrderBy(c => c.Name).Select(x => new { Id = x.Id, Value = x.Name }).ToList();
            vm.SelectAddress = new SelectList(Address, "Id", "Value");
            var Cermoney = context.Cermoney.OrderBy(c => c.Name).Select(x => new { Id = x.Id, Value = x.Name }).ToList();
            vm.SelectCermoney = new SelectList(Cermoney, "Id", "Value");



            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Event(ViewModel.InformationViewModel vmodel, IList<IFormFile> files)
        {
            if (ModelState.IsValid)
            {
                int? Exhibition;
                int? Eduction;
                int? Place;
                int? Address, Cermoney;


              

                    vmodel.Event.EventNow = DateTime.Now;
                    vmodel.Event.StatuseChecked = true;
                    vmodel.Event.StatuseEnter = true;
                    vmodel.Event.Statusevent = WebEventoo_DomainClasses.Model.Event.StatuseEvent.Published;
                

                if (files == null || files.Count == 0)
                {
                    return BadRequest();
                }
                vmodel.Event.Image = new List<WebEventoo_DomainClasses.Model.Images>();
                using (var ms = new MemoryStream())
                {
                    foreach (var item in files)
                    {

                        item.CopyTo(ms);
                        var ArrayImage = ms.ToArray();


                        vmodel.Event.Image.Add(new WebEventoo_DomainClasses.Model.Images() { ImageData = ArrayImage, NameImage = item.FileName });

                     

                       // vmodel.Event.Image = vmodel.Image;
                    }

                }
                Exhibition = int.Parse(vmodel.ExhibitionCode);
                    // Eduction = int.Parse(vmodel.EductionCode);
                    Place = int.Parse(vmodel.PlaceCode);
                    Address = int.Parse(vmodel.AddressCode);
                    Cermoney = int.Parse(vmodel.CermoneyCode);
                    //if (Exhibition >= 1)
                    //{
                        // var ex = context.Exhibition.Where(x => x.Id == Exhibition).Select(x=>new {x.Name,x.Type }).ToList();
                        //// vmodel.Event.Exhibotion = ex;
                        vmodel.Event.Exhibotion = context.Exhibition.ToList().Where(x => x.Id == Exhibition).ToList();
                        vmodel.Event.Place = context.Place.ToList().Where(x => x.Id == Place).ToList();
                        vmodel.Event.Address = context.Address.ToList().Where(x => x.Id == Address).ToList();
                        vmodel.Event.Cermoney = context.Cermoney.ToList().Where(x => x.Id == Cermoney).ToList();
                      //  var xdfdfdf = vmodel.Event;


                        await FEventServices.AddAsync(vmodel.Event);

                        Message = string.Format("Ok!");
                        // return View("Event");
                        return RedirectToAction("Index");

                 //   }


            }
            return View();

        }

        [HttpPost]
        public IActionResult UploadFilesAjax()
        {


            vm = new ViewModel.InformationViewModel();
            var file = Request.Form.Files;

            using (var ms = new MemoryStream())
            {
                foreach (var item in file)
                {

                    item.CopyTo(ms);
                    var ArrayImage = ms.ToArray();
                    vm.Image = new List<WebEventoo_DomainClasses.Model.Images>
                    {
                        new WebEventoo_DomainClasses.Model.Images
                        {
                            Id=file.Count,
                            ImageData=ms.ToArray(),
                            NameImage=item.Name
                        }
                    };
                }

            }
            string message = $" فایل با موفقیت اپلود شد!";
            return Json(message);

        }
        public async Task<IActionResult> EventReport()
        {
            var vm = new ViewModel.InformationViewModel();
            // await FInformtionSErvices.AddAsync(vmodel.Information);
            var x = await FreportServices.GetAllReportAsync();
            if (x.Any())
            {
                ViewBag.Error = true;
                foreach (var item in x)
                {
                    vm.ReportList.Add(new WebEventoo_DomainClasses.Model.Report
                    {
                        Event = item.Event,
                        RoleReport = WebEventoo_DomainClasses.Model.Report.TypeReport.ReportEvent,

                        CaptionReport = item.CaptionReport

                    });
                    if (vm.ReportList.Count < 0)
                    {
                        ViewBag.Count = 0;
                    }
                    if (vm.ReportList.Count > 0)
                    {
                        ViewBag.Count = vm.ReportList.Count;
                    }
                    return View(vm);
                }
            }
            ViewBag.Error = false;
            return View(vm);
        }
        public async Task<IActionResult> Comments()
        {
            var vm = new ViewModel.InformationViewModel();
            // await FInformtionSErvices.AddAsync(vmodel.Information);
            var comment = await FCommentServices.GetAllCommentAsync();
            if (comment.Any())
            {
                ViewBag.Error = true;
                foreach (var item in comment)
                {
                    vm.CommentnList.Add(new WebEventoo_DomainClasses.Model.Comment
                    {
                        Event = item.Event,
                        CaptionComment = item.CaptionComment,
                        User = item.User,
                        Id = item.Id

                    });
                }
            }
            ViewBag.Error = false;
            return View(vm);
        }
        // 
        public async Task<IActionResult> EnterComment(int? id)
        {
            ViewModel.InformationViewModel Vmodel = new InformationViewModel();
            if (id == null)
            {
                return NotFound();
            }
            Vmodel.Comment = await FCommentServices.GetCommentAsync(id);
            Vmodel.Comment.OkComment = true;
            await FCommentServices.UpdateAsync(Vmodel.Comment);
            Message = string.Format("Ok!");

            return RedirectToAction("Index");
        }

    }
}
