using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Team6.Models;

namespace Team6.DAL
{
    public class Team6Context : DbContext
    {
        public Team6Context() : base("Team6Context")
        { }

        public DbSet<Officer> Officers { get; set; }
        public DbSet<Criminal> Criminals { get; set; }
        public DbSet<CrimeReport> CrimeReports { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}