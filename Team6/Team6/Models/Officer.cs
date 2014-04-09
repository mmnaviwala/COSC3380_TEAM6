using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public int OfficerID { get; set; }
        public int BadgeNumber { get; set; }
        public Rank? Rank { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public int Ssn { get; set; }
        public EyeColor? EyeColor { get; set; }
        public int Height { get; set; }
        public Gender? Gender { get; set; }
    }
}