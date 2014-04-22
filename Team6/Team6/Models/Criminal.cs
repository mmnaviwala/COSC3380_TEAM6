using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Team6.Models
{

    public enum State
    {
        None, AL, AK, AZ, AR, CA, CO, CT, DE, FL, GA, HI, ID, IL, IN, IA, KS, KY, LA, ME, MD, MA, MI, MN, MS, MO, MT, NE, NV, NH, NJ, NM, NY, NC, ND, OH, OK, OR, PA, RI, SC, SD, TN, TX, UT, VT, VA, WA, WV, WI, WY
    }

    public enum Gender
    {
        None, Male, Female
    }

    public enum EyeColor
    {
	    None, Amber, Blue, Brown, Gray, Green, Hazel
    }

    public enum HairColor
    {
	    None, Black, Brown, Red, Blonde, Grey, White, Bald, Other
    }

    public enum Race
    {
<<<<<<< HEAD
	    [Description("American Indian / Alaska Native")] 
        AmericanIndianAlaskaNative,
=======
        None,
	    [Description("American Indian / Alaska Native")]
	    AmericanIndianAlaskaNative,
>>>>>>> 26661eafe53c473838c7bc41cd0f8eb6192ff3a6
	    Asian,
	    [Description("Black / African American")] BlackAfricanAmerican,
	    Hispanic,
	    [Description("Native Hawaiian / Pacific Islander")]
	    NativeHawaiianPacificIslander,
	    White
    }

    public class Criminal
    {
        [Display(Name = "Criminal ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CriminalID { get; set; }

        [StringLength(30)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [StringLength(30)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Eye Color")]
        public EyeColor? EyeColor { get; set; }

        [Display(Name = "Weight")]
        public int Weight { get; set; }

        [Display(Name = "Height")]
        public int Height { get; set; }


        [Display(Name = "Gender")]
        public Gender? Gender { get; set; }

        [Display(Name = "Social Security Number")]
        public int Ssn { get; set; }

        [Display(Name = "Alias")]
        public string Alias { get; set; }

        [Display(Name = "Hair Color")]
        public HairColor? HairColor { get; set; }

        [Display(Name = "Known Affiliates")]
        public string KnownAffiliates { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Race")]
        public Race? Race { get; set; }

        [StringLength(60)]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "State")]
        public State? State { get; set; }

        [Display(Name = "Zip Code")]
        public int ZipCode { get; set; }

        [Display(Name = "Phone Number")]
        public int PhoneNumber { get; set; }

        [Display(Name = "Miscellaneous")]
        public string misc { get; set; }


        //public virtual CrimeReport CrimeReport { get; set; }
        public virtual ICollection<CrimeReport> CrimeReports { get; set; }
    }
}