﻿using Dal.Do;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.DalApi;

public interface ISubscriberRepoDal:IRepo<Subscriber>
{
    public List<SubscriberSong> GetSubscriberSongs(int suscriberId);
}
