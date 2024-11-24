namespace DTOs;

public class CreateCommentDto
{
    public int AuthorUserId { get; set; }
    public string Body { get; set; }
    public string PostId { get; set; }
}