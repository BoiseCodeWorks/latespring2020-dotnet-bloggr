using System.Collections.Generic;
using dotnet_bloggr.Models;
using dotnet_bloggr.Repositories;

namespace dotnet_bloggr.Services
{
  public class BlogsService
  {
    private readonly BlogsRepository _repo;

    public BlogsService(BlogsRepository repo)
    {
      _repo = repo;
    }
    public IEnumerable<Blog> GetAll()
    {
      return _repo.GetAll();
    }
  }
}