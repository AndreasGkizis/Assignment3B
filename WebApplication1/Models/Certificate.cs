using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Certificate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool ProductEnabled { get; set; }
        public int MaxScore { get; set; }
        //public virtual ICollection<Topic> Topics { get; set; }

    }
}
