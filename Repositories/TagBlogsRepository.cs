using System;
using System.Data;
using Dapper;
using dotnet_bloggr.Models;

namespace dotnet_bloggr.Repositories
{
  public class TagBlogsRepository
  {
    private readonly IDbConnection _db;

    public TagBlogsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal TagBlog Create(TagBlog newTagBlog)
    {
      string sql = @"
        INSERT INTO tagblogs
        (blogId, tagId)
        VALUES
        (@BlogId, @TagId);
        SELECT LAST_INSERT_ID()";
      newTagBlog.Id = _db.ExecuteScalar<int>(sql, newTagBlog);
      return newTagBlog;
    }

    internal bool Delete(int id)
    {
      string sql = "DELETE FROM tagblogs WHERE id = @id LIMIT 1";
      int affectedRows = _db.Execute(sql, new { id });
      return affectedRows == 1;
    }
  }
}