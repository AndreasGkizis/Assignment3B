using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ModelProject.Models;

namespace WebApplication1.Data
{
    public class AppContextDikoMou: DbContext
    {
        public virtual DbSet<Candidate> Candidates { get; set; } 
        public virtual DbSet<Certificate> Certificates { get; set; } 
        public virtual DbSet<Examination> Examinations { get; set; } 
        public virtual DbSet<Topic> Topics { get; set; } 
        public virtual DbSet<ExaminationTopic_Results> ExaminationTopic_Results{ get; set; }
        public virtual DbSet<Certificate_Topics> Certificate_Topics { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<AppContextDikoMou>(new MyDBInitializer());
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Examination>().HasRequired(s => s.Candidate_Id).WithMany().WillCascadeOnDelete(true);
            modelBuilder.Entity<ExaminationTopic_Results>().HasRequired(s => s.Examination).WithMany().WillCascadeOnDelete(true);
        }
        public AppContextDikoMou():base("name = MyCon")
        { }
    }
}
