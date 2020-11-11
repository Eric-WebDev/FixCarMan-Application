using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserProfile.Model
{
    public class User
    {
      
        public int UserId { get; set; }
      
        public string FirstName { get; set; }
       
        public string LastName { get; set; }
     
        public string CompanyName { get; set; }
       
        public string ProfileDescription { get; set; }
      
        public string Email { get; set; }
     
        public string PhoneNumber { get; set; }
    
        public string URL { get; set; }
      
        public DateTime? Birthday { get; set; }
     
        public string Street { get; set; }
      
        public string City { get; set; }
      
        public string County { get; set; }
      
        public string ZipCode { get; set; }
   
        public bool IsUserGarage { get; set; }
    }
}
