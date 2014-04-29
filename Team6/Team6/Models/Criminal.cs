using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Team6.Models;
using Team6.DAL;

namespace Team6.Models
{

    public enum State
    {
        [Description("None")]None,
        [Description("AL")]AL,
        [Description("AK")]AK,
        [Description("AZ")]AZ,
        [Description("AR")]AR,
        [Description("CA")]CA,
        [Description("CO")]CO,
        [Description("CT")]CT,
        [Description("DE")]DE,
        [Description("FL")]FL,
        [Description("GA")]GA,
        [Description("HI")]HI,
        [Description("ID")]ID,
        [Description("IL")]IL,
        [Description("IN")]IN,
        [Description("IA")]IA,
        [Description("KS")]KS,
        [Description("KY")]KY,
        [Description("LA")]LA,
        [Description("ME")]ME,
        [Description("MD")]MD,
        [Description("MA")]MA,
        [Description("MI")]MI,
        [Description("MN")]MN,
        [Description("MS")]MS,
        [Description("MO")]MO,
        [Description("MT")]MT,
        [Description("NE")]NE,
        [Description("NV")]NV,
        [Description("NH")]NH,
        [Description("NJ")]NJ,
        [Description("NM")]NM,
        [Description("NY")]NY,
        [Description("NC")]NC,
        [Description("ND")]ND,
        [Description("OH")]OH,
        [Description("OK")]OK,
        [Description("OR")]OR,
        [Description("PA")]PA,
        [Description("RI")]RI,
        [Description("SC")]SC,
        [Description("SD")]SD,
        [Description("TN")]TN,
        [Description("TX")]TX,
        [Description("UT")]UT,
        [Description("VT")]VT,
        [Description("VA")]VA,
        [Description("WA")]WA,
        [Description("WV")]WV,
        [Description("WI")]WI,
        [Description("WY")]WY
    }

    public enum Gender
    {
        [Description("None")]
        None,
        [Description("Male")]
        Male,
        [Description("Female")]
        Female
    }

    public enum EyeColor
    {
        [Description("None")]
        None,
        [Description("Amber")]
        Amber,
        [Description("Blue")]
        Blue,
        [Description("Brown")]
        Brown,
        [Description("Black")]
        Black,
        [Description("Grey")]
        Gray,
        [Description("Green")]
        Green,
        [Description("Hazel")]
        Hazel
    }

    public enum HairColor
    {
        [Description("None")]
        None,
        [Description("Black")]
        Black,
        [Description("Brown")]
        Brown,
        [Description("Red")]
        Red,
        [Description("Blonde")]
        Blonde,
        [Description("Grey")]
        Grey,
        [Description("White")]
        White,
        [Description("Bald")]
        Bald,
        [Description("Other")]  
        Other
    }

    public enum Race
    {
        [Description("None")] None,
        [Description("American Indian / Alaska Native")] AmericanIndianAlaskaNative,
        [Description("Asian")] Asian,
	    [Description("Black / African American")] BlackAfricanAmerican,
        [Description("Hispanic")] Hispanic,
	    [Description("Native Hawaiian / Pacific Islander")] NativeHawaiianPacificIslander,
        [Description("White")] White,
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

        [Display(Name = "Zip Code")]
        public int ZipCode { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "State")]
        public State? State { get; set; }

        [Display(Name = "Phone Number")]
        public Int64 PhoneNumber { get; set; }

        [Display(Name = "Miscellaneous")]
        public string misc { get; set; }

        [Display(Name = "Mug Shot")]
        public string image { get; set; }


        //public virtual CrimeReport CrimeReport { get; set; }
        public virtual ICollection<CrimeReport> CrimeReports { get; set; }

        public int getHighestID()
        {
            Team6Context dre = new Team6Context();
            var user = from o in dre.Criminals select o.CriminalID;
            return user.Max();

        }
    }
}