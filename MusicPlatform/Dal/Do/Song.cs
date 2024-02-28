using System;
using System.Collections.Generic;

namespace Dal.Do;

public partial class Song
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int SingerId { get; set; }

    public int? AlbumId { get; set; }

    public string TheSongWriter { get; set; } = null!;

    public int ComposerId { get; set; }

    public int ProcessorId { get; set; }

    public string Description { get; set; } = null!;

    public DateTime PublicationDate { get; set; }

    public virtual Album? Album { get; set; }

    public virtual Composer Composer { get; set; } = null!;

    public virtual Processor Processor { get; set; } = null!;

    public virtual ICollection<Rating> Ratings { get; set; } = new List<Rating>();

    public virtual Singer Singer { get; set; } = null!;
}
