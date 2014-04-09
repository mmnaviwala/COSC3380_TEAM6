using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Team6.Models
{
    public class Officer
    {
        public int OfficerID { get; set; }
        public int BadgeNumber { get; set; }
        public int Rank { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public int Ssn { get; set; }
        public int EyeColor { get; set; }
        public int Feet { get; set; }
        public int Inches { get; set; }
        public int Gender { get; set; }
    }
}