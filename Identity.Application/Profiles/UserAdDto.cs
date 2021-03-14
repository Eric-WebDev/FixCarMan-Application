using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Application.Profiles
{
    public class UserAdDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string CarModel { get; set; }
        public DateTime Date { get; set; }
        public bool IsAdvertCreator { get; set; }
        public string AdvertiserUsername { get; set; }
    }
}
