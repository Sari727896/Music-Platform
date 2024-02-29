using Dal.Do;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Dalimplementaion;

public class SubscriberRepo
{
    MusicContext musicContext;
    public SubscriberRepo(MusicContext musicContext)
    {
        this.musicContext = musicContext;
    }
    public List<Subscriber> GetAll()
    {
        IEnumerable<Subscriber> subscriber = musicContext.Subscribers;
        return subscriber.ToList();
    }
    public Subscriber Add(Subscriber subscriber)
    {
        musicContext.Subscribers.Add(subscriber);
        musicContext.SaveChanges();
        return subscriber;
    }
    public Subscriber Update(Subscriber subscriber, int code)
    {
        Subscriber subscriberToUpdate = musicContext.Subscribers.FirstOrDefault(s => s.Code == code);
        if (subscriberToUpdate != null)
        {
            subscriberToUpdate.LastName = subscriber.LastName;
            musicContext.SaveChanges();
            return subscriberToUpdate;
        }
        return null;
    }
    public Subscriber Delete(int code)
    {
        Subscriber subscriberToDelete = musicContext.Subscribers.FirstOrDefault(p => p.Code == code);
        if (subscriberToDelete != null)
        {
            musicContext.Subscribers.Remove(subscriberToDelete);
            musicContext.SaveChanges();
            return subscriberToDelete;
        }
        return null;
    }

}
