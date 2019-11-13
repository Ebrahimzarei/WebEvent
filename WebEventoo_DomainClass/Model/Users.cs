using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace WebEventoo_DomainClasses.Model
{
    public class AppIdentityRole : IdentityRole
    { 

    }
    public class Users : IdentityUser
    {
        public enum UserType
        {
            [DisplayName("کاربران استفاده کننده")]
            UserApp,
            [DisplayName("کاربران صاحب  رویداد")]
            UserEvent,
            [DisplayName("کاربر وب")]
            UserWeb
        }
        public Users()
        {
          //  Event = new HashSet<Event>();
        }
        
   
        [DisplayName("نام ")]
        public string FirstName { get; set; }
        public int tested { get; set; }
        [DisplayName("نام خانوادگی")]
        public string LastName { get; set; }
        [DisplayName("کاربر ها")]
        public UserType Type { get; set; }
        [DisplayName("کاربران استفاده کننده")]
        public Guid KeyUserApp { get; set; }
        [DisplayName("شماره تلفن")]
        public string Tellephone { get; set; }
        [DisplayName("رمز عبور")]
        public string Password { get; set; }
        
        [DataType(DataType.EmailAddress)]
        [DisplayName("آدرس ایمیل")]
        public string EmailUser { get; set; }
        public int UsersOfId { get; set; }
        public virtual  ICollection<Event> Event { get; set; }
        public ICollection<Comment> Comment { get; set; }
        public Information information { get; set; }
 

    }
}
