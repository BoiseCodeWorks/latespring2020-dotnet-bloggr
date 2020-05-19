using System;
using dotnet_bloggr.Models;
using dotnet_bloggr.Repositories;

namespace dotnet_bloggr.Services
{
  public class TagBlogsService
  {
    private readonly TagBlogsRepository _repo;

    public TagBlogsService(TagBlogsRepository repo)
    {
      _repo = repo;
    }

    internal TagBlog Create(TagBlog newTagBlog)
    {
      return _repo.Create(newTagBlog);
    }
  }
}