using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Team6.Models
{
    public class Officer
    {
        public int officerID { get; set; }
        public int badge_number { get; set; }
        public int rank { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string user_name { get; set; }
        public string paswerd { get; set; }
        public int phone_number { get; set; }
        public string email { get; set; }
        public int ssn { get; set; }
        public int eye_color { get; set; }
        public int feet { get; set; }
        public int inches { get; set; }
        public int gender { get; set; }
    }
}