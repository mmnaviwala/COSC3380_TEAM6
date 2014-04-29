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
                new Criminal{CriminalID=123456,FirstName="John",LastName="Smith",DateOfBirth=DateTime.Parse("1971-05-20"),EyeColor=EyeColor.Brown, Weight=(155),Height=(70),Gender=Gender.Male,Ssn=(111223333),HairColor=HairColor.Brown,Race=Race.White,Address=("111 A-Street"),City=("Juneau"),ZipCode=(77777),State=State.AK,PhoneNumber=(1231231231),image="~/Photos/unknown.jpg"},
                new Criminal{CriminalID=112233,FirstName="Carl",LastName="Johnson",DateOfBirth=DateTime.Parse("1980-11-18"),EyeColor=EyeColor.Gray,Weight=(130),Height=(55),Gender=Gender.Male,Ssn=(222334444),HairColor=HairColor.Black,Race=Race.White,Address=("222 B-Street"),City=("Montgomery"),ZipCode=(88888),State=State.AL,PhoneNumber=(1231231232),image="~/Photos/unknown.jpg"},
                new Criminal{CriminalID=223344,FirstName="Xavier",LastName="Jones",DateOfBirth=DateTime.Parse("1983-02-10"),EyeColor=EyeColor.Green,Weight=(147),Height=(80),Gender=Gender.Male,Ssn=(333445555),HairColor=HairColor.Bald,Race=Race.BlackAfricanAmerican,Address=("333 C-Street"),City=("Little Rock"),ZipCode=(99999),State=State.AR,PhoneNumber=(1231231233),image="~/Photos/unknown.jpg"},
                new Criminal{CriminalID=445566,FirstName="Adam",LastName="Rivet",DateOfBirth=DateTime.Parse("1988-04-16"),EyeColor=EyeColor.Brown,Weight=(180),Height=(68),Gender=Gender.Male,Ssn=(444556666),HairColor=HairColor.Brown,Race=Race.White,Address=("444 D-Street"),City=("Phoenix"),ZipCode=(11111),State=State.AZ,PhoneNumber=(1231231234),image="~/Photos/unknown.jpg"},
                new Criminal{CriminalID=556677,FirstName="Phil",LastName="Thomas",DateOfBirth=DateTime.Parse("2000-04-16"),EyeColor=EyeColor.Brown,Weight=(135),Height=(77),Gender=Gender.Male,Ssn=(555667777),HairColor=HairColor.Brown,Race=Race.Asian,Address=("555 E-Street"),City=("Sacramento"),ZipCode=(22222),State=State.CA,PhoneNumber=(1231231235),image="~/Photos/unknown.jpg"},
                new Criminal{CriminalID=667788,FirstName="Michael",LastName="Newman",DateOfBirth=DateTime.Parse("1992-01-30"),EyeColor=EyeColor.Brown,Weight=(110),Height=(65),Gender=Gender.Male,Ssn=(666778888),HairColor=HairColor.Brown,Race=Race.White,Address=("666 F-Street"),City=("Denver"),ZipCode=(33333),Alias=("Sean Connery"),State=State.CO,PhoneNumber=(1231231236),image="~/Photos/unknown.jpg"},
                new Criminal{CriminalID=778899,FirstName="Mohammad",LastName="Shirali",DateOfBirth=DateTime.Parse("1991-12-15"),EyeColor=EyeColor.Hazel,Weight=(140),Height=(70),Gender=Gender.Male,Ssn=(777889999),HairColor=HairColor.Black,Race=Race.Asian,Address=("777 G-Street"),City=("Hartford"),ZipCode=(44444),Alias=("Mo Money"),State=State.CT,PhoneNumber=(1231231237),image="~/Photos/unknown.jpg"},
                new Criminal{CriminalID=889900,FirstName="Geordie",LastName="Daniel",DateOfBirth=DateTime.Parse("1990-6-17"),EyeColor=EyeColor.Amber,Weight=(130),Height=(68),Gender=Gender.Male,Ssn=(888990000),HairColor=HairColor.Black,Race=Race.Asian,Address=("888 H-Street"),City=("Dover"),ZipCode=(44444),Alias=("Brown Man"),State=State.DE,PhoneNumber=(1231231238),image="~/Photos/unknown.jpg"},
                new Criminal{CriminalID=990011,FirstName="Josh",LastName="Cooper",DateOfBirth=DateTime.Parse("1989-10-20"),EyeColor=EyeColor.Blue,Weight=(150),Height=(75),Gender=Gender.Male,Ssn=(999001111),HairColor=HairColor.Blonde,Race=Race.White,Address=("999 I-Street"),City=("Miami"),ZipCode=(55555),State=State.FL,PhoneNumber=(1231231239),image="~/Photos/unknown.jpg"},
                new Criminal{CriminalID=987654,FirstName="Juan",LastName="Martinez",DateOfBirth=DateTime.Parse("1990-4-05"),EyeColor=EyeColor.Blue,Weight=(200),Height=(59),Gender=Gender.Male,Ssn=(987456325),HairColor=HairColor.Black,Race=Race.Hispanic,Address=("100 J-Street"),City=("Atlanta"),ZipCode=(66666),Alias=("El Jefe"),State=State.GA,PhoneNumber=(1231231241),image="~/Photos/unknown.jpg"},
                new Criminal{CriminalID=102345,FirstName="Robert",LastName="Gonzalez",DateOfBirth=DateTime.Parse("1956-5-17"),EyeColor=EyeColor.Brown,Weight=(260),Height=(55),Gender=Gender.Male,Ssn=(899887777),HairColor=HairColor.Brown,Race=Race.Hispanic,Address=("200 K-Street"),City=("Dallas"),ZipCode=(77777),Alias=("Taz"),State=State.TX,PhoneNumber=(1231231251),image="~/Photos/unknown.jpg"},               
                new Criminal{CriminalID=201452,FirstName="Mary",LastName="Ford",DateOfBirth=DateTime.Parse("1985-11-1"),EyeColor=EyeColor.Green,Weight=(120),Height=(72),Gender=Gender.Female,Ssn=(777722233),HairColor=HairColor.Blonde,Race=Race.White,Address=("300 L-Street"),City=("Columbus"),ZipCode=(88888),Alias=("Black Widow"),State=State.OH,PhoneNumber=(1231231261),image="~/Photos/unknown.jpg"},
                new Criminal{CriminalID=798150,FirstName="Walter",LastName="White",DateOfBirth=DateTime.Parse("1975-11-1"),EyeColor=EyeColor.Black,Weight=(190),Height=(84),Gender=Gender.Male,Ssn=(314159265),HairColor=HairColor.Bald,Race=Race.White,Address=("300 M-Street"),City=("Albuquerque"),ZipCode=(87101),Alias=("Heisenberg"),State=State.NM,PhoneNumber=(1231231261),image="~/Photos/unknown.jpg"},
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
                new CrimeReport{CrimereportID=969658,CriminalID=667788,OfficerID=715250,CaseNumber="WDE1237",Suspect=true,OffenseType=OffenseType.MotorVehicleTheft, OffenseDate=DateTime.Parse("2014-4-19"),AdmittedDate=DateTime.Parse("2014-4-20"),PrisonAgency="Alcatraz",Time=DateTime.Parse("2014-4-23")},
                new CrimeReport{CrimereportID=325215,CriminalID=778899,OfficerID=258741,CaseNumber="AWE7859",Suspect=true,OffenseType=OffenseType.DomesticViolence, OffenseDate=DateTime.Parse("2014-4-19"),AdmittedDate=DateTime.Parse("2014-4-21"),PrisonAgency="Azcaban",Time=DateTime.Parse("2014-4-23")},
                new CrimeReport{CrimereportID=978952,CriminalID=667788,OfficerID=715250,CaseNumber="EIM2838",Suspect=true,OffenseType=OffenseType.AggravatedAssault, OffenseDate=DateTime.Parse("2010-12-31"),AdmittedDate=DateTime.Parse("2011-1-01"),PrisonAgency="Alcatraz",Time=DateTime.Parse("2011-1-05")},  
                new CrimeReport{CrimereportID=698582,CriminalID=889900,OfficerID=968582,CaseNumber="SWE7982",Suspect=true,OffenseType=OffenseType.Rape, OffenseDate=DateTime.Parse("2011-10-31"),AdmittedDate=DateTime.Parse("2011-11-01"),PrisonAgency="Emerald City",Time=DateTime.Parse("2011-12-10")},  

            
            };

            crimereports.ForEach(s => context.CrimeReports.Add(s));
            context.SaveChanges();
        }
    }
}