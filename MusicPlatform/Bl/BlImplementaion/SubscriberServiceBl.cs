using BL.BlApi;
using BL.Bo;
using Dal.DalApi;
using Dal.Dalimplementaion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BlImplementaion;

public class SubscriberServiceBl : ISubscriberRepoBl
{
    ISubscriberRepoDal subscriberRepoDal;
    public SubscriberServiceBl(ISubscriberRepoDal subscriberRepoDal)
    {
        this.subscriberRepoDal = subscriberRepoDal;
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

}

