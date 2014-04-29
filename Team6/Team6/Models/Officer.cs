using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Team6.DAL;

namespace Team6.Models
{
    public enum Rank
    {
        [Description("None")]
        None,
        [Description("Chief of police")]
        ChiefOfPolice,
        [Description("Assistant Chief")]
        AssistantChief,
        [Description("Deputy Chief")]
        DeputyChief,
        [Description("Captain")]
        Captain,
        [Description("Lieutenant")]
        Lieutenant,
        [Description("Sergeant")]
        Sergeant,
        [Description("Detective")]
        Detective,
        [Description("Officer")]
        Officer,
        [Description("Inspector")]
        Inspector,
        [Description("Colonel")]
        Colonel,
        [Description("Major")]
        Major
    }

    public class Officer
    {
        [Display(Name = "Officer ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OfficerID { get; set; }

        [Display(Name = "Badge Number")]
        [RegularExpression("^([0-9]+)$", ErrorMessage = "Invalid Badge Number")]
        [Required(ErrorMessage = "Badge Number is required")]
        public int BadgeNumber { get; set; }

        [Display(Name = "Rank")]
        public Rank? Rank { get; set; }

        [StringLength(30)]
        [Display(Name = "First Name")]
        [RegularExpression("^([a-zA-Z '-]+)$", ErrorMessage = "Invalid First Name")]
        [Required(ErrorMessage="First Name is required")]
        public string FirstName { get; set; }

        [StringLength(30)]
        [Display(Name = "Last Name")]
        [RegularExpression("^([a-zA-Z '-]+)$", ErrorMessage = "Invalid Last Name")]
        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }

        [StringLength(15)]
        [Display(Name = "User Name")]
        [Required(ErrorMessage = "User Name is required")]
        public string UserName { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Phone Number")]
        [RegularExpression("^([0-9]+)$", ErrorMessage = "Invalid Phone Number")]
        [Required(ErrorMessage = "Phone Number is required")]
        public Int64 PhoneNumber { get; set; }

        [StringLength(50)]
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Display(Name = "Social Security Number")]
        [RegularExpression("^([0-9]+)$", ErrorMessage = "Invalid Badge Number")]
        [Required(ErrorMessage = "Social Security Number is required")]
        public int Ssn { get; set; }

        [Display(Name = "Eye Color")]
        public EyeColor? EyeColor { get; set; }

        [Display(Name = "Height")]
        [Required(ErrorMessage = "Height is required")]
        public int Height { get; set; }

        [Display(Name = "Gender")]
        public Gender? Gender { get; set; }



        //public virtual CrimeReport CrimeReport { get; set; }
        public virtual ICollection<CrimeReport> CrimeReports { get; set; }

        public string getUserPassword(string userLogIn)
        {
            Team6Context dre = new Team6Context();
            var user = from o in dre.Officers where o.UserName == userLogIn select o;
            if (user.ToList().Count > 0)
                return user.First().Password;
            else
                return string.Empty;

        }
        public string getUserRank(string userLogIn)
        {
            Team6Context dre = new Team6Context();
            var user = from o in dre.Officers where o.UserName == userLogIn select o;
            if (user.ToList().Count > 0)
                return user.First().Rank.ToString();
            else
                return string.Empty;

        }
    }
}