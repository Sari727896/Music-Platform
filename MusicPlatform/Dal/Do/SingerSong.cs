using System;
using System.Collections.Generic;

namespace Dal.Do;

public partial class SingerSong
{
    public int Id { get; set; }

    public int SingerId { get; set; }

    public int SongId { get; set; }

    public virtual Singer Singer { get; set; }

    public virtual Song Song { get; set; }
}
