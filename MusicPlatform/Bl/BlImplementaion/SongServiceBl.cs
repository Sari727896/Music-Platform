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
    public class SongServiceBl :ISongRepoBl
    {
        ISongRepoDal songRepo;
        public SongServiceBl(ISongRepoDal songRepo)
        {
            this.songRepo = songRepo;
        }

        public Song Add(Song something)
        {
            throw new NotImplementedException();
        }

        public Song Delete(int code)
        {
            throw new NotImplementedException();
        }

        public List<Song> GetAll()
        {
            List<Song> list = new();
            var data = songRepo.GetAll();
            foreach(var item in data)
            {
                Song song = new Song();
                song.Id = item.Id;
                song.Name = item.Name;
                song.SingerId = item.SingerId;
                song.PublicationDate = item.PublicationDate;
                list.Add(song);
            }
            return list;
        }
        public Song GetPublicationSong()
        {
            DateTime lastDate = DateTime.MinValue;
            var data = songRepo.GetAll();
            Song lastSong = new();
            foreach (var item in data)
            {
                if (item.PublicationDate > lastDate)
                {
                    lastDate = item.PublicationDate;
               
                    lastSong.Id = item.Id;
                    lastSong.Name=item.Name;
                    lastSong.SingerId = item.SingerId;
                    lastSong.PublicationDate = item.PublicationDate;
                }
            }
            return lastSong;
        }

        public Song Update(Song something, int somethimgCode)
        {
            throw new NotImplementedException();
        }
    }
}
