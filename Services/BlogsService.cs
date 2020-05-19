using System;
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
    internal IEnumerable<Blog> GetBlogsByUserEmail(string creatorEmail)
    {
      return _repo.GetBlogsByUserEmail(creatorEmail);
    }
    internal IEnumerable<TagBlogViewModel> GetBlogsByTagId(int id)
    {
      return _repo.GetBlogsByTagId(id);
    }

    internal Blog Create(Blog newBlog)
    {
      Blog createdBlog = _repo.Create(newBlog);
      return createdBlog;
    }

    internal Blog GetById(int id)
    {
      Blog foundBlog = _repo.GetById(id);
      if (foundBlog == null)
      {
        throw new Exception("Invalid id.");
      }
      return foundBlog;
    }

    internal Blog Delete(int id)
    {
      Blog foundBlog = GetById(id);
      if (_repo.Delete(id))
      {
        return foundBlog;
      }
      throw new Exception("Something bad happened...");
    }


    internal Blog Edit(int id, Blog updatedBlog)
    {
      Blog foundBlog = GetById(id);
      //NOTE GetById() is already handling our null checking
      foundBlog.IsPublished = updatedBlog.IsPublished;
      foundBlog.Body = updatedBlog.Body;
      foundBlog.Title = updatedBlog.Title;
      return _repo.Edit(foundBlog);
    }

  }
}