using BL.BlApi;
using BL.Bo;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Server.Controllers
{
    public class SingersController:BaseController
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
    }
}
