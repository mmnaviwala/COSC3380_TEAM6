using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CriminalDatabase.Models
{
    public class CrimeReport
    {
        public int crime_report_id { get; set; }
        [StringLength(6)]
        public string criminal_id { get; set; }
        [StringLength(6)]
        public string officer_badge_number { get; set; }
        
        [StringLength(7)]
        public string case_number { get; set; }
        public byte suspect { get; set; }
        [Range(1, 15)]
        public int offense_type { get; set; }
        [DataType(DataType.Date)]
        public DateTime offense_date { get; set; }
        [DataType(DataType.Date)]
        public DateTime admitted_date { get; set; }
        
        [StringLength(50)]
        public string prison_agency { get; set; }
        [DataType(DataType.Time)]
        public DateTime time { get; set; }

        public virtual Officer Officer { get; set; }
        public virtual Crime Crime { get; set; }
    }
}