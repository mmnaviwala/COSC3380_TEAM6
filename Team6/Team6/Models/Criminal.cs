using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.EnterpriseServices;
using System.Linq;
using System.Web;

namespace Team6.Models
{

    public enum State
    {
        AL, AK, AZ, AR, CA, CO, CT, DE, FL, GA, HI, ID, IL, IN, IA, KS, KY, LA, ME, MD, MA, MI, MN, MS, MO, MT, NE, NV, NH, NJ, NM, NY, NC, ND, OH, OK, OR, PA, RI, SC, SD, TN, TX, UT, VT, VA, WA, WV, WI, WY
    }

    public enum Gender
    {
        Male, Female
    }

    public enum EyeColor
    {
	    Amber, Blue, Brown, Gray, Green, Hazel
    }

    public enum HairColor
    {
	    Black, Brown, Red, Blonde, Grey, White, Bald
    }

    public enum Race
    {
	    [Description("American Indian / Alaska Native")]
	    AmericanIndianAlaskaNative,
	    Asian,
	    [Description("Black / African American")]
	    BlackAfricanAmerican,
	    Hispanic,
	    [Description("Native Hawaiian / Pacific Islander")]
	    NativeHawaiianPacificIslander,
	    White
    }
    public class Criminal
    {
        public int CriminalID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public EyeColor? EyeColor { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
        public Gender? Gender { get; set; }
        public int Ssn { get; set; }
        public string Alias { get; set; }
        public HairColor? HairColor { get; set; }
        public string KnownAffiliates { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Race? Race { get; set; }
        public string Address { get; set; }
        public State? State { get; set; }
        public int ZipCode { get; set; }
        public int PhoneNumber { get; set; }
        public string misc { get; set; }
    }
}