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
        public int OfficerID { get; set; }

        [Display(Name = "Badge Number")]
        public int BadgeNumber { get; set; }

        [Display(Name = "Rank")]
        public Rank? Rank { get; set; }

        [StringLength(30)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [StringLength(30)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [StringLength(15)]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Phone Number")]
        public int PhoneNumber { get; set; }

        [StringLength(50)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Social Security Number")]
        public int Ssn { get; set; }

        [Display(Name = "Eye Color")]
        public EyeColor? EyeColor { get; set; }

        [Display(Name = "Height")]
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