namespace EfcRepositories.Models;

public class User
{
    public int Id { get; set; }
    public String UserName { get; set; }
    public String Password { get; set; }
    
    public List<Comment> Comments { get; set; }

  private User(){}
}