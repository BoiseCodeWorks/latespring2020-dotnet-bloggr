using System.ComponentModel.DataAnnotations;

namespace dotnet_bloggr.Models
{
  public class Blog
  {
    public int Id { get; set; }
    [Required]
    [MaxLength(80)]
    public string Title { get; set; }
    public string Body { get; set; }
    public bool IsPublished { get; set; }
    public string CreatorEmail { get; set; }
  }

  public class TagBlogViewModel : Blog
  {
    public int TagBlogId { get; set; }
    public string Tag { get; set; }
  }

}