using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MIS4200Hackett.Models;

namespace MIS4200Hackett.DAL
{
    public class MIS4200Context : DbContext
    {
        public MIS4200Context() : base ("name=DefaultConnection")
        {

        }
        public DbSet<order> orders { get; set; }
        public DbSet<customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<LineItem> LineItems { get; set; }
        public DbSet <Patient> Patients { get; set; }
        public DbSet <Doctor> Doctors { get; set; }
        public DbSet <Treatment> Treatments { get; set; }
        public DbSet <TreatmentLineItem> TreatmentLineItems { get; set; }
        public DbSet <UserData> UserData { get; set; }





    }
}