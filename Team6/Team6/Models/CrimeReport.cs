using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
        [Display(Name = "Crime Report ID")]
        public int CrimereportID { get; set; }

        [Display(Name = "Criminal ID")]
        public int CriminalID { get; set; }

        [Display(Name = "Officer ID")]
        public int OfficerID { get; set; }

        [StringLength(7)]
        [Display(Name = "Case Number")]
        public string CaseNumber { get; set; }

        [Display(Name = "Suspect")]
        public byte Suspect { get; set; }

        [Display(Name = "Offense Type")]
        public OffenseType? OffenseType { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Offense Date")]
        public DateTime OffenseDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Admitted Date")]
        public DateTime AdmittedDate { get; set; }

        [StringLength(50)]
        [Display(Name = "Prison Agency")]
        public string PrisonAgency { get; set; }

        [DataType(DataType.Time)]
        [Display(Name = "Time")]
        public DateTime Time { get; set; }


        public virtual Officer Officer { get; set; }
        public virtual Criminal Criminal { get; set; }

    }
}