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
            
            var officers = new List<Officer>
            {
                //new Officer{BadgeNumber=001,FirstName="John",LastName="Doe",UserName="jdoe",Password="password",PhoneNumber=123,Email="john@doe.com",Ssn=123456789,EyeColor=1,Feet=6,Inches=10,Gender=2},
                new Officer{FirstName="Smith",LastName="Brown"}
            };

             /*
            officers.ForEach(s => context.Officers.Add(s));
            context.SaveChanges();

            var criminals = new List<Criminal>
            {
                new Criminal{FirstName="John",LastName="Doe",DateOfBirth=DateTime.Parse("1985-09-01")}
            };

            criminals.ForEach(s => context.Criminals.Add(s));
            context.SaveChanges();

            var crimereports = new List<CrimeReport>
            {
                new CrimeReport{OfficerID=123,CrimereportID=098,OffenseDate=DateTime.Parse("2005-09-01"),AdmittedDate=DateTime.Parse("2005-09-01"), Time=DateTime.Parse("2005-09-01 07:00:00 PM")}
            };

            crimereports.ForEach(s => context.CrimeReports.Add(s));
            context.SaveChanges();
            */
        }
    }
}