using AutoMapper;
using BL.BlApi;
using BL.Bo;
using Dal.DalApi;
using Dal.Dalimplementaion;
using Dal.Do;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BL.BlImplementaion
{
    public class SongServiceBl : ISongRepoBl
    {
        ISongRepoDal songRepo;
        IMapper mapper;
        public SongServiceBl(ISongRepoDal songRepo, IMapper mapper)
        {
            this.songRepo = songRepo;
            this.mapper = mapper;
        }


        public Bo.Song Add(Bo.Song song)
        {

            Dal.Do.Song dalsong = mapper.Map<Dal.Do.Song>(song);
            Dal.Do.Song addsong = songRepo.Add(dalsong);
            Bo.Song addedBoSong = mapper.Map<Bo.Song>(addsong);
            return addedBoSong;
        }

        public Bo.Song Delete(int code)
        {
            Dal.Do.Song dalsong = songRepo.Delete(code);
            Bo.Song song = new();
            song.Id = dalsong.Id;
            song.Name = dalsong.Name;
            song.SingerId = dalsong.SingerId;
            song.PublicationDate = dalsong.PublicationDate;
            //song.SingerName = dalsong.Singer.FirstName + " " + dalsong.Singer.LastName;
            return song;
        }

        public List<Bo.Song> GetAll()
        {
            List<Bo.Song> list = new();
            var data = songRepo.GetAll();
            foreach (var item in data)
            {
                Bo.Song song = new();
                song.Id = item.Id;
                song.Name = item.Name;
                song.SingerId = item.SingerId;
                song.PublicationDate = item.PublicationDate;
                //song.SingerName = item.Singer.FirstName + " " + item.Singer.LastName;
                list.Add(song);
            }
            return list;
        }
        public Bo.Song GetPublicationSong()
        {
            DateTime lastDate = DateTime.MinValue;
            var data = songRepo.GetAll();
            Bo.Song lastSong = new();
            foreach (var item in data)
            {
                if (item.PublicationDate > lastDate)
                {
                    lastDate = item.PublicationDate;
                    lastSong.Id = item.Id;
                    lastSong.Name = item.Name;
                    lastSong.SingerId = item.SingerId;
                    lastSong.PublicationDate = item.PublicationDate;
                }
            }
            return lastSong;
        }

        public Bo.Song Update(Bo.Song song, int songCode)
        {
            Dal.Do.Song dalsong = new();
            dalsong.SingerId = song.SingerId;
            dalsong.PublicationDate = song.PublicationDate;
            dalsong.Id = songCode;
            dalsong.Name = song.Name;
            songRepo.Update(dalsong, songCode);
            return song;
        }

    }
}
