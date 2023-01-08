using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class ExaminationTopic_Results
    {
        public int Id { get; set; }
        public int AwardedMarks { get; set; }

        //Navigation props
        public Examination Examination { get; set; }
        public Topic Topic { get; set; }

    }
}
