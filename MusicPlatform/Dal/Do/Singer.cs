using System;
using System.Collections.Generic;

namespace Dal.Do;

public partial class Singer
{
    public int Code { get; set; }

    public string Id { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Description { get; set; }

    public int CityId { get; set; }

    public int Age { get; set; }

    public virtual City City { get; set; } = null!;

    public virtual ICollection<Song> Songs { get; set; } = new List<Song>();
}
