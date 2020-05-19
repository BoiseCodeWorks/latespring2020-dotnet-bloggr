namespace dotnet_bloggr.Models
{
  public class Tag
  {
    public int Id { get; set; }
    public string Title { get; set; }
  }


  //NOTE this is for our Many-To-Many table
  public class TagBlog
  {
    public int Id { get; set; }
    public int BlogId { get; set; }
    public int TagId { get; set; }
    //NOTE if i wanted to control by a user as well
    // public string CreatorEmail { get; set; }
  }
}