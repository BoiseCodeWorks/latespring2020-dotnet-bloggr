using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using dotnet_bloggr.Models;

namespace dotnet_bloggr.Repositories
{
  public class BlogsRepository
  {
    private readonly IDbConnection _db;

    public BlogsRepository(IDbConnection db)
    {
      _db = db;
    }
    internal IEnumerable<Blog> GetAll()
    {
      string sql = "SELECT * FROM blogs WHERE isPublished = 1";
      return _db.Query<Blog>(sql);
    }

    internal Blog Create(Blog newBlog)
    {
      string sql = @"
      INSERT INTO blogs
      (title, body, isPublished, creatorEmail)
      VALUES
      (@Title, @Body, @IsPublished, @CreatorEmail);
      SELECT LAST_INSERT_ID()";
      newBlog.Id = _db.ExecuteScalar<int>(sql, newBlog);
      return newBlog;
    }

    internal IEnumerable<Blog> GetBlogsByUserEmail(string creatorEmail)
    {
      string sql = "SELECT * FROM blogs WHERE creatorEmail = @CreatorEmail";
      return _db.Query<Blog>(sql, new { creatorEmail });
    }

    internal Blog GetById(int id)
    {
      string sql = "SELECT * FROM blogs WHERE id = @Id";
      return _db.QueryFirstOrDefault<Blog>(sql, new { id });
    }

    internal bool Delete(int id)
    {
      string sql = "DELETE FROM blogs WHERE id = @Id LIMIT 1";
      int affectedRows = _db.Execute(sql, new { id });
      return affectedRows == 1;
    }

    internal Blog Edit(Blog blogToUpdate)
    {
      string sql = @"
        UPDATE blogs
        SET
          title = @Title,
          body = @Body,
          isPublished = @IsPublished
        WHERE id = @Id LIMIT 1";
      _db.Execute(sql, blogToUpdate);
      return blogToUpdate;
    }
  }
}