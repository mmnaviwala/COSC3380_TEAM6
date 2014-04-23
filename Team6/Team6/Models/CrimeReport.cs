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
        None,
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
        [Required(ErrorMessage = "Crime Report ID is required")]
        public int CrimereportID { get; set; }

        [Display(Name = "Criminal ID")]
        [Required(ErrorMessage = "Criminal ID is required")]
        public int CriminalID { get; set; }

        [Display(Name = "Officer ID")]
        [Required(ErrorMessage = "Officer ID is required")]
        public int OfficerID { get; set; }

        [StringLength(7)]
        [Display(Name = "Case Number")]
        [Required(ErrorMessage = "Case Number is required")]
        public string CaseNumber { get; set; }

        [Display(Name = "Suspect")]
        public bool Suspect { get; set; }

        [Display(Name = "Offense Type")]
        public OffenseType? OffenseType { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Offense Date")]
        [Required(ErrorMessage = "Offense Date is required")]
        public DateTime OffenseDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Admitted Date")]
        [Required(ErrorMessage = "Admitted Dateis required")]
        public DateTime AdmittedDate { get; set; }

        [StringLength(50)]
        [Display(Name = "Prison Agency")]
        public string PrisonAgency { get; set; }

        [DataType(DataType.Time)]
        [Display(Name = "Time")]
        [Required(ErrorMessage = "Time is required")]
        public DateTime Time { get; set; }


        public virtual Officer Officer { get; set; }
        public virtual Criminal Criminal { get; set; }

    }
}