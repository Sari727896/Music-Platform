using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Bo
{
    public class Song
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int SingerId { get; set; }

        public DateTime PublicationDate { get; set; }
    }
}
