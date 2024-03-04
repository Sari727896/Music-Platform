using System;
using System.Collections.Generic;

namespace Dal.Do;

public partial class Singer
{
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Description { get; set; }

    public int? CityId { get; set; }

    public int? Age { get; set; }

    public virtual City City { get; set; }

    public virtual ICollection<SingerSong> SingerSongs { get; set; } = new List<SingerSong>();
}
