using System;
using System.Collections.Generic;

namespace Dal.Do;

public partial class City
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int CountryId { get; set; }

    public virtual ICollection<Composer> Composers { get; set; } = new List<Composer>();

    public virtual Country Country { get; set; }

    public virtual ICollection<Processor> Processors { get; set; } = new List<Processor>();

    public virtual ICollection<Singer> Singers { get; set; } = new List<Singer>();
}
