using BL.BlApi;
using BL.Bo;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Server.Controllers
{
    public class SingersController : BaseController
    {

        ISingerRepoBl SingerRepoBl;
        public SingersController(ISingerRepoBl SingerRepoBl)
        {
            this.SingerRepoBl = SingerRepoBl;
        }
        [HttpGet]
        public ActionResult<List<Singer>> GetSingers()
        {
            if (SingerRepoBl.GetAll() == null)
                return NotFound();
            return SingerRepoBl.GetAll();
        }
        [HttpGet("{SingerId}")]
        public ActionResult<List<Song>> GetSingersSong(int SingerId)
        {
            if (SingerRepoBl.GetSingerSongs(SingerId) == null)
            {
                return NotFound();
            }
            return SingerRepoBl.GetSingerSongs(SingerId);
        }
        [HttpPost]
        public ActionResult<Singer> AddSinger(Singer singer)
        {
            if (singer == null)
            {
                return BadRequest();
            }
            SingerRepoBl.Add(singer);
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

            return SingerRepoBl.Update(singer, singerId);
        }
        [HttpDelete("{code}")]
        public ActionResult<Singer> DeletePatient(int code)
        {
            if (code < 0)
            {
                return BadRequest();
            }
            return SingerRepoBl.Delete(code);
        }
    }
}