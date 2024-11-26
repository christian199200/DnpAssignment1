namespace EfcRepositories.Models;

public class Comment
{
    
    public Post Post { get; set; }
    public User User { get; set; }

    public int PostId { get;  }
    public int UserId { get;  }
    
    public int Id { get; set; }
    public String Body { get; set; }

  private Comment(){}
}