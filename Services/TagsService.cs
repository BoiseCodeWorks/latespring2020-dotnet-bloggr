using System;
using System.Collections.Generic;
using dotnet_bloggr.Models;
using dotnet_bloggr.Repositories;

namespace dotnet_bloggr.Services
{
  public class TagsService
  {
    private readonly TagsRepository _repo;

    public TagsService(TagsRepository repo)
    {
      _repo = repo;
    }
    internal Tag Create(Tag newTag)
    {
      return _repo.Create(newTag);
    }

    internal IEnumerable<Tag> GetAll()
    {
      return _repo.GetAll();
    }
  }
}


