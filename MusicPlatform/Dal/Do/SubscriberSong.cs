using System;
using System.Collections.Generic;

namespace Dal.Do;

public partial class SubscriberSong
{
    public int Id { get; set; }

    public int SubscriberId { get; set; }

    public int SongId { get; set; }

    public virtual Song Song { get; set; }

    public virtual Subscriber Subscriber { get; set; }
}
