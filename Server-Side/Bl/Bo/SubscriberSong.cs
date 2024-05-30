using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Bo;

internal class SubscriberSong
{
    public int Id { get; set; }

    public int SubscriberId { get; set; }

    public int SongId { get; set; }

    public virtual Song Song { get; set; }

    public virtual Subscriber Subscriber { get; set; }
}
