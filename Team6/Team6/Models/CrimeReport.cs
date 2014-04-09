using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team6.Models
{
    public class CrimeReport
    {
        public int CrimereportID { get; set; }
        public int CriminalID { get; set; }
        public int OfficerID { get; set; }
        public string CaseNumber { get; set; }
        public byte Suspect { get; set; }
        public int OffenseType { get; set; }
        public DateTime OffenseDate { get; set; }
        public DateTime AdmittedDate { get; set; }
        public string PrisonAgency { get; set; }
        public DateTime Time { get; set; }
    }
}