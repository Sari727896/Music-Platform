using BL.BlApi;
using BL.Bo;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Server.Controllers
{
    public class SingersController : BaseController
    {

        ISingerRepoBl singerRepoBl;
        public SingersController(ISingerRepoBl singerRepoBl)
        {
            this.singerRepoBl = singerRepoBl;
        }
        [HttpGet]
        public ActionResult<List<Singer>> GetSingers()
        {
            if (singerRepoBl.GetAll() == null)
                return NotFound();
            return singerRepoBl.GetAll();
        }
        [HttpGet("{SingerId}")]
        public ActionResult<List<Song>> GetSingersSong(int SingerId)
        {
            if (singerRepoBl.GetSingerSongs(SingerId) == null)
            {
                return NotFound();
            }
            return singerRepoBl.GetSingerSongs(SingerId);
        }
        [HttpPost]
        public ActionResult<Singer> AddSinger(Singer singer)
        {
            if (singer == null)
            {
                return BadRequest();
            }
            singerRepoBl.Add(singer);
            return singer;
        }
     
        [HttpPut("{singerId}")]
        public ActionResult<Singer> UpdateSinger([FromRoute] int singerId, [FromBody] Singer singer)
        {
            if (singer == null)
            {
                return BadRequest();
            }

            if (singerId < 0)
            {
                return BadRequest();
            }

            return singerRepoBl.Update(singer, singerId);
        }
        [HttpDelete("{code}")]
        public ActionResult<Singer> DeleteSinger(int code)
        {
            if (code < 0)
            {
                return BadRequest();
            }
            return singerRepoBl.Delete(code);
        }
    }
}