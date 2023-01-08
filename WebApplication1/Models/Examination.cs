using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Examination
    {
        //Navigation props
        public Candidate Candidate_Id { get; set; }
        public Certificate Certificate_Id { get; set; }

        //normal props
        public int Id { get; set; }
        public string AssessmentCode { get; set; }
        public DateTime ExaminationDate { get; set;}
        public DateTime ScoreReportDate { get; set;}
        public int CandidateScore { get; set; }
        public bool Passed { get; set; }
        public decimal PercentageScore { get; set; }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return $"Id: {Id}";
        }
    }
}
