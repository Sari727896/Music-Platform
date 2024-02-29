using System;
using System.Collections.Generic;

namespace Dal.Do;

public partial class Rating
{
    public int Id { get; set; }

    public int AmountOfLikes { get; set; }

    public int AmountOfPlays { get; set; }

    public int SongId { get; set; }

    public virtual Song Song { get; set; }
}
