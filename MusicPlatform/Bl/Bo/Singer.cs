using Dal.Do;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Bo
{
    public class Singer
    {
        public int Id { get; set; } 

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public int? Age { get; set; }
        public string Description { get; set; }
  
    }
}
