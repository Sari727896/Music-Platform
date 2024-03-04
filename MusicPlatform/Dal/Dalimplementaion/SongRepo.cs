
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.Do;
using Dal.DalApi;
using Microsoft.EntityFrameworkCore;

namespace Dal.Dalimplementaion
{
    public class SongRepo : ISongRepoDal
    {
        MusicContext musicContext;
        public SongRepo(MusicContext musicContext)
        {
            this.musicContext = musicContext;
        }
        public List<Song> GetAll()
        {
            IEnumerable<Song> songs = musicContext.Songs.Include(s => s.Singer);
            if (songs == null)
                return null;
            return songs.ToList();
        }
        public Song Add(Song song)
        {
            musicContext.Songs.Add(song);
            musicContext.SaveChanges();
            return song;
        }
        public Song Update(Song song, int id)
        {
            Song songToUpdate = musicContext.Songs.FirstOrDefault(p => p.Id == id);
            if (songToUpdate != null)
            {
                songToUpdate.TheSongWriter = song.TheSongWriter;
                musicContext.SaveChanges();
                return songToUpdate;
            }
            return null;
        }
        public Song Delete(int id)
        {
            Song songToDelete = musicContext.Songs.FirstOrDefault(p => p.Id == id);
            if (songToDelete != null)
            {
                musicContext.Songs.Remove(songToDelete);
                musicContext.SaveChanges();
                return songToDelete;
            }
            return null;
        }

    }
}
