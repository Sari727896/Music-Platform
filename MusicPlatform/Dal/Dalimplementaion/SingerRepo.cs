using Dal.DalApi;
using Dal.Do;
using Microsoft.EntityFrameworkCore;
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
            IEnumerable<Singer> singers = musicContext.Singers;
            //if (Singers == null)
            //    return null;
            return singers.ToList();
        }
        public Singer Add(Singer singer)
        {
            musicContext.Singers.Add(singer);
            musicContext.SaveChanges();
            return singer;
        }
        public Singer Update(Singer singer, int singerId)
        {
            Singer SingerToUpdate = musicContext.Singers.FirstOrDefault(s => s.Id == singerId);
            if (SingerToUpdate != null)
            {
                SingerToUpdate.Age = singer.Age;
                musicContext.SaveChanges();
                return SingerToUpdate;
            }
            return null;
        }
        public Singer Delete(int id)
        {
            Singer singerToDelete = musicContext.Singers.FirstOrDefault(p => p.Id == id);
            if (singerToDelete != null)
            {
                musicContext.Singers.Remove(singerToDelete);
                musicContext.SaveChanges();
                return singerToDelete;
            }
            return null;
        }     
    }
}
