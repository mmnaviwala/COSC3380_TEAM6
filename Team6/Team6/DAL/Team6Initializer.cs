using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Team6.Models;

namespace Team6.DAL
{
    public class Team6Initializer : System.Data.Entity.DropCreateDatabaseAlways<Team6Context>
    {
        protected override void Seed(Team6Context context)
        {
            var criminals = new List<Criminal>
            {
                new Criminal{CriminalID=123456,FirstName="John",LastName="Doe",DateOfBirth=DateTime.Parse("1971-05-20")},
                new Criminal{CriminalID=112233,FirstName="Carl",LastName="Johnson",DateOfBirth=DateTime.Parse("1980-11-18")},
                new Criminal{CriminalID=223344,FirstName="Xavier",LastName="Jones",DateOfBirth=DateTime.Parse("1983-02-10")},
                new Criminal{CriminalID=778899,FirstName="Phil",LastName="Thomas",DateOfBirth=DateTime.Parse("1963-12-05")},
                new Criminal{CriminalID=445566,FirstName="Adam",LastName="Rivet",DateOfBirth=DateTime.Parse("1988-04-16")},
            };

            criminals.ForEach(s => context.Criminals.Add(s));
            context.SaveChanges();

            var officers = new List<Officer>
            {
                new Officer{OfficerID=654321,BadgeNumber=001,FirstName="John",Rank=Rank.AssistantChief,LastName="Doe",UserName="jdoe",Password="jd001",PhoneNumber=234567892,Email="john@doe.com",Ssn=123456789,EyeColor=EyeColor.Amber,Height=60,Gender=Gender.Male},
                new Officer{OfficerID=258741,BadgeNumber=002,FirstName="Alex",Rank=Rank.Detective,LastName="Murphy",UserName="jbrown",Password="am002",PhoneNumber=234345823, Email="alex@murphy.com", Ssn=567839201, EyeColor=EyeColor.Blue,Height=70, Gender=Gender.Male},
                new Officer{OfficerID=845162,BadgeNumber=003,FirstName="Matt",Rank=Rank.ChiefOfPolice,LastName="Dillon",UserName="mdillon",Password="md003",PhoneNumber=234789645, Email="matt@dillon.com", Ssn=789641453, EyeColor=EyeColor.Brown, Height=55, Gender=Gender.Male},
                new Officer{OfficerID=956251,BadgeNumber=004,FirstName="Harry",Rank=Rank.Sergeant,LastName="Callahan",UserName="hcallahan",Password="hc004",PhoneNumber=86753909, Email="harry@callahan.com", Ssn=654210412, EyeColor=EyeColor.Gray, Height=81, Gender=Gender.Male},
                new Officer{OfficerID=764312,BadgeNumber=005,FirstName="Axel",Rank=Rank.Colonel,LastName="Foley",UserName="afoley",Password="af005",PhoneNumber=456890239, Email="axel@foleycom", Ssn=784241563, EyeColor=EyeColor.Green, Height=89, Gender=Gender.Male},
            };

            officers.ForEach(s => context.Officers.Add(s));
            context.SaveChanges();

            var crimereports = new List<CrimeReport>
            {
                new CrimeReport{CrimereportID=123789,CriminalID=123456,OfficerID=654321,CaseNumber="ASD1234",Suspect=1,OffenseType=OffenseType.Burglary, OffenseDate=DateTime.Parse("1991-05-05"),AdmittedDate=DateTime.Parse("1991-05-20"),PrisonAgency="Uma's Penetentiary",Time=DateTime.Parse("1991-05-21")},
                new CrimeReport{CrimereportID=741258,CriminalID=123456,OfficerID=258741,CaseNumber="ASD7890",Suspect=0,OffenseType=OffenseType.Vandalism,OffenseDate=DateTime.Parse("1995-03-13"),AdmittedDate=DateTime.Parse("1995-04-10"),PrisonAgency="Alcatraz",Time=DateTime.Parse("1995-04-11")},
                new CrimeReport{CrimereportID=753951,CriminalID=123456,OfficerID=845162,CaseNumber="ASD4567",Suspect=0,OffenseType=OffenseType.Manslaughter, OffenseDate=DateTime.Parse("1996-08-18"),AdmittedDate=DateTime.Parse("1996-08-20"),PrisonAgency="Azcaban",Time=DateTime.Parse("1996-08-22")},
                new CrimeReport{CrimereportID=456159,CriminalID=123456,OfficerID=956251,CaseNumber="AMD1580",Suspect=1,OffenseType=OffenseType.MotorVehicleTheft, OffenseDate=DateTime.Parse("1997-12-24"),AdmittedDate=DateTime.Parse("1998-01-05"),PrisonAgency="Emerald City",Time=DateTime.Parse("1998-01-12")},
                new CrimeReport{CrimereportID=753789,CriminalID=123456,OfficerID=764312,CaseNumber="UMA7390",Suspect=1,OffenseType=OffenseType.AggravatedAssault, OffenseDate=DateTime.Parse("1999-10-30"),AdmittedDate=DateTime.Parse("1999-11-24"),PrisonAgency="Woodbury",Time=DateTime.Parse("1999-11-27")},
            };

            crimereports.ForEach(s => context.CrimeReports.Add(s));
            context.SaveChanges();
        }
    }
}