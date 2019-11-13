using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebEventoo_DomainClasses.Model;

namespace WebEvento.ViewModel
{
    public class InformationViewModel
    {
        public List<SelectListItem> SelectedList { set; get; }
        public SelectList Select { get; set; }
        public string ExhibitionCode { get; set; }
        public SelectList SelectExhibition { get; set; }
        public string EductionCode { get; set; }
        public SelectList SelectEduction { get; set; }
        public string PlaceCode { get; set; }
        public SelectList SelectPlace { get; set; }
        public string AddressCode { get; set; }
        public SelectList SelectAddress { get; set; }
        public string CermoneyCode { get; set; }
        public SelectList SelectCermoney { get; set; }
        public Address Adress { get; set; }
        public IEnumerable<Address> IENumarableAddress { get; set; }
        public List<Address> AddressList { get; set; }
        public Ceremony Cermoney { get; set; }
        public IEnumerable<Ceremony> IENumarableCermoney { get; set; }
        public List<Ceremony> CermoneyList { get; set; }
        public Colors Colors { get; set; }
        public List<Colors> ColorList { get; set; }
        public IEnumerable<Colors> IENumarableColors { get; set; }
        public Comment Comment { get; set; }
        public List<Comment> CommentnList { get; set; }
        public Eduction Eduction { get; set; }
        public List<Eduction> EductionList { get; set; }
        public Event Event { get; set; }
        public Exhibition Exhibition { get; set; }
        public List<Exhibition> ExhibitionList { get; set; }
        public Information Information { get; set; }
        public List<Information> InformationList { get; set; }
        public Place Place { get; set; }
        public List<Place> PlaceList { get; set; }
        public Users Users { get; set; }
        public List<Users> UsersList { get; set; }
        public List<Event> EventList { get; set; }
        public Report Report { get; set; }
        public List<Report> ReportList { get; set; }
        public List<NotPublished> NotPublishedList { get; set; }
        public  NotPublished NotPublished { get; set; }
        public List<EventResultBank> EventResultBankList { get; set; }
        public EventResultBank EventResultBank { get; set; }
        public int? StatuseCheckedviewcomponent { get; set; }
        public  List<string> PeriodEventTime { get; set; }
        public List<Images> Image { get; set; }
    
    }
}
