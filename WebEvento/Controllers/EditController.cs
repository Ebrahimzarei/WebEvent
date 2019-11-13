using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebEvento.Data;
using WebEventoo_DomainClasses.Services;
using WebExhibitionoo_DomainClasses.Services;

namespace WebEvento.Controllers
{
    public class EditController : Controller
    {
        readonly IAddresServices FAddressServices;
        readonly WebEventoo_DomainClasses.Services.IExhibitionServices FCermoneyServices;
        readonly IColorService FColorServices;
        readonly ICommentService FCommentServices;
        readonly IEductionservices FEductionServices;
        readonly IEventServices FEventServices;
        readonly WebExhibitionoo_DomainClasses.Services.IExhibitionServices FExhibitionServices;
        readonly IInformationService FInformtionSErvices;
        readonly IPlaceServices FPlacesServices;
        private readonly WebDbContext context;
        private static string Message;
        private static double lattiude;
        private static double longtiude;
        public EditController(
             WebDbContext Context,

           IAddresServices Address,
           WebEventoo_DomainClasses.Services.IExhibitionServices Cermoney,
           IColorService Color,
           ICommentService Comment,
           IEductionservices Eduction,
           IEventServices Event,
           WebExhibitionoo_DomainClasses.Services.IExhibitionServices Exhibition,
           IInformationService Information,
           IPlaceServices Place
            )
        {
            context = Context;
            FAddressServices = Address;
            FCermoneyServices = Cermoney;
            FColorServices = Color;
            FCommentServices = Comment;
            FEductionServices = Eduction;
            FEventServices = Event;
            FExhibitionServices = Exhibition;
            FInformtionSErvices = Information;
            FPlacesServices = Place;

        }
        public IActionResult Index()
        {
            ViewBag.Message = Message;
            return View();
        }
        [HttpPost]
        public void GetMap(string lat, string longi)
        {


            lattiude = Convert.ToDouble(lat, CultureInfo.InvariantCulture);
            longtiude = Convert.ToDouble(longi, CultureInfo.InvariantCulture);


        }
        [HttpGet]
        public async Task<IActionResult> EditAddress(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            ViewModel.InformationViewModel Vmodel = new ViewModel.InformationViewModel();

            Vmodel.Adress = await FAddressServices.GetAddressAsync(Id);
            if (Vmodel.Adress == null)
            {
                return NotFound();
            }
            return View(Vmodel);

        }
        //EditAddress
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAddress(ViewModel.InformationViewModel vmodel)
        {
            if (ModelState.IsValid)
            {
                WebEventoo_DomainClasses.Model.Address address = new WebEventoo_DomainClasses.Model.Address
                {
                    AddressTwo = vmodel.Adress.AddressTwo,
                    CaptionAddress = vmodel.Adress.CaptionAddress,
                    Name = vmodel.Adress.Name,
                    Lattiude = lattiude,
                    Longtiude = longtiude

                };
                await FAddressServices.AddAsync(address);
                Message = string.Format("Ok!");

                return RedirectToAction("Index");

            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EditExhibition(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            ViewModel.InformationViewModel Vmodel = new ViewModel.InformationViewModel();

            Vmodel.Exhibition = await FExhibitionServices.GetExhibitionAsync(Id);
            if (Vmodel.Exhibition == null)
            {
                return NotFound();
            }
            return View(Vmodel);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditExhibition(ViewModel.InformationViewModel vmodel)
        {
            if (ModelState.IsValid)
            {
                await FExhibitionServices.UpdateAsync(vmodel.Exhibition);
                Message = "Ok Edit";
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> EditCermoney(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            ViewModel.InformationViewModel Vmodel = new ViewModel.InformationViewModel();

           Vmodel.Cermoney = await FCermoneyServices.GetCermoneyAsync(Id);
          
            if (Vmodel.Cermoney == null)
            {
                return NotFound();
            }
            return View(Vmodel);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCermoney(ViewModel.InformationViewModel vmodel)
        {

            if (ModelState.IsValid)
            {
                await FCermoneyServices.UpdateAsync(vmodel.Cermoney);
                Message = "Ok Edit";
            }
            return RedirectToAction(nameof(Index));


        }
        [HttpGet]
        public async Task<IActionResult> EditColors(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            ViewModel.InformationViewModel Vmodel = new ViewModel.InformationViewModel();

            Vmodel.Colors = await FColorServices.GetColorsAsync(Id);
            if (Vmodel.Colors == null)
            {
                return NotFound();
            }
            return View(Vmodel);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditColors(ViewModel.InformationViewModel vmodel)
        {

            if (ModelState.IsValid)
            {
                await FColorServices.UpdateAsync(vmodel.Colors);
                Message = "Ok Edit";
            }
            return RedirectToAction(nameof(Index));


        }
        [HttpGet]
        
        public async Task<IActionResult> EditEduction(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            ViewModel.InformationViewModel Vmodel = new ViewModel.InformationViewModel();

            Vmodel.Eduction = await FEductionServices.GetEductionAsync(Id);
            if (Vmodel.Eduction == null)
            {
                return NotFound();
            }
            return View(Vmodel);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditEduction(ViewModel.InformationViewModel vmodel)
        {

            if (ModelState.IsValid)
            {
                await FEductionServices.UpdateAsync(vmodel.Eduction);
                Message = "Ok Edit";
            }
            return RedirectToAction(nameof(Index));


        }
        [HttpGet]
        public async Task<IActionResult> EditInformation(int? Id )
        {
            if (Id == null)
            {
                return NotFound();
            }
            ViewModel.InformationViewModel Vmodel = new ViewModel.InformationViewModel();

            Vmodel.Information = await FInformtionSErvices.GetInformationAsync(Id);
            if (Vmodel.Information == null)
            {
                return NotFound();
            }
            return View(Vmodel);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditInformation(ViewModel.InformationViewModel vmodel)
        {

            if (ModelState.IsValid)
            {
                await FInformtionSErvices.UpdateAsync(vmodel.Information);
                Message = "Ok Edit";
            }
            return RedirectToAction(nameof(Index));


        }
        [HttpGet]
        public async Task<IActionResult> EditPlace(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            ViewModel.InformationViewModel Vmodel = new ViewModel.InformationViewModel();

            Vmodel.Place = await FPlacesServices.GetPlaceAsync(Id);
            if (Vmodel.Place == null)
            {
                return NotFound();
            }
            return View(Vmodel);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPlace(ViewModel.InformationViewModel vmodel)
        {

            if (ModelState.IsValid)
            {
                await FPlacesServices.UpdateAsync(vmodel.Place);
                Message = "Ok Edit";
            }
            return RedirectToAction(nameof(Index));


        }
        [HttpGet]
        public async Task<IActionResult> EditEvent(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            ViewModel.InformationViewModel Vmodel = new ViewModel.InformationViewModel();

            Vmodel.Event = await FEventServices.GetEventAsync(Id);
            if (Vmodel.Event == null)
            {
                return NotFound();
            }
            return View(Vmodel);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditEvent(ViewModel.InformationViewModel vmodel)
        {

            if (ModelState.IsValid)
            {
                vmodel.Event.EventNow = DateTime.Now;
                vmodel.Event.StatuseChecked = true;
                vmodel.Event.StatuseEnter = true;
                await FEventServices.UpdateAsync(vmodel.Event);
                Message = "Ok Edit";
            }
            return RedirectToAction(nameof(Index));


        }
    }
}