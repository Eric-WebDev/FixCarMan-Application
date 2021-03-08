using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Domain
{
   public class Photo
    {
        public string Id { get; set; }
        public string Url { get; set; }
        public bool IsMain { get; set; }
    }
}
