using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebEvento.Data;
using WebEventoo_DomainClasses.Model;
using WebEventoo_DomainClasses.Services;

namespace WebEvento.Controllers
{
    /// <summary>
    /// ثبت عملیات
    /// </summary>
    public class OperationController : Controller
    {
        WebDbContext Dbcontext;
        ViewModel.InformationViewModel vmodel;
        IEventServices FEventServices;
        INotPublishedServices FNotPublishServices;
        ITranctionServices FTranctionServices;
        readonly ICommentService FCommentServices;

        public OperationController(WebDbContext db,
            ICommentService Comment,
            IEventServices Event,INotPublishedServices NotPublish, ITranctionServices TranctionServices)
        {
            Dbcontext = db;
            vmodel = new ViewModel.InformationViewModel();
            FNotPublishServices = NotPublish;
            FEventServices = Event;
            FTranctionServices = TranctionServices;
            FCommentServices = Comment;
        }
        /// <summary>
        /// رویداد های امروز
        /// </summary>
        /// <returns></returns>
        public IActionResult EventDay()

        {
          
            PersianCalendar pc = new PersianCalendar();
            var dtnow = DateTime.Now;

            DateTime dt = new DateTime(dtnow.Year, dtnow.Month, dtnow.Day); // یا DateTime.Now


            string PersianDate = string.Format("{0}/{1}/{2}", pc.GetYear(dt), pc.GetMonth(dt), pc.GetDayOfMonth(dt));


            var obj = Dbcontext.Event.Where(p => p.TimeEvent== PersianDate).OrderBy(x => x.TimeEvent);
            if (obj.Any())
            {
                vmodel.EventList = obj.ToList();
                ViewBag.Error = true;
                if (vmodel.EventList.Count < 0)
                {
                    ViewBag.Count = 0;
                }
                if (vmodel.EventList.Count > 0)
                {
                    ViewBag.Count = vmodel.EventList.Count;
                }

                return View(vmodel);
            }

            ViewBag.Error = false;
            return View();
        }
        /// <summary>
        /// رویداد های بررسی نشده 
        /// </summary>
        /// <returns></returns>
        public IActionResult StatuseChecked()

        {
       


            var obj = Dbcontext.Event.Where(p => p.Statusevent ==Event.StatuseEvent.NotChecked);
            if (obj.Any())
            {
                
              //  vmodel.EventList = obj.ToList();
                ViewBag.Error = true;
         
                    vmodel = new ViewModel.InformationViewModel();
                    vmodel.EventList = obj.OrderByDescending(x=>x.TimeEvent).ToList();
                var dt2 = DateTime.Now;
          
                vmodel.PeriodEventTime = new List<string>();
                foreach (var item in vmodel.EventList)
                {
                    var dt = item.EventNow.Date;


                    TimeSpan ts = (dt2 - dt);

                    vmodel.PeriodEventTime.Add(ts.ToString(@"hh\:mm\:ss"));
                }
                if (vmodel.EventList.Count < 0)
                {
                    ViewBag.Count = 0;
                }
                if (vmodel.EventList.Count > 0)
                {
                    ViewBag.Count = vmodel.EventList.Count;
                }

                return View(vmodel);
            }
            ViewBag.Error = false;
            return View(vmodel);
        }
        /// <summary>
        /// رویدادهای منتشر شده
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> PublishEvent()

        {
         var PublishEvent=  await FEventServices.GetAllEventAsync();
          var Date = PublishEvent.Where(x => x.Statusevent == Event.StatuseEvent.Published);
            if (Date.Any())
            {


          
                var dt2 = DateTime.Now;
                vmodel.EventList = Date.ToList();
                vmodel.PeriodEventTime = new List<string>();
                foreach (var item in vmodel.EventList)
                {
                    var dt = item.EventNow.Date;


                    TimeSpan ts = (dt2 - dt);
                 
                    vmodel.PeriodEventTime.Add(ts.ToString(@"hh\:mm\:ss"));
                }


                vmodel.EventList = Date.ToList() ;
                 
                ViewBag.Error = true;
                if(vmodel.EventList.Count<0)
                {
                    ViewBag.Count = 0;
                }
                if (vmodel.EventList.Count > 0)
                {
                    ViewBag.Count = vmodel.EventList.Count;
                }
             
                return View(vmodel);
            }

            ViewBag.Error = false;

            return View();

        }
        /// <summary>
        /// رویدادهای نیاز به تغییرات
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> EventEdit()

        {
            var PublishEvent = await FEventServices.GetAllEventAsync();
            var Date = PublishEvent.Where(x => x.Statusevent == Event.StatuseEvent.IsEdit);
            if (Date.Any())
            {

                vmodel.EventList = Date.ToList();

                ViewBag.Error = true;
                var dt2 = DateTime.Now;
              
                vmodel.PeriodEventTime = new List<string>();
                foreach (var item in vmodel.EventList)
                {
                    var dt = item.EventNow.Date;


                    TimeSpan ts = (dt2 - dt);

                    vmodel.PeriodEventTime.Add(ts.ToString(@"hh\:mm\:ss"));
                }


                if (vmodel.EventList.Count < 0)
                {
                    ViewBag.Count = 0;
                }
                if (vmodel.EventList.Count > 0)
                {
                    ViewBag.Count = vmodel.EventList.Count;
                }

                return View(vmodel);
            }

            ViewBag.Error = false;

            return View();

        }
        /// <summary>
        /// رویدادهای نیاز به پرداخت
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> EventPayed()

        {
            var PublishEvent = await FEventServices.GetAllEventAsync();
            var Date = PublishEvent.Where(x => x.Statusevent == Event.StatuseEvent.Ispayed);
            if (Date.Any())
            {

                vmodel.EventList = Date.ToList();
                var dt2 = DateTime.Now;
              
                vmodel.PeriodEventTime = new List<string>();
                foreach (var item in vmodel.EventList)
                {
                    var dt = item.EventNow.Date;


                    TimeSpan ts = (dt2 - dt);

                    vmodel.PeriodEventTime.Add(ts.ToString(@"hh\:mm\:ss"));
                }

                ViewBag.Error = true;
                if (vmodel.EventList.Count < 0)
                {
                    ViewBag.Count = 0;
                }
                if (vmodel.EventList.Count > 0)
                {
                    ViewBag.Count = vmodel.EventList.Count;
                }

                return View(vmodel);
            }

            ViewBag.Error = false;

            return View();

        }
        /// <summary>
        /// رویدادهای ویژه
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> EventSpecial()

        {
            var PublishEvent = await FEventServices.GetAllEventAsync();
            var Date = PublishEvent.Where(x => x.Statusevent == Event.StatuseEvent.Special);
            if (Date.Any())
            {

             
                var dt2 = DateTime.Now;
                vmodel.EventList = Date.ToList();
                vmodel.PeriodEventTime = new List<string>();
                foreach (var item in vmodel.EventList)
                {
                    var dt = item.EventNow.Date;


                    TimeSpan ts = (dt2 - dt);

                    vmodel.PeriodEventTime.Add(ts.ToString(@"hh\:mm\:ss"));
                }

                ViewBag.Error = true;
                if (vmodel.EventList.Count < 0)
                {
                    ViewBag.Count = 0;
                }
                if (vmodel.EventList.Count > 0)
                {
                    ViewBag.Count = vmodel.EventList.Count;
                }

                return View(vmodel);
            }

            ViewBag.Error = false;

            return View();

        }
        /// <summary>
        /// رویداد های اسلایدر
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> EventSlider()

        {
            var PublishEvent = await FEventServices.GetAllEventAsync();
            var Date = PublishEvent.Where(x => x.Statusevent == Event.StatuseEvent.Slider);
            if (Date.Any())
            {

                vmodel.EventList = Date.ToList();
                var dt2 = DateTime.Now;
                vmodel.EventList = Date.ToList();
                vmodel.PeriodEventTime = new List<string>();
                foreach (var item in vmodel.EventList)
                {
                    var dt = item.EventNow.Date;


                    TimeSpan ts = (dt2 - dt);

                    vmodel.PeriodEventTime.Add(ts.ToString(@"hh\:mm\:ss"));
                }

                ViewBag.Error = true;
                if (vmodel.EventList.Count < 0)
                {
                    ViewBag.Count = 0;
                }
                if (vmodel.EventList.Count > 0)
                {
                    ViewBag.Count = vmodel.EventList.Count;
                }

                return View(vmodel);
            }

            ViewBag.Error = false;

            return View();

        }
        /// <summary>
        /// رویداد های نردبان شده
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> EventLadder()

        {
            var PublishEvent = await FEventServices.GetAllEventAsync();
            var Date = PublishEvent.Where(x => x.Statusevent == Event.StatuseEvent.Ladder);
            if (Date.Any())
            {

                vmodel.EventList = Date.ToList();
                var dt2 = DateTime.Now;
             
                vmodel.PeriodEventTime = new List<string>();
                foreach (var item in vmodel.EventList)
                {
                    var dt = item.EventNow.Date;


                    TimeSpan ts = (dt2 - dt);

                    vmodel.PeriodEventTime.Add(ts.ToString(@"hh\:mm\:ss"));
                }

                ViewBag.Error = true;
                if (vmodel.EventList.Count < 0)
                {
                    ViewBag.Count = 0;
                }
                if (vmodel.EventList.Count > 0)
                {
                    ViewBag.Count = vmodel.EventList.Count;
                }

                return View(vmodel);
            }

            ViewBag.Error = false;

            return View();

        }
        /// <summary>
        /// رویداد های نیاز به تغییرات
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> EventStatuseEdit()

        {
            var PublishEvent = await FEventServices.GetAllEventAsync();
            var Date = PublishEvent.Where(x => x.Statusevent == Event.StatuseEvent.IsEdit);
            if (Date.Any())
            {

                vmodel.EventList = Date.ToList();
                var dt2 = DateTime.Now;
             
                vmodel.PeriodEventTime = new List<string>();
                foreach (var item in vmodel.EventList)
                {
                    var dt = item.EventNow.Date;


                    TimeSpan ts = (dt2 - dt);

                    vmodel.PeriodEventTime.Add(ts.ToString(@"hh\:mm\:ss"));
                }

                ViewBag.Error = true;
                if (vmodel.EventList.Count < 0)
                {
                    ViewBag.Count = 0;
                }
                if (vmodel.EventList.Count > 0)
                {
                    ViewBag.Count = vmodel.EventList.Count;
                }

                return View(vmodel);
            }

            ViewBag.Error = false;

            return View();

        }
        /// <summary>
        /// رویداد های منتشر نشده
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> EventNotPublish()

        {
            var Date = await FNotPublishServices.GetAllAsync();
             
            if (Date.Any())
            {
                vmodel.NotPublishedList = Date.ToList();
              
                
                
              

                ViewBag.Error = true;
                if (vmodel.NotPublishedList.Count < 0)
                {
                    ViewBag.Count = 0;
                }
                if (vmodel.NotPublishedList.Count > 0)
                {
                    ViewBag.Count = vmodel.NotPublishedList.Count;
                }

               
                return View(vmodel);
            }


            ViewBag.Error = false;


            return View(vmodel);

        }

        /// <summary>
        /// رویداد های ثبت شده نیاز به تغییرات توسط موبایل
        /// </summary>
        /// <returns></returns>
        public IActionResult StatuseEnter()

        {


           var obj = Dbcontext.Event.Where(p => p.Statusevent ==Event.StatuseEvent.NotChecked).OrderBy(x => x.TimeEvent);
            if (obj.Any())
            {
               
                vmodel.EventList = obj.ToList();
                var dt2 = DateTime.Now;
              
                vmodel.PeriodEventTime = new List<string>();
                foreach (var item in vmodel.EventList)
                {
                    var dt = item.EventNow.Date;


                    TimeSpan ts = (dt2 - dt);

                    vmodel.PeriodEventTime.Add(ts.ToString(@"hh\:mm\:ss"));
                }
                ViewBag.Error = true;
                if (vmodel.EventList.Count < 0)
                {
                    ViewBag.Count = 0;
                }
                if (vmodel.EventList.Count > 0)
                {
                    ViewBag.Count = vmodel.EventList.Count;
                }
                return View(vmodel);
            }
            ViewBag.Error = false;
            return View(vmodel);
        }
        /// <summary>
        /// رویداد های پرداخت شده
        /// </summary>
        /// <returns></returns>
        public IActionResult StatusePayed()

        {


            var obj = Dbcontext.Event.Where(p => p.Payed ==WebEventoo_DomainClasses.Model.Event.Cost.AddCost).OrderBy(x => x.TimeEvent);
            if (obj.Any())
            {

                var dt2 = DateTime.Now;
               vmodel.EventList = obj.ToList();
                vmodel.PeriodEventTime = new List<string>();
                foreach (var item in vmodel.EventList)
                {
                    var dt = item.EventNow.Date;


                    TimeSpan ts = (dt2 - dt);

                    vmodel.PeriodEventTime.Add(ts.ToString(@"hh\:mm\:ss"));
                }
               
                ViewBag.Error = true;
                if (vmodel.EventList.Count < 0)
                {
                    ViewBag.Count = 0;
                }
                if (vmodel.EventList.Count > 0)
                {
                    ViewBag.Count = vmodel.EventList.Count;
                }
                return View(vmodel);
            }
            ViewBag.Error = false;
            return View(vmodel);
        }
        /// <summary>
        /// تعداد صاحب ان رویداد و شماره آنها
        /// </summary>
        /// <returns></returns>
        public IActionResult EventUser()

        {


            var obj = Dbcontext.User.Include(x=>x.Event).Where(p => p.Type ==Users.UserType.UserEvent).OrderBy(x => x.Tellephone);
            if (obj.Any())
            {
                vmodel.UsersList = obj.ToList();
                ViewBag.Error = true;
                if (vmodel.EventList.Count < 0)
                {
                    ViewBag.Count = 0;
                }
                if (vmodel.EventList.Count > 0)
                {
                    ViewBag.Count = vmodel.EventList.Count;
                }
                return View(vmodel);
            }
            ViewBag.Error = false;
            return View(vmodel);
        }
        /// <summary>
        /// تعداد کل کاربران اپ
        /// </summary>
        /// <returns></returns>
        public IActionResult UserApp()

        {


            var obj = Dbcontext.User.Where(p => p.Type == Users.UserType.UserApp);
            if (obj.Any())
            {
                vmodel.UsersList = obj.ToList();
                ViewBag.Error = true;
                if (vmodel.EventList.Count < 0)
                {
                    ViewBag.Count = 0;
                }
                if (vmodel.EventList.Count > 0)
                {
                    ViewBag.Count = vmodel.EventList.Count;
                }
                return View(vmodel);
            }
            ViewBag.Error = false;
            return View(vmodel);
        }
        /// <summary>
        /// تراکنش های ثبت شده
        /// </summary>
        /// <returns></returns>
        public IActionResult TranctionEvent()

        {
         

            var obj = Dbcontext.TranctionEvent;
            if (obj.Any())
            {
                vmodel.EventResultBankList = obj.Include(x=>x.Event).ToList();
                ViewBag.Error = true;
                if (vmodel.EventList.Count < 0)
                {
                    ViewBag.Count = 0;
                }
                if (vmodel.EventList.Count > 0)
                {
                    ViewBag.Count = vmodel.EventList.Count;
                }
                return View(vmodel);
            }
            ViewBag.Error = false;
            return View(vmodel);
        }
        /// <summary>
        /// نظرات
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> CommentsEvent()
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
                if (vmodel.CommentnList.Count < 0)
                {
                    ViewBag.Count = 0;
                }
                if (vmodel.CommentnList.Count > 0)
                {
                    ViewBag.Count = vmodel.CommentnList.Count;
                }
                return View(vmodel);
            }
            ViewBag.Error = false;
            return View(vm);
        }

        public async Task<IActionResult> Details(int id)
        {
            var Event =  await FEventServices.GetEventAsync(id);
          
            vmodel.Event = Event;

           
            return View(vmodel);
        }

        }
}