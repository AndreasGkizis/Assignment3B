using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Certificate_Topics
    {
        //Navigation props
        public Certificate Certificate { get; set; }
        public Topic Topic { get; set; }

        //normal props 
        public int Id { get; set; }








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
            return $"Id -> {Certificate.Id}";
        }
    }

}
