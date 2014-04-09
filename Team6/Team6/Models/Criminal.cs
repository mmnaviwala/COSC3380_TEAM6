using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Team6.Models
{
    public class Criminal
    {
        public int criminalID { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public int eye_color { get; set; }
        public int weight { get; set; }
        public int feet { get; set; }
        public int inches { get; set; }
        public int gender { get; set; }
        public int ssn { get; set; }
        public string alias { get; set; }
        public int hair_color { get; set; }
        public string known_affiliates { get; set; }
        public DateTime date_of_birth { get; set; }
        public int race { get; set; }
        public string address { get; set; }
        public int state { get; set; }
        public int zip_code { get; set; }
        public int phone_number { get; set; }
        public string misc { get; set; }
    }
}