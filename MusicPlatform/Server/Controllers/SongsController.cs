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
        [HttpGet]
        public ActionResult<List<Song>> Get()
        {
            if (ISongRepoBl.GetAll() == null)
                return NotFound();
            return ISongRepoBl.GetAll();
        }
        [HttpGet("{SongId}")]
        public Song GetPublocationSong(int SongId)
        {
            return ISongRepoBl.GetPublicationSong();
        }
    }
}
