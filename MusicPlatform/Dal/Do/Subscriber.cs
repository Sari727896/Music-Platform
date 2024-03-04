using System;
using System.Collections.Generic;

namespace Dal.Do;

public partial class Subscriber
{
    public int Code { get; set; }

    public string Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public virtual ICollection<SubscriberSong> SubscriberSongs { get; set; } = new List<SubscriberSong>();
}
