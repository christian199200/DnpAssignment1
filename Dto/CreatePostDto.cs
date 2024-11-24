namespace DTOs;

public class CreatePostDto
{
    public int AuthorUserId { get; set; }
    public string Body { get; set; }
    public string Title { get; set; }
}