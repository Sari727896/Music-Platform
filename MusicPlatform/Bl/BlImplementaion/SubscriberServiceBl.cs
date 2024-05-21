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
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BL.BlImplementaion;

public class SubscriberServiceBl : ISubscriberRepoBl
{
    ISubscriberRepoDal subscriberRepoDal;
    ISongRepoDal songRepoDal;
    IMapper mapper;
    public SubscriberServiceBl(DalManager dalManager, IMapper mapper)
    {
        this.subscriberRepoDal =dalManager.SubscribersRepo;
        this.songRepoDal = dalManager.SongsRepo;
        this.mapper = mapper;
    }
    public List<Bo.Subscriber> GetAll()
    {
        List<Bo.Subscriber> list = new();
        var data = subscriberRepoDal.GetAll();
        data.ForEach(s => list.Add(mapper.Map<Bo.Subscriber>(s)));
        return list;
    }
    public Bo.Subscriber Add(Bo.Subscriber subscriber)
    {
        Dal.Do.Subscriber subscriber1 = mapper.Map<Dal.Do.Subscriber>(subscriber);
        Dal.Do.Subscriber addsubscriber = subscriberRepoDal.Add(subscriber1);
        Bo.Subscriber addedBoSubscriber= mapper.Map<Bo.Subscriber>(addsubscriber);
        return addedBoSubscriber;
    }
    public Bo.Subscriber Update(Bo.Subscriber subscriber, int somethingCode)
    {
        Dal.Do.Subscriber dalsubscriber = mapper.Map<Dal.Do.Subscriber>(subscriber);
        subscriberRepoDal.Update(dalsubscriber, somethingCode);
        Bo.Subscriber blSubscriber = mapper.Map<Bo.Subscriber>(dalsubscriber);
        return blSubscriber;

    }
    public Bo.Subscriber Delete(int code)
    {
        Dal.Do.Subscriber dalsubscriber = subscriberRepoDal.Delete(code);
        Bo.Subscriber subscriber = mapper.Map<Bo.Subscriber>(dalsubscriber);
        return subscriber;
      
    }
    public List<Bo.Song> GetSubscriberSongs(int subscriberId)
    {
        List<Bo.SubscriberSong> list = new();
        var subscriberSongsId = subscriberRepoDal.GetSubscriberSongs(subscriberId);
       
        foreach (var item in subscriberSongsId)
        {
            Bo.SubscriberSong subscriberSong = mapper.Map<Bo.SubscriberSong>(item);
            list.Add(subscriberSong);
        }
        var songs = songRepoDal.GetAll();
        List<Bo.Song> subscriberSongs = new();
        foreach (Bo.SubscriberSong s in list)
        {
            var song = songs.FirstOrDefault(song => song.Id == s.SongId);
            if (song != null)
            {
                Bo.Song subscriberSong = mapper.Map<Bo.Song>(song);
                subscriberSongs.Add(subscriberSong);
            }
        }
        return subscriberSongs;
    }
}

