using BL.BlApi;
using BL.Bo;
using Dal;
using Dal.DalApi;
using Dal.Dalimplementaion;
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
    ISongRepoBl songRepoBl;
    public SubscriberServiceBl(DalManager dalManager)
    {
        this.subscriberRepoDal =dalManager.SubscribersRepo;
    }
    public List<Subscriber> GetAll()
    {
        List<Subscriber> list = new();
        var data = subscriberRepoDal.GetAll();
        foreach (var item in data)
        {
            Subscriber subscriber = new();
            subscriber.Id = item.Id;
            subscriber.FirstName = item.FirstName;
            subscriber.LastName = item.LastName;
            list.Add(subscriber);
        }
        return list;
    }
    public Subscriber Add(Subscriber subscriber)
    {
        Dal.Do.Subscriber subscriber1 = new();
        subscriber1.Id = subscriber.Id;
        subscriber1.FirstName = subscriber.FirstName;
        subscriber1.LastName = subscriber.LastName;
        subscriberRepoDal.Add(subscriber1);
        return subscriber;
    }
    public Subscriber Update(Subscriber subscriber, int somethimgCode)
    {
        Dal.Do.Subscriber dalsubscriber = new();
        subscriber.Id = subscriber.Id;
        dalsubscriber.FirstName = subscriber.FirstName;
        dalsubscriber.LastName = subscriber.LastName;
        subscriberRepoDal.Update(dalsubscriber, somethimgCode);
        return subscriber;
    }
    public Subscriber Delete(int code)
    {
        Dal.Do.Subscriber dalsubscriber = subscriberRepoDal.Delete(code);
        Subscriber subscriber = new Subscriber();
        subscriber.Id = dalsubscriber.Id;
        subscriber.FirstName = dalsubscriber.FirstName;
        subscriber.LastName = dalsubscriber.LastName;
        return subscriber;
    }

    public List<Song> GetSubscriberSongs(int subscriberId)
    {
        List<SubscriberSong> list = new();
        var subscriberSongsId = subscriberRepoDal.GetSubscriberSongs(subscriberId);
        foreach (var item in subscriberSongsId)
        {
            SubscriberSong subscriberSong = new();
            subscriberSong.Id = item.Id;
            subscriberSong.SongId = item.SongId;
            subscriberSong.SubscriberId = item.SubscriberId;
            list.Add(subscriberSong);
        }

        var songs = songRepoBl.GetAll();
        List<Song> subscriberSongs = new List<Song>();
        foreach (SubscriberSong s in list)
        {
            var song = songs.FirstOrDefault(song => song.Id == s.SongId);
            if (song != null)
            {
                subscriberSongs.Add(song);
            }
        }
        return subscriberSongs;
    }

}

