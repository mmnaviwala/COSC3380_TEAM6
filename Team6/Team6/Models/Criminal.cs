using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Team6.Models;

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
        [Description("American Indian / Alaska Native")] AmericanIndianAlaskaNative,
        [Description("Asian")] Asian,
	    [Description("Black / African American")] BlackAfricanAmerican,
        [Description("Hispanic")] Hispanic,
	    [Description("Native Hawaiian / Pacific Islander")] NativeHawaiianPacificIslander,
        [Description("White")] White,
        [Description("None")] None

    }

    public class Criminal
    {
        [Display(Name = "Criminal ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CriminalID { get; set; }

        [StringLength(30)]
        [Display(Name = "First Name")]
        [RegularExpression("^([a-zA-Z '-]+)$", ErrorMessage = "Invalid First Name")]
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }


        [StringLength(30)]
        [Display(Name = "Last Name")]
        [RegularExpression("^([a-zA-Z '-]+)$", ErrorMessage = "Invalid Last Name")]
        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }

        [Display(Name = "Eye Color")]
        public EyeColor? EyeColor { get; set; }

        [Display(Name = "Weight")]
        [Required(ErrorMessage = "Weight is required")]
        public int Weight { get; set; }

        [Display(Name = "Height")]
        [Required(ErrorMessage = "Height is required")]
        public int Height { get; set; }


        [Display(Name = "Gender")]
        public Gender? Gender { get; set; }

        [Display(Name = "Social Security Number")]
        [RegularExpression("^([0-9]+)$", ErrorMessage = "Invalid Social Security Number")]
        [Required(ErrorMessage = "Social Security Number is required")]
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
        [Required(ErrorMessage = "Date of Birth is required")]
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

        [Display(Name = "Mug Shot")]
        public string image { get; set; }

        [Display(Name = "alt text")]
        public string AlternateText { get; set; }

        //public virtual CrimeReport CrimeReport { get; set; }
        public virtual ICollection<CrimeReport> CrimeReports { get; set; }
    }
}