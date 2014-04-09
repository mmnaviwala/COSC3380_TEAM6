using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Team6.Models
{
    public class Criminal
    {
        public int CriminalID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int EyeColor { get; set; }
        public int Weight { get; set; }
        public int Feet { get; set; }
        public int Inches { get; set; }
        public int Gender { get; set; }
        public int Ssn { get; set; }
        public string Alias { get; set; }
        public int HairColor { get; set; }
        public string KnownAffiliates { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Race { get; set; }
        public string Address { get; set; }
        public int State { get; set; }
        public int ZipCode { get; set; }
        public int PhoneNumber { get; set; }
        public string misc { get; set; }
    }
}