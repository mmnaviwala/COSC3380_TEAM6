using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace COSC3380_TEAM6.Models
{
    public class Officer
    {   [StringLength(6)]
        public int badge_number { get; set; }
        [StringLength(1)]
        public int rank { get; set; }
        [StringLength(30)]
        public string first_name { get; set; }
        [StringLength(30)]
        public string last_name { get; set; }
        [StringLength(15)]
        public string user_name { get; set; }
        [StringLength(20)]
        public string paswerd { get; set; }
        [StringLength(10)]
        public int phone_number { get; set; }
        [StringLength(50)]
        public string email { get; set; }
        [StringLength(12)]
        public int ssn { get; set; }
        [StringLength(1)]
        public int eye_color { get; set; }
        [StringLength(2)]
        public int feet { get; set; }
        [StringLength(2)]
        public int inches { get; set; }
        [StringLength(1)]
        public int gender { get; set; }
        
    }
}