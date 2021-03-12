using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Application.Profiles
{
    public class UserAdDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string CarModel { get; set; }
        public DateTime Date { get; set; }
    }
}
