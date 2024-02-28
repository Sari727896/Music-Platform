using Dal.DalApi;
using Dal.Do;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Dalimplementaion
{
    public class SingerRepo:ISingerRepoDal
    {
        MusicContext musicContext;
        public SingerRepo(MusicContext musicContext)
        {
            this.musicContext = musicContext;
        }
        public List<Singer> GetAll()
        {
            IEnumerable<Singer> Singers = musicContext.Singers;
            //if (Singers == null)
            //    return null;
            return Singers.ToList();
        }
        public Singer Add(Singer Singer)
        {
            musicContext.Singers.Add(Singer);
            musicContext.SaveChanges();
            return Singer;
        }
        public Singer Update(Singer Singer, int code)
        {
            Singer SingerToUpdate = musicContext.Singers.FirstOrDefault(s => s.Code == code);
            if (SingerToUpdate != null)
            {
                SingerToUpdate.Age = Singer.Age;
                musicContext.SaveChanges();
                return SingerToUpdate;
            }
            return null;
        }
        public Singer Delete(int code)
        {
            Singer SingerToDelete = musicContext.Singers.FirstOrDefault(p => p.Code == code);
            if (SingerToDelete != null)
            {
                musicContext.Singers.Remove(SingerToDelete);
                musicContext.SaveChanges();
                return SingerToDelete;
            }
            return null;
        }

        
    }
}
