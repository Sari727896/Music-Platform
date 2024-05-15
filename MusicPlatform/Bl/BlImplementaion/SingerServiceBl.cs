﻿using AutoMapper;
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
        IMapper map;
        public SingerServiceBl(DalManager dalManager, IMapper map)
        {
            this.singerRepo =dalManager.SingersRepo;
            this.songRepo = dalManager.SongsRepo;
            this.map = map;
        }

        public Singer Add(Singer singer)
        {
            Dal.Do.Singer singer1 =map.Map<Dal.Do.Singer>(singer);
            //singer1.Age= singer.Age;
            //singer1.FirstName = singer.FirstName;
            //singer1.LastName = singer.LastName;
            //singer1.Id = singer.Id;
            //singer1.Description = singer.Description;

            singerRepo.Add(singer1);
            return singer;
        }

        public Singer Delete(int id)
        {
            Dal.Do.Singer dalsinger = singerRepo.Delete(id);
            Singer singer = map.Map<Singer>(dalsinger);
            //singer.FirstName = dalsinger.FirstName;
            //singer.Id = dalsinger.Id;
            //singer.LastName = dalsinger.LastName;
            //singer.Description = dalsinger.Description;
            //singer.Age = dalsinger.Age;
            return singer;
        }
        public List<Singer> GetAll()
        {
            List<Singer> listBl = new();
            var data = singerRepo.GetAll();
            data.ForEach(sin => listBl.Add(map.Map<Singer>(sin)));
            return listBl;
        }
        public List<Song> GetSingerSongs(int singerId)
        {
            var songs = songRepo.GetAll();
            var singers = singerRepo.GetAll();
            List<Song> listBlSong = new();
            var singer = singers.Find(s => s.Id == singerId);
            if (singer == null)
                return null;
            var singerSong = songs.Where(s => s.SingerId == singerId).ToList();
            singerSong.ForEach(s=> listBlSong.Add(map.Map<Song>(s)));
            return listBlSong;
        }
        public Singer Update(Singer singer, int singerId)
        {
            Dal.Do.Singer dalsinger = map.Map<Dal.Do.Singer>(singer);
            //dalsinger.FirstName = singer.FirstName;
            //dalsinger.LastName = singer.LastName;
            //dalsinger.Description = singer.Description;
            //dalsinger.Age= singer.Age;
            singerRepo.Update(dalsinger, singerId);
            return singer;
        }
    }
}
