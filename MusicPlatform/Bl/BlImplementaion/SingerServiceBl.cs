using BL.BlApi;
using BL.Bo;
using Dal;
using Dal.DalApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BlImplementaion
{
    public class SingerServiceBl : ISingerRepoBl
    {
        ISingerRepoDal singerRepo;
        ISongRepoDal  songRepo;
        public SingerServiceBl(DalManager dalManager)//,BLManager bLManager)
        {
            this.singerRepo =dalManager.SingersRepo;
            this.songRepo = dalManager.SongsRepo;
        }

        public Singer Add(Singer singer)
        {
            Dal.Do.Singer singer1 = new();
            singer1.Age= singer.Age;
            singer1.FirstName = singer.FirstName;
            singer1.LastName = singer.LastName;
            singer1.Id = singer.Id;
            singer1.Description = singer.Description;
            singerRepo.Add(singer1);
            return singer;
        }

        public Singer Delete(int id)
        {
            Dal.Do.Singer dalsinger = singerRepo.Delete(id);
            Singer singer = new Singer();
            singer.FirstName = dalsinger.FirstName;
            singer.Id = dalsinger.Id;
            singer.LastName = dalsinger.LastName;
            singer.Description = dalsinger.Description;
            singer.Age = dalsinger.Age;
            return singer;
        }
        public List<Singer> GetAll()
        {
            List<Singer> list = new();
            var data = singerRepo.GetAll();
            foreach (var item in data)
            {
                Singer singer = new();
                singer.Id = item.Id;
                singer.Age = item.Age;
                singer.FirstName = item.FirstName;
                singer.LastName = item.LastName;
                singer.Description = item.Description;
                list.Add(singer);
            }
            return list;
        }
        public List<Song> GetSingerSongs(int singerId)
        {
            var songs = songRepo.GetAll();
            var singers = singerRepo.GetAll();

            var singer = singers.Find(s => s.Id == singerId);
          
            if (singer == null)
                return null;
            var singerSong = songs.Where(s => s.SingerId == singerId).ToList();
            return singerSong;
        }
        public Singer Update(Singer singer, int singerId)
        {
            Dal.Do.Singer dalsinger = new();
            dalsinger.FirstName = singer.FirstName;
            dalsinger.LastName = singer.LastName;
            dalsinger.Description = singer.Description;
            dalsinger.Age= singer.Age;
            singerRepo.Update(dalsinger, singerId);
            return singer;
        }
    }
}
