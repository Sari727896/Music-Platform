using System;
using System.Collections.Generic;

namespace Dal.Do;

public partial class Song
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int? AlbumId { get; set; }

    public string TheSongWriter { get; set; }

    public string Description { get; set; }

    public DateTime PublicationDate { get; set; }

    public string ComposerName { get; set; }

    public string ProcessorName { get; set; }

    public virtual Album Album { get; set; }

    public virtual ICollection<Rating> Ratings { get; set; } = new List<Rating>();

    public virtual ICollection<SingerSong> SingerSongs { get; set; } = new List<SingerSong>();

    public virtual ICollection<SubscriberSong> SubscriberSongs { get; set; } = new List<SubscriberSong>();
}
