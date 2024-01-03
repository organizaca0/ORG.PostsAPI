using Microsoft.AspNetCore.Mvc;
using ORG.PostsAPI.Database;
using ORG.PostsAPI.Interfaces;
using ORG.PostsAPI.Models;

namespace ORG.PostsAPI.Controllers
{
    public class Posts : Controller
    {
        private readonly IPostService _postService;

        public Posts(IPostService postService)
        {
            _postService=postService;  
        }

        [HttpGet]
        [Route("GetPost")]
        public ActionResult<Post> GetPost(int postId)
        {
            Post post = _postService.GetPost(postId);
            if(post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }

        [HttpPost]
        [Route("CreatePost")]
        public async Task<ActionResult<Post>> CreatePost(Post post)
        {
            if (post == null)
            {
                return BadRequest("Empty body");
            }
            Boolean created = await _postService.CreatePost(post);
            if (created)
            {
                return Created("Created", post);
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("UpdatePost")]
        public async Task<ActionResult<Post>> UpdatePost(int postId,Post post)
        {
            if (post == null)
            {
                return BadRequest("Empty body");
            }
            Boolean updated = await _postService.UpdatePost(postId,post);
            if (updated)
            {
                return Created("updated", post);
            }
            return BadRequest();
        }
    }
}
