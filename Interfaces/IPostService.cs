using Microsoft.AspNetCore.Mvc;
using ORG.PostsAPI.Models;

namespace ORG.PostsAPI.Interfaces
{
    public interface IPostService
    {
        Task<Boolean> CreatePost(Post post);
        Task <Boolean> UpdatePost(Guid postGuid, Post updatedPost);
        Task<Boolean> DeletePost(Guid postGuid);
        Task<Boolean> RatePost(Guid postGuid, string rating);
        Task <Post> GetPost(Guid postGuid);
        IEnumerable<Post> GetAllPosts();
    }
}
