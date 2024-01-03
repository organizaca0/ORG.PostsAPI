using Microsoft.AspNetCore.Mvc;
using ORG.PostsAPI.Database;
using ORG.PostsAPI.Models;

namespace ORG.PostsAPI.Controllers
{
    public class Posts : Controller
    {
        private readonly DatabaseContext _dbContext;

        public Posts(DatabaseContext dbContext)
        {
            _dbContext=dbContext;
        }

        [HttpGet]
        [Route("GetPosts")]
        public IActionResult GetPost(int Amount)
        {
            List<Post> posts = _dbContext.Posts
                .Take(Amount)
                .ToList();
            return Ok(posts);
        }
    }
}
