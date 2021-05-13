using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BertoniController : ControllerBase
    {
        [HttpGet]
        public String Get()
        {
            return "This is one of the Micro-Service's for Music Library projects. Test Bertoni";
        }
    }
}
