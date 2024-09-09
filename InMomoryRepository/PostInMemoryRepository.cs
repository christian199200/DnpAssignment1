﻿using Entities;
using RepositoryContracts;

namespace InMomoryRepository;

public class PostInMemoryRepository: IPostRepository
{
    List<Post> posts = new List<Post>();
    
    public Task<Post> AddAsync(Post post) 
    { 
        post.Id = posts.Any()  
            ? posts.Max(p => p.Id) + 1 
            : 1; 
        posts.Add(post); 
        return Task.FromResult(post); 
    }

    public Task UpdateAsync(Post post)
    {
        
        
        Post? existingPost = posts.SingleOrDefault(p => p.Id == post.Id); 
        if (existingPost is null) 
        { 
            throw new InvalidOperationException( 
                $"Post with ID '{post.Id}' not found"); 
        } 
        posts.Remove(existingPost); 
        posts.Add(post); 
        return Task.CompletedTask; 
    }

    public Task DeleteAsync(int id)
    {
       
        Post? postToRemove = posts.SingleOrDefault(p => p.Id == id); 
        if (postToRemove is null) 
        { 
            throw new InvalidOperationException( 
                $"Post with ID '{id}' not found"); 
        } 
        posts.Remove(postToRemove); 
        return Task.CompletedTask; 
        
    }

    public Task<Post> GetSingleAsync(int id)
    {
        throw new NotImplementedException();
        //To do
       // return Task.FromResult(post);
    }

    public IQueryable<Post> GetMany()
    {
        return posts.AsQueryable(); 
    }
}