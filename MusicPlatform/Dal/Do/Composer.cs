﻿using System;
using System.Collections.Generic;

namespace Dal.Do;

public partial class Composer
{
    public int Code { get; set; }

    public string Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public int Age { get; set; }

    public int CityId { get; set; }

    public virtual City City { get; set; }

    public virtual ICollection<Song> Songs { get; set; } = new List<Song>();
}
