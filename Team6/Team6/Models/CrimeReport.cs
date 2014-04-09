using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team6.Models
{
    public class CrimeReport
    {
        public int crimereportID { get; set; }
        public int criminal_id { get; set; }
        public int officer_id { get; set; }
        public string case_number { get; set; }
        public byte suspect { get; set; }
        public int offense_type { get; set; }
        public DateTime offense_date { get; set; }
        public DateTime admitted_date { get; set; }
        public string prison_agency { get; set; }
        public DateTime time { get; set; }
    }
}