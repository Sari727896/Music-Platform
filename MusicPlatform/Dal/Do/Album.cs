using System;
using System.Collections.Generic;

namespace Dal.Do;

public partial class Album
{
    public int Code { get; set; }

    public string Name { get; set; }

    public DateTime? PublicationDate { get; set; }

    public virtual ICollection<Song> Songs { get; set; } = new List<Song>();
}
