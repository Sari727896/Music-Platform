using BL.BlApi;
using BL.Bo;
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
        ISongRepoBl songRepoBl;
        public SingerServiceBl(ISingerRepoDal singerRepo, ISongRepoBl songRepoBl)
        {
            this.singerRepo = singerRepo;
            this.songRepoBl=songRepoBl;
        }

        public Singer Add(Singer singer)
        {
            return null;
        }

        public Singer Delete(int code)
        {
            throw new NotImplementedException();
        }

        public List<Singer> GetAll()
        {
            List<Singer> list = new();
            var data = singerRepo.GetAll();
            foreach (var item in data)
            {
                Singer singer = new ();
                singer.Code=item.Code;
                singer.Id = item.Id;
                singer.FirstName = item.FirstName;
                singer.LastName = item.LastName;
                singer.Description= item.Description;
                list.Add(singer);
            }
            return list;
        }

        public List<Song> GetSingerSongs(int singerCode)
        {
            var songs=songRepoBl.GetAll();
            var singers=singerRepo.GetAll();
            var singer = singers.Find(s => s.Code == singerCode);
            if (singer == null)
                return null;
            var singerSong = songs.Where(s => s.SingerId == singerCode).ToList();
            return singerSong;
        }

        public Singer Update(Singer something, int somethimgCode)
        {
            throw new NotImplementedException();
        }
    }
}
