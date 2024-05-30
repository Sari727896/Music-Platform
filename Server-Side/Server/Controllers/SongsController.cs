﻿using Microsoft.AspNetCore.Mvc;
using BL.BlApi;
using BL.Bo;
using System.Collections.Generic;
using BL;

namespace Server.Controllers;
public class SongsController : BaseController
{
    ISongRepoBl songRepoBl;
    public SongsController(BLManager bLManager)
    {
        this.songRepoBl = bLManager.Songs;
    }
    [HttpGet("api/songs")]
    public ActionResult<List<Song>> Get()
    {
        if (songRepoBl.GetAll() == null)
            return NotFound();
        return songRepoBl.GetAll();
    }
    [HttpGet("api/Current-songs")]
    public ActionResult<List<Song>> GetPublicationSong()
    {
        if(songRepoBl.GetRecentSongs() == null)
        {
            return NotFound();
        }
        return songRepoBl.GetRecentSongs();
    }
    [HttpPost]
    public ActionResult<Song> AddSong(Song song)
    {
        if (song == null)
        {
            return BadRequest();
        }
        songRepoBl.Add(song);
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

        return songRepoBl.Update(song, songId);
    }
    [HttpDelete("{code}")]
    public ActionResult<Song> DeleteSong(int code)
    {
        if (code < 0)
        {
            return BadRequest();
        }
        return songRepoBl.Delete(code);
    }
}
