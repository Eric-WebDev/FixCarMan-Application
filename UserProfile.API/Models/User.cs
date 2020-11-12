using System;


namespace UserProfile.API.Models
{
    public class User
    {
        public int Id { get; set; }

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
