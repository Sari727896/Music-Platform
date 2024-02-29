﻿using BL.BlApi;
using BL.Bo;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Server.Controllers
{
    public class SingersController : BaseController
    {

        ISingerRepoBl ISingerRepoBl;
        public SingersController(ISingerRepoBl ISingerRepoBl)
        {
            this.ISingerRepoBl = ISingerRepoBl;
        }
        [HttpGet]
        public ActionResult<List<Singer>> GetSingers()
        {
            if (ISingerRepoBl.GetAll() == null)
                return NotFound();
            return ISingerRepoBl.GetAll();
        }
        [HttpGet("{SingerId}")]
        public ActionResult<List<Song>> GetSingersSong(int SingerId)
        {
            if (ISingerRepoBl.GetSingerSongs(SingerId) == null)
            {
                return NotFound();
            }
            return ISingerRepoBl.GetSingerSongs(SingerId);
        }
        [HttpPost]
        public ActionResult<Singer> AddSinger(Singer singer)
        {
            if (singer == null)
            {
                return BadRequest();
            }
            ISingerRepoBl.Add(singer);
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

            return ISingerRepoBl.Update(singer, singerId);
        }
        [HttpDelete("{code}")]
        public ActionResult<Singer> DeletePatient(int code)
        {
            if (code < 0)
            {
                return BadRequest();
            }
            return ISingerRepoBl.Delete(code);
        }
    }
}