using Microsoft.AspNetCore.Mvc;
using ORG.PostsAPI.Models;

namespace ORG.PostsAPI.Interfaces
{
    public interface IPostService
    {
        Task<Boolean> CreatePost(Post post);
        Task <Boolean> UpdatePost(int postId, Post updatedPost);
        Task<Boolean> DeletePost(int postId);
        Task<Boolean> RatePost(int postId, string rating);
        Task <Post> GetPost(int postId);
        IEnumerable<Post> GetAllPosts();
    }
}
