using Microsoft.AspNetCore.Mvc;
using BL.BlApi;
using BL.Bo;
using System.Collections.Generic;

namespace Server.Controllers
{
  
    public class SongsController : BaseController
    {
        ISongRepoBl ISongRepoBl;
        public SongsController(ISongRepoBl ISongRepoBl)
        {
            this.ISongRepoBl = ISongRepoBl;
        }
        [HttpGet("api/songs")]
        public ActionResult<List<Song>> Get()
        {
            if (ISongRepoBl.GetAll() == null)
                return NotFound();
            return ISongRepoBl.GetAll();
        }
        [HttpGet("api/publication-song")]
        public ActionResult<Song> GetPublicationSong()
        {
            if(ISongRepoBl.GetPublicationSong == null)
            {
                return NotFound();
            }
            return ISongRepoBl.GetPublicationSong();
        }
        [HttpPost]
        public ActionResult<Song> AddSong(Song song)
        {
            if (song == null)
            {
                return BadRequest();
            }
            ISongRepoBl.Add(song);
            return song;
        }
        [HttpPut("{songId}")]
        public ActionResult<Song> UpdateSong([FromRoute] int songId, [FromBody]Song  song)
        {
            if (song == null)
            {
                return BadRequest();
            }

            if (songId < 0)
            {
                return BadRequest();
            }

            return ISongRepoBl.Update(song, songId);
        }
        [HttpDelete("{code}")]
        public ActionResult<Song> DeleteSong(int code)
        {
            if (code < 0)
            {
                return BadRequest();
            }
            return ISongRepoBl.Delete(code);
        }
    }
}
