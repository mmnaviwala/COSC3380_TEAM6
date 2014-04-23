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
        None,
        [Description("Chief of police")]
        ChiefOfPolice,
        [Description("Assistant Chief")]
        AssistantChief,
        [Description("Deputy Chief")]
        DeputyChief,
        Captain,
        Lieutenant,
        Sergeant,
        Detective,
        Officer,
        Inspector,
        Colonel,
        Major
    }

    public class Officer
    {
        [Display(Name = "Officer ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required(ErrorMessage = "Officer ID is required")]
        public int OfficerID { get; set; }

        [Display(Name = "Badge Number")]
        [Required(ErrorMessage = "Badge Numer is required")]
        public int BadgeNumber { get; set; }

        [Display(Name = "Rank")]
        public Rank? Rank { get; set; }

        [StringLength(30)]
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }

        [StringLength(30)]
        [Display(Name = "Last Name")]
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
        [Required(ErrorMessage = "Phone Number is required")]
        public int PhoneNumber { get; set; }

        [StringLength(50)]
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Display(Name = "Social Security Number")]
        [Required(ErrorMessage = "Social Securtiy is required")]
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