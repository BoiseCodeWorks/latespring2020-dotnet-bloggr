using System.Collections.Generic;
using dotnet_bloggr.Models;
using dotnet_bloggr.Services;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_bloggr.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class TagsController : ControllerBase
  {
    private readonly TagsService _ts;

    public TagsController(TagsService ts)
    {
      _ts = ts;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Tag>> GetAll()
    {
      try
      {
        return Ok(_ts.GetAll());
      }
      catch (System.Exception)
      {

        throw;
      }
    }

    [HttpPost]
    public ActionResult<Tag> Create([FromBody] Tag newTag)
    {
      try
      {
        return Ok(_ts.Create(newTag));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

  }
}