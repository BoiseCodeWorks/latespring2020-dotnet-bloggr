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

    private readonly BlogsService _bs;

    public TagsController(TagsService ts, BlogsService bs)
    {
      _ts = ts;
      _bs = bs;
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

    [HttpGet("{id}/blogs")]
    public ActionResult<IEnumerable<TagBlogViewModel>> GetBlogsByTagId(int id)
    {
      try
      {
        //NOTE We could go request to get the tag, and make sure it exists right here by using the tag service.
        return Ok(_bs.GetBlogsByTagId(id));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
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