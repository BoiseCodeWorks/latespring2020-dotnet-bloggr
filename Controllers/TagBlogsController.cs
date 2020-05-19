using dotnet_bloggr.Models;
using dotnet_bloggr.Services;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_bloggr.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class TagBlogsController : ControllerBase
  {
    private readonly TagBlogsService _tbs;

    public TagBlogsController(TagBlogsService tbs)
    {
      _tbs = tbs;
    }

    [HttpPost]
    public ActionResult<TagBlog> Create([FromBody] TagBlog newTagBlog)
    {
      try
      {
        return Ok(_tbs.Create(newTagBlog));
      }
      catch (System.Exception)
      {

        throw;
      }
    }
  }
}