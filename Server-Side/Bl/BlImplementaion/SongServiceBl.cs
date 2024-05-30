using AutoMapper;
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

namespace BL.BlImplementaion;

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
        return song;
    }
    public List<Bo.Song> GetAll()
    {
        List<Bo.Song> listBl = new();
        var data = songRepo.GetAll();
        data.ForEach(s => listBl.Add(mapper.Map<Bo.Song>(s)));
        return listBl;
    }
    public List<Bo.Song> GetRecentSongs()
    {
        //to do Transfer the count to the permanent page
        //int count = 6;
        var recentSongs = songRepo
            .GetAll()
            .OrderByDescending(s => s.PublicationDate)
            .Take(6)
            .Select(song => mapper.Map<Bo.Song>(song))
            .ToList();

        return recentSongs;
    }
    public Bo.Song Update(Bo.Song song, int songCode)
    {
        Dal.Do.Song dalsong =mapper.Map<Dal.Do.Song>(song);
        songRepo.Update(dalsong, songCode);
        Bo.Song blsong=mapper.Map<Bo.Song>(dalsong);
        return blsong;
    }
}
