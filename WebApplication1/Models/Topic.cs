using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Topic
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int PossibleMarks { get; set; }
        public string Description { get; set; }
        //public virtual ICollection<Certificate> Certificates { get; set; }


    }
}
