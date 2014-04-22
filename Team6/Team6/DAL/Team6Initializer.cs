using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Team6.Models;

namespace Team6.DAL
{
    public class Team6Initializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<Team6Context>
    {
        protected override void Seed(Team6Context context)
        {
            var criminals = new List<Criminal>
            {
                new Criminal{CriminalID=123456,FirstName="John",LastName="Doe",DateOfBirth=DateTime.Parse("1971-05-20"),EyeColor=EyeColor.Brown, Weight=(155),Height=(70),Gender=Gender.Male,Ssn=(111223333),HairColor=HairColor.Brown,Race=Race.White,Address=("111 A-Street"),ZipCode=(77777)},
                new Criminal{CriminalID=112233,FirstName="Carl",LastName="Johnson",DateOfBirth=DateTime.Parse("1980-11-18"),EyeColor=EyeColor.Gray,Weight=(130),Height=(55),Gender=Gender.Male,Ssn=(222334444),HairColor=HairColor.Black,Race=Race.White,Address=("222 B-Street"),ZipCode=(88888)},
                new Criminal{CriminalID=223344,FirstName="Xavier",LastName="Jones",DateOfBirth=DateTime.Parse("1983-02-10"),EyeColor=EyeColor.Green,Weight=(147),Height=(80),Gender=Gender.Male,Ssn=(333445555),HairColor=HairColor.Bald,Race=Race.BlackAfricanAmerican,Address=("333 C-Street"),ZipCode=(99999)},
                new Criminal{CriminalID=445566,FirstName="Adam",LastName="Rivet",DateOfBirth=DateTime.Parse("1988-04-16"),EyeColor=EyeColor.Brown,Weight=(180),Height=(68),Gender=Gender.Male,Ssn=(444556666),HairColor=HairColor.Brown,Race=Race.White,Address=("444 D-Street"),ZipCode=(11111)},
                new Criminal{CriminalID=556677,FirstName="Phil",LastName="Thomas",DateOfBirth=DateTime.Parse("2000-04-16"),EyeColor=EyeColor.Brown,Weight=(135),Height=(77),Gender=Gender.Male,Ssn=(555667777),HairColor=HairColor.Brown,Race=Race.Asian,Address=("555 E-Street"),ZipCode=(22222)},
            };

            criminals.ForEach(s => context.Criminals.Add(s));
            context.SaveChanges();

            var officers = new List<Officer>
            {
                new Officer{OfficerID=654321,BadgeNumber=001,FirstName="John",Rank=Rank.AssistantChief,LastName="Doe",UserName="jdoe",Password="jd001",PhoneNumber=234567892,Email="john@doe.com",Ssn=123456789,EyeColor=EyeColor.Amber,Height=60,Gender=Gender.Male},
                new Officer{OfficerID=258741,BadgeNumber=002,FirstName="Alex",Rank=Rank.Sergeant,LastName="Murphy",UserName="jbrown",Password="am002",PhoneNumber=234345823, Email="alex@murphy.com", Ssn=567839201, EyeColor=EyeColor.Blue,Height=70, Gender=Gender.Male},
                new Officer{OfficerID=845162,BadgeNumber=003,FirstName="Matt",Rank=Rank.ChiefOfPolice,LastName="Dillon",UserName="mdillon",Password="md003",PhoneNumber=234789645, Email="matt@dillon.com", Ssn=789641453, EyeColor=EyeColor.Brown, Height=55, Gender=Gender.Male},
                new Officer{OfficerID=956251,BadgeNumber=004,FirstName="Harry",Rank=Rank.Inspector,LastName="Callahan",UserName="hcallahan",Password="hc004",PhoneNumber=86753909, Email="harry@callahan.com", Ssn=654210412, EyeColor=EyeColor.Gray, Height=81, Gender=Gender.Male},
                new Officer{OfficerID=764312,BadgeNumber=005,FirstName="Axel",Rank=Rank.Colonel,LastName="Foley",UserName="afoley",Password="af005",PhoneNumber=456890239, Email="axel@foleycom", Ssn=784241563, EyeColor=EyeColor.Green, Height=89, Gender=Gender.Male},
                new Officer{OfficerID=458963,BadgeNumber=006,FirstName="Martin",Rank=Rank.Detective,LastName="Rigg",UserName="mrigg",Password="mr006",PhoneNumber=745120856,Email="martin@rigg.com",Ssn=463217896,EyeColor=EyeColor.Green,Height=56,Gender=Gender.Male},
                new Officer{OfficerID=368525,BadgeNumber=007,FirstName="Laverne",Rank=Rank.Sergeant,LastName="Hooks",UserName="lhooks",Password="lh007",PhoneNumber=745120856,Email="martin@rigg.com",Ssn=528145648,EyeColor=EyeColor.Brown,Height=52,Gender=Gender.Female},
                new Officer{OfficerID=296348,BadgeNumber=008,FirstName="Anne",Rank=Rank.Officer,LastName="Lewis",UserName="alewis",Password="al008",PhoneNumber=313250489,Email="anne@lewis.com",Ssn=789323141,EyeColor=EyeColor.Blue,Height=50,Gender=Gender.Female},
                new Officer{OfficerID=582148,BadgeNumber=009,FirstName="Amelia",Rank=Rank.Officer,LastName="Donaghy",UserName="adonaghy",Password="ad009",PhoneNumber=253698412,Email="amelia@donaghy.com",Ssn=598546354,EyeColor=EyeColor.Green,Height=51,Gender=Gender.Female},
                new Officer{OfficerID=896335,BadgeNumber=010,FirstName="David",Rank=Rank.Detective,LastName="Starsky",UserName="dstarsky",Password="ds010",PhoneNumber=213654859,Email="david@starsky.com",Ssn=012536525,EyeColor=EyeColor.Brown,Height=70,Gender=Gender.Male},
                new Officer{OfficerID=968582,BadgeNumber=011,FirstName="Kenneth",Rank=Rank.Detective,LastName="Hutchinson",UserName="khutchinson",Password="kh011",PhoneNumber=213654859,Email="kenneth@hutchinson.com",Ssn=201455960,EyeColor=EyeColor.Blue,Height=78,Gender=Gender.Male},
                new Officer{OfficerID=147859,BadgeNumber=012,FirstName="Clarice",Rank=Rank.Officer,LastName="Starling",UserName="cstarling",Password="cs012",PhoneNumber=968878525,Email="clarice@startling.com",Ssn=784528569,EyeColor=EyeColor.Green,Height=59,Gender=Gender.Female},
                new Officer{OfficerID=828582,BadgeNumber=013,FirstName="Frank",Rank=Rank.Detective,LastName="Drebin",UserName="fdrebin",Password="fd013",PhoneNumber=859632148,Email="frank@drebin.com",Ssn=701253652,EyeColor=EyeColor.Blue,Height=75,Gender=Gender.Male},
                new Officer{OfficerID=696582,BadgeNumber=014,FirstName="Vincent",Rank=Rank.Lieutenant,LastName="Hanna",UserName="vhanna",Password="vh014",PhoneNumber=202148568,Email="vincent@hanna.com",Ssn=70856385,EyeColor=EyeColor.Brown,Height=62,Gender=Gender.Male},
                new Officer{OfficerID=715250,BadgeNumber=015,FirstName="Clancy",Rank=Rank.Captain,LastName="Wiggum",UserName="cwiggum",Password="cw015",PhoneNumber=365825418,Email="clancy@wiggum.com",Ssn=81829362,EyeColor=EyeColor.Brown,Height=58,Gender=Gender.Male},
            
            };

            officers.ForEach(s => context.Officers.Add(s));
            context.SaveChanges();

            var crimereports = new List<CrimeReport>
            {
                new CrimeReport{CrimereportID=123789,CriminalID=123456,OfficerID=654321,CaseNumber="ASD1234",Suspect=true,OffenseType=OffenseType.Burglary, OffenseDate=DateTime.Parse("1991-05-05"),AdmittedDate=DateTime.Parse("1991-05-20"),PrisonAgency="Uma's Penetentiary",Time=DateTime.Parse("1991-05-21")},
                new CrimeReport{CrimereportID=741258,CriminalID=123456,OfficerID=258741,CaseNumber="ASD7890",Suspect=true,OffenseType=OffenseType.Vandalism,OffenseDate=DateTime.Parse("1995-03-13"),AdmittedDate=DateTime.Parse("1995-04-10"),PrisonAgency="Alcatraz",Time=DateTime.Parse("1995-04-11")},
                new CrimeReport{CrimereportID=753951,CriminalID=123456,OfficerID=845162,CaseNumber="ASD4567",Suspect=true,OffenseType=OffenseType.Manslaughter, OffenseDate=DateTime.Parse("1996-08-18"),AdmittedDate=DateTime.Parse("1996-08-20"),PrisonAgency="Azcaban",Time=DateTime.Parse("1996-08-22")},
                new CrimeReport{CrimereportID=456159,CriminalID=123456,OfficerID=956251,CaseNumber="AMD1580",Suspect=false,OffenseType=OffenseType.MotorVehicleTheft, OffenseDate=DateTime.Parse("1997-12-24"),AdmittedDate=DateTime.Parse("1998-01-05"),PrisonAgency="Emerald City",Time=DateTime.Parse("1998-01-12")},
                new CrimeReport{CrimereportID=753789,CriminalID=123456,OfficerID=764312,CaseNumber="UMA7390",Suspect=false,OffenseType=OffenseType.AggravatedAssault, OffenseDate=DateTime.Parse("1999-10-30"),AdmittedDate=DateTime.Parse("1999-11-24"),PrisonAgency="Woodbury",Time=DateTime.Parse("1999-11-27")},
            };

            crimereports.ForEach(s => context.CrimeReports.Add(s));
            context.SaveChanges();
        }
    }
}