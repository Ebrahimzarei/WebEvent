using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebEvento.Data;
using WebEventoo_DomainClasses.Services;
using WebExhibitionoo_DomainClasses.Services;
using Extensions;

namespace WebEvento.Controllers
{

    public class DeleteController : Controller
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
        private INotPublishedServices FnotPublished;
        private static string Message;
        public DeleteController(
                         WebDbContext Context,

           IAddresServices Address,
           WebEventoo_DomainClasses.Services.IExhibitionServices Cermoney,
           IColorService Color,
           ICommentService Comment,
           IEductionservices Eduction,
           IEventServices Event,
           INotPublishedServices notpublish,
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
            FnotPublished = notpublish;
        }
        public IActionResult Index()
        {
            ViewBag.Message = Message;
            return View();
        }
        //DeleteAddres
        public async Task<IActionResult> DeleteAddres(int Id)
        {
            if (Id == null)
                return NotFound();
            await FAddressServices.DeleteConfirmedAsync(Id);
            Message = "Delete Ok";
            return RedirectToAction("Index");

        }
        [HttpGet]

        public async Task<IActionResult> DeletePlace(int Id)
        {
            if (Id == null)
                return NotFound();
            await FPlacesServices.DeleteConfirmedAsync(Id);
            Message = "Delete Ok";
            return RedirectToAction("Index");

        }
        [HttpGet]
        public async Task<IActionResult> DeleteInformation(int Id)
        {
            if (Id == null)
                return NotFound();
            await FInformtionSErvices.DeleteConfirmedAsync(Id);
            Message = "Delete Ok";
            return RedirectToAction("Index");

        }
        [HttpGet]
        public async Task<IActionResult> DeleteEvent(int Id)
        {
            if (Id == null)
                return NotFound();
          
            await FEventServices.DeleteConfirmedAsync(Id);
            Message = "Delete Ok";
            return RedirectToAction("Index");

        }
        [HttpGet]
        public async Task<IActionResult> DeleteEduction(int Id)
        {
            if (Id == null)
                return NotFound();
            await FEductionServices.DeleteConfirmedAsync(Id);
            Message = "Delete Ok";
            return RedirectToAction("Index");

        }
        [HttpGet]
        public async Task<IActionResult> DeleteColor(int Id)
        {
            if (Id == null)
                return NotFound();
            await FColorServices.DeleteConfirmedAsync(Id);
            Message = "Delete Ok";
            return RedirectToAction("Index");

        }
        [HttpGet]
        public async Task<IActionResult> DeleteCermoney(int Id)
        {
            if (Id == null)
                return NotFound();
            await FCermoneyServices.DeleteConfirmedAsync(Id);
            Message = "Delete Ok";
            return RedirectToAction("Index");

        }
        [HttpGet]
        public async Task<IActionResult> DeleteExhibition(int Id)
        {
            if (Id == null)
                return NotFound();
        var Event= await FEventServices.GetEventAsync(Id);
         
          await  FnotPublished.AddAsync(new WebEventoo_DomainClasses.Model.NotPublished() { DeleteDate = DateTime.Now.ToPersianDateString(), NameEvent = Event.CaptionEvent });
            await FExhibitionServices.DeleteConfirmedAsync(Id);
            Message = "Delete Ok";
            return RedirectToAction("Index");

        }
    }
}