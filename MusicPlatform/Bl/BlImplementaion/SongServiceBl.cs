﻿using AutoMapper;
using BL.BlApi;
using BL.Bo;
using Dal;
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
        public SongServiceBl(DalManager dalManager, IMapper mapper)
        {
            this.songRepo = dalManager.SongsRepo;
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
            Bo.Song song =mapper.Map<Bo.Song>(dalsong);
            //song.Id = dalsong.Id;
            //song.Name = dalsong.Name;
            //song.SingerId = dalsong.SingerId;
            //song.PublicationDate = dalsong.PublicationDate;
            //song.SingerName = dalsong.Singer.FirstName + " " + dalsong.Singer.LastName;
            return song;
        }

        public List<Bo.Song> GetAll()
        {
            List<Bo.Song> listBl = new();
            var data = songRepo.GetAll();
            data.ForEach(s => listBl.Add(mapper.Map<Bo.Song>(s)));
            return listBl;
        }
        public Bo.Song GetPublicationSong()
        {
            DateTime lastDate = DateTime.MinValue;
            var data = songRepo.GetAll();
            Bo.Song lastSong =mapper.Map<Bo.Song>(data.OrderByDescending(s=>s.PublicationDate).FirstOrDefault());
            //foreach (var item in data)
            //{
            //    if (item.PublicationDate > lastDate)
            //    {
            //        lastDate = item.PublicationDate;
            //        lastSong.Id = item.Id;
            //        lastSong.Name = item.Name;
            //        lastSong.SingerId = item.SingerId;
            //        lastSong.PublicationDate = item.PublicationDate;
            //    }
            //}
            return lastSong;
        }

        public Bo.Song Update(Bo.Song song, int songCode)
        {
            Dal.Do.Song dalsong =mapper.Map<Dal.Do.Song>(song);
            //dalsong.SingerId = song.SingerId;
            //dalsong.PublicationDate = song.PublicationDate;
            //dalsong.Id = songCode;
            //dalsong.Name = song.Name;
            songRepo.Update(dalsong, songCode);
            Bo.Song blsong=mapper.Map<Bo.Song>(dalsong);
            return blsong;
        }

    }
}
