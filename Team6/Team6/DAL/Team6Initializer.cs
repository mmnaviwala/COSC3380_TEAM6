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
                new Officer{badge_number=001,first_name="John",last_name="Doe",user_name="jdoe",paswerd="password",phone_number=123,email="john@doe.com",ssn=123456789,eye_color=1,feet=6,inches=10,gender=2},
                new Officer{first_name="Smith",last_name="Brown"}
            };

            officers.ForEach(s => context.Officers.Add(s));
            context.SaveChanges();

            var criminals = new List<Criminal>
            {
                new Criminal{first_name="John",last_name="Doe",date_of_birth=DateTime.Parse("1985-09-01")}
            };

            criminals.ForEach(s => context.Criminals.Add(s));
            context.SaveChanges();

            var crimereports = new List<CrimeReport>
            {
                new CrimeReport{officer_id=123,crimereportID=098,offense_date=DateTime.Parse("2005-09-01"),admitted_date=DateTime.Parse("2005-09-01"), time=DateTime.Parse("2005-09-01 07:00:00 PM")}
            };

            crimereports.ForEach(s => context.CrimeReports.Add(s));
            context.SaveChanges();
        }
    }
}