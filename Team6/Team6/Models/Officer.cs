using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Team6.Models
{
    public enum Rank
    {
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


        public virtual CrimeReport CrimeReport { get; set; }
    }
}