using BL.Bo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BlApi
{
    public interface ISingerRepoBl:IRepoBl<Singer>
    {
        public List<Song> GetSingerSongs(int singerCode);
    }
}
