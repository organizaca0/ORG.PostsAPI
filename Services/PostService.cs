using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ORG.PostsAPI.Database;
using ORG.PostsAPI.Interfaces;
using ORG.PostsAPI.Models;
using System;
using System.Diagnostics.CodeAnalysis;

namespace ORG.PostsAPI.Services
{
    public class PostService : IPostService
    {
        private readonly DatabaseContext _dbContext;

        public PostService(DatabaseContext dbContext)
        {
            _dbContext=dbContext;
        }

        public async Task<Boolean> CreatePost(Post post)
        {
            _dbContext.Posts.Add(post);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public void DeletePost(int postId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetAllPosts()
        {
            throw new NotImplementedException();
        }

        public Post GetPost(int postId)
        {
            Post post = _dbContext.Posts.FirstOrDefault(p => p.PostId == postId);
            return post;
        }


        public async Task<Boolean> UpdatePost(int postId,Post post)
        {
            throw new NotImplementedException();
        }
    }
}
