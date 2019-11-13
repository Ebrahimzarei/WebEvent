using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pioneer.Pagination;
using WebEvento.Data;
using WebEventoo_DomainClasses.Services;
using WebExhibitionoo_DomainClasses.Services;

namespace WebEvento.Controllers
{/// <summary>
/// جستجو
/// </summary>
    public class FindController : Controller
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
        private readonly IPaginatedMetaService _paginatedMetaService;
        public FindController(
            IPaginatedMetaService paginatedMetaService,
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
            FAddressServices = Address;
            FCermoneyServices = Cermoney;
            FColorServices = Color;
            FCommentServices = Comment;
            FEductionServices = Eduction;
            FEventServices = Event;
            FExhibitionServices = Exhibition;
            FInformtionSErvices = Information;
            FPlacesServices = Place;
            context = Context;
            _paginatedMetaService = paginatedMetaService;



        }
        public IActionResult Index()
        {
            return View();
        }
        //نمایشگاه
        [HttpGet]
        public async Task<IActionResult> FindExhibition(int page = 1)
        {
            var Date = await FExhibitionServices.GetAllExhibitionAsync();
            var Obj = new WebEvento.ViewModel.InformationViewModel();
            Obj.ExhibitionList = Date.ToList();
            var totalNumberInCollection = Obj.ExhibitionList.Count;
            var itemsPerPage = 5;
            ViewBag.PaginatedMeta = _paginatedMetaService.GetMetaData(totalNumberInCollection, page, itemsPerPage);

            return View(Obj);
        }
        //آدرس
        [HttpGet]
        public async Task<IActionResult> FindAddress()
        {
            var Date = await FAddressServices.GetAllAddressAsync();
            var Obj = new WebEvento.ViewModel.InformationViewModel();
            Obj.AddressList = Date.ToList();
    

            return View(Obj);
        }
        // 
        //ویژه کردن رویداد
        [HttpGet]
        public async Task<IActionResult> SpecialEvent()
        {
            var Date = await FEventServices.GetAllEventListAsync();
            var Obj = new WebEvento.ViewModel.InformationViewModel();
            Obj.EventList = Date.ToList();


            return View(Obj);
        }
        //ویژه کردن رویداد
     
        public async Task<IActionResult> SpecialEvents(int? Id)
        {
            if (Id==null)
            {
                return NotFound();
            }
            ViewModel.InformationViewModel Vmodel = new ViewModel.InformationViewModel();

            Vmodel.Event = await FEventServices.GetEventAsync(Id);
            Vmodel.Event.Statusevent = WebEventoo_DomainClasses.Model.Event.StatuseEvent.Special;
            await FEventServices.UpdateAsync(Vmodel.Event);
            return RedirectToAction("Index");
        }
        //آموزش
        [HttpGet]
        public async Task<IActionResult> FindEduction(int page = 1)
        {
            var Date = await FEductionServices.GetAllEductionAsync();
            var Obj = new WebEvento.ViewModel.InformationViewModel();
            Obj.EductionList = Date.ToList();
            var totalNumberInCollection = Obj.EductionList.Count;
            var itemsPerPage = 5;
            ViewBag.PaginatedMeta = _paginatedMetaService.GetMetaData(totalNumberInCollection, page, itemsPerPage);

            return View(Obj);
        }
        //مکان
        [HttpGet]
        public async Task<IActionResult> FindPlace(int page = 1)
        {
            var Date = await FPlacesServices.GetAllPlaceAsync();
            var Obj = new WebEvento.ViewModel.InformationViewModel();
            Obj.PlaceList = Date.ToList();
            var totalNumberInCollection = Obj.PlaceList.Count;
            var itemsPerPage = 5;
            ViewBag.PaginatedMeta = _paginatedMetaService.GetMetaData(totalNumberInCollection, page, itemsPerPage);

            return View(Obj);
        }
        //کاربران
        //[HttpGet]
        //public async Task<IActionResult> FindUser(int page = 1)
        //{
        //    var Date = await FPlacesServices.GetAllPlaceAsync();
        //    var Obj = new WebEvento.ViewModel.InformationViewModel();
        //    Obj.PlaceList = Date.ToList();
        //    var totalNumberInCollection = Obj.ExhibitionList.Count;
        //    var itemsPerPage = 5;
        //    ViewBag.PaginatedMeta = _paginatedMetaService.GetMetaData(totalNumberInCollection, page, itemsPerPage);

        //    return View(Obj);
        //}
      
       // مراسم و همایش
        [HttpGet]
        public async Task<IActionResult> FindCermoney(int page = 1)
        {
            var Date = await FCermoneyServices.GetAllCermoneyAsync();
            var Obj = new WebEvento.ViewModel.InformationViewModel();
            Obj.CermoneyList = Date.ToList();
            var totalNumberInCollection = Obj.CermoneyList.Count;
            var itemsPerPage = 5;
            ViewBag.PaginatedMeta = _paginatedMetaService.GetMetaData(totalNumberInCollection, page, itemsPerPage);

            return View(Obj);
        }
        [HttpGet]
        public async Task<IActionResult> FindComments(int page = 1)
        {
            //var Date = await FCommentServices.GetAllCommentAsync();
            //var Obj = new WebEvento.ViewModel.InformationViewModel();
            //Obj.com = Date.ToList();
            //var totalNumberInCollection = Obj.ExhibitionList.Count;
            //var itemsPerPage = 5;
            //ViewBag.PaginatedMeta = _paginatedMetaService.GetMetaData(totalNumberInCollection, page, itemsPerPage);

            return View();
        }
        [HttpGet]
        public async Task<IActionResult> FindInformation(int page = 1)
        {
            var Date = await FInformtionSErvices.GetAllInformationAsync();
            var Obj = new WebEvento.ViewModel.InformationViewModel();
            Obj.InformationList = Date.ToList();
            var totalNumberInCollection = Obj.InformationList.Count;
            var itemsPerPage = 5;
            ViewBag.PaginatedMeta = _paginatedMetaService.GetMetaData(totalNumberInCollection, page, itemsPerPage);

            return View(Obj);
        }
        
                [HttpGet]
        public async Task<IActionResult> FindColor(int page = 1)
        {
            var Date = await FColorServices.GetAllColorsAsync();
            var Obj = new WebEvento.ViewModel.InformationViewModel();
            Obj.ColorList = Date.ToList();
            var totalNumberInCollection = Obj.ColorList.Count;
            var itemsPerPage = 5;
            ViewBag.PaginatedMeta = _paginatedMetaService.GetMetaData(totalNumberInCollection, page, itemsPerPage);

            return View(Obj);
        }

        //  FindEvents
        //تایید جهت ارسال
        public async Task<IActionResult> Confirm(int Id )
        {
            if (Id == null)
            {
                return NotFound();
            }
            ViewModel.InformationViewModel Vmodel = new ViewModel.InformationViewModel();

            Vmodel.Event= await FEventServices.GetEventAsync(Id);
            Vmodel.Event.Statusevent = WebEventoo_DomainClasses.Model.Event.StatuseEvent.Published;
            await FEventServices.UpdateAsync(Vmodel.Event);
            return RedirectToAction("Index");


        }
        //نیاز به ویرایش
        public async Task<IActionResult> IsEdit(int Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            ViewModel.InformationViewModel Vmodel = new ViewModel.InformationViewModel();

            Vmodel.Event = await FEventServices.GetEventAsync(Id);
            Vmodel.Event.Statusevent = WebEventoo_DomainClasses.Model.Event.StatuseEvent.IsEdit;
            await FEventServices.UpdateAsync(Vmodel.Event);
            return RedirectToAction("Index");


        }
        [HttpGet]
        public async Task<IActionResult> FindEvents(int page = 1)
        {
            var Date = await FEventServices.GetAllEventAsync();
            var Obj = new WebEvento.ViewModel.InformationViewModel();
            Obj.EventList = Date.ToList();
            var dt2 = DateTime.Now;
            foreach (var item in Obj.EventList)
            {
                var dt = item.EventNow.Date;
            
              
                TimeSpan ts = (dt2 - dt);
                Obj.PeriodEventTime = new List<string>();
                Obj.PeriodEventTime.Add(ts.ToString(@"hh\:mm\:ss"));
            }
            var totalNumberInCollection = Obj.EventList.Count;
            var itemsPerPage = 5;
            ViewBag.PaginatedMeta = _paginatedMetaService.GetMetaData(totalNumberInCollection, page, itemsPerPage);


            return View(Obj);
        }

    
    }
}