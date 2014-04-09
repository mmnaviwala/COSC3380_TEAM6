using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;

namespace Team6.Models
{
    public enum OffenseType
    {
        Murder,
        Rape,
        Robbery,
        [Description("Aggravated Assault")]
        AggravatedAssault,
        Burglary,
        [Description("Larceny-Theft")]
        LarcenyTheft,
        [Description("Motor Vehicle Theft")]
        MotorVehicleTheft,
        Arson,
        [Description("Domestic Violence")]
        DomesticViolence,
        [Description("Drug Related Crime")]
        DrugRelatedCrime,
        [Description("DUI/DWI")]
        DUIDWI,
        Fraud,
        Kidnapping,
        Manslaughter,
        Vandalism
    }

    public class CrimeReport
    {
        public int CrimereportID { get; set; }
        public int CriminalID { get; set; }
        public int OfficerID { get; set; }
        public string CaseNumber { get; set; }
        public byte Suspect { get; set; }
        public OffenseType? OffenseType { get; set; }
        public DateTime OffenseDate { get; set; }
        public DateTime AdmittedDate { get; set; }
        public string PrisonAgency { get; set; }
        public DateTime Time { get; set; }
    }
}