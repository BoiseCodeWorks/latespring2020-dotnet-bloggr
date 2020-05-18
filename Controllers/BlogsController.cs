using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_bloggr.Models;
using dotnet_bloggr.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace dotnet_bloggr.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class BlogsController : ControllerBase
  {
    private readonly BlogsService _bs;

    public BlogsController(BlogsService bs)
    {
      _bs = bs;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Blog>> GetAll()
    {
      try
      {
        return Ok(_bs.GetAll());
      }
      catch (System.Exception)
      {
        throw;
      }
    }

  }
}
