using System.Text.Json;
using Entities;
using RepositoryContracts;

namespace FIleRepositories;

public class CommentFileRepository : ICommentRepository
{
    private readonly string filePath = "comments.json";

    public CommentFileRepository()
    {
        if (!File.Exists(filePath))
        {
            File.WriteAllText(filePath, "[]");
        }
    }

    public async Task<Comment> AddAsync(Comment comment)
    {
        string commentsAsJson = await File.ReadAllTextAsync(filePath);
        List<Comment> comments = JsonSerializer.Deserialize<List<Comment>>(commentsAsJson) ?? new List<Comment>();
        int maxId = comments.Count > 0 ? comments.Max(c => c.Id) : 1;
        comment.Id = maxId + 1;
        comments.Add(comment);
        commentsAsJson = JsonSerializer.Serialize(comments);
        await File.WriteAllTextAsync(filePath, commentsAsJson);
        return comment;
    }

    public Task UpdateAsync(Comment comment)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Comment> GetSingleAsync(int id)
    {
        throw new NotImplementedException();
    }

    public IQueryable<Comment> GetMany()
    {
        throw new NotImplementedException();
    }

    public async Task<Comment> GetByIdAsync(int commentId)
    {
        string commentsAsJson = await File.ReadAllTextAsync(filePath);
        List<Comment> comments = JsonSerializer.Deserialize<List<Comment>>(commentsAsJson) ?? new List<Comment>();
        return comments.SingleOrDefault(c => c.Id == commentId);
    }

    public IQueryable<Comment> GetAll()
    {
        string commentsAsJson = File.ReadAllTextAsync(filePath).Result;
        List<Comment> comments = JsonSerializer.Deserialize<List<Comment>>(commentsAsJson) ?? new List<Comment>();
        return comments.AsQueryable();
    }
}