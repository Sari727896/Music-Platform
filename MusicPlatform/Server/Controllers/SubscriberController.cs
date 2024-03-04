using BL.BlApi;
using BL.Bo;
using Dal.DalApi;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers;

public class SubscriberController:BaseController
{
    ISubscriberRepoBl subscriberRepoBl;
    public SubscriberController(ISubscriberRepoBl subscriberRepoBl)
    {
        this.subscriberRepoBl = subscriberRepoBl;
    }
    [HttpGet]
    public ActionResult<List<Subscriber>> GetSubscribers()
    {
        if (subscriberRepoBl.GetAll() == null)
            return NotFound();
        return subscriberRepoBl.GetAll();
    }

    [HttpPost]
    public ActionResult<Subscriber> AddSubscriber(Subscriber subscriber)
    {
        if (subscriber == null)
            return BadRequest();
        subscriberRepoBl.Add(subscriber);
        return subscriber;
    }

    [HttpPut("{subscriberId}")]
    public ActionResult<Subscriber> UpdateSinger([FromRoute] int subscriberId, [FromBody]Subscriber subscriber)
    {
        if (subscriber == null)
            return BadRequest();
        if (subscriberId < 0)
            return BadRequest();
        return subscriberRepoBl.Update(subscriber, subscriberId);
    }

    [HttpDelete("{id}")]
    public ActionResult<Subscriber> DeleteSubscriber(int id)
    {
        if (id < 0)
            return BadRequest();
        return subscriberRepoBl.Delete(id);
    }
}
