namespace Entities;

public class Comment
{
    public int Id { get; set; }
    public String Body { get; set; }
    public int PostId { get;  }
    public int UserId { get;  }

    public Comment(string body, int postId, int userId)
    {
        Body = body;
        PostId = postId;
        UserId = userId;
    }
}