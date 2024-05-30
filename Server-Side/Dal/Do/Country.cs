using System;
using System.Collections.Generic;

namespace Dal.Do;

public partial class Country
{
    public int Id { get; set; }

    public string Name { get; set; }

    public virtual ICollection<City> Cities { get; set; } = new List<City>();
}
