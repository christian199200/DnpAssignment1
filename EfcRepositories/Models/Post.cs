namespace EfcRepositories.Models;

public class Post
{
    public int Id { get; set; }
    public string Title { get; set; }
    public String Body { get; set; }
    public int UserId { get; set; }
    
    public List<Comment> Comments { get; set; }

   private Post(){}
}