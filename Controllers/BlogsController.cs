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
    // Route path: https://localhost:5001/api/blogs
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

    //NOTE decision we made, this route does not follow standard conventions
    // Route path: https://localhost:5001/api/blogs/user
    [HttpGet("user")]
    public ActionResult<IEnumerable<Blog>> GetBlogsByUserEmail()
    {
      try
      {
        string creatorEmail = "Dmoney@momoney.com";
        return Ok(_bs.GetBlogsByUserEmail(creatorEmail));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    // Route path: https://localhost:5001/api/blogs/1
    [HttpGet("{id}")]
    public ActionResult<Blog> GetById(int id)
    {
      try
      {
        return Ok(_bs.GetById(id));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }


    // Route path: https://localhost:5001/api/blogs
    [HttpPost]
    public ActionResult<Blog> Create([FromBody] Blog newBlog)
    {
      try
      {
        newBlog.CreatorEmail = "Dmoney@momoney.com";
        return Ok(_bs.Create(newBlog));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    // Route path: https://localhost:5001/api/blogs/1
    [HttpDelete("{id}")]
    public ActionResult<Blog> Delete(int id)
    {
      try
      {
        return Ok(_bs.Delete(id));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpPut("{id}")]
    public ActionResult<Blog> Edit(int id, [FromBody] Blog updatedBlog)
    {
      try
      {
        return Ok(_bs.Edit(id, updatedBlog));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }
  }
}
