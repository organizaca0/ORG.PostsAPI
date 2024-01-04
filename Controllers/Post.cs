using Microsoft.AspNetCore.Mvc;
using ORG.PostsAPI.Interfaces;
using ORG.PostsAPI.Models;

namespace ORG.PostsAPI.Controllers
{
    public class Posts : Controller
    {
        private readonly IPostService PostService;

        public Posts(IPostService postService)
        {
            PostService=postService;  
        }

        [HttpGet]
        [Route("GetPost/{postId}")]
        public async Task <ActionResult<Post>> GetPost(int postId)
        {
            if(postId >= 0)
            {
                Post post = await PostService.GetPost(postId);
                if (post == null)
                {
                    return NotFound();
                }
                return Ok(post);
            }
            return BadRequest("Invalid ID");
        }

        [HttpPost]
        [Route("CreatePost")]
        public async Task<ActionResult<Post>> CreatePost([FromBody] Post post)
        {
            if (post == null)
            {
                return BadRequest("Empty body");
            }
            Boolean created = await PostService.CreatePost(post);
            if (created)
            {
                return Created("Created", post);
            }
            return BadRequest();
        }

        [HttpPut]
        [Route("UpdatePost/{postId}")]
        public async Task<ActionResult<Post>> UpdatePost(int postId, [FromBody] Post post)
        {
            if (post == null || postId <=0)
            {
                return BadRequest("Empty body or invalid ID");
            }
            Boolean updated = await PostService.UpdatePost(postId,post);
            if (updated)
            {
                return Created("updated", post);
            }
            return BadRequest();
        }

        [HttpPut]
        [Route("DeletePost/{postId}")]
        public async Task<ActionResult<Post>> DeletePost(int postId)
        {
            if (postId <=0)
            {
                return BadRequest("Invalid ID");
            }
            Boolean deleted = await PostService.DeletePost(postId);
            if (deleted)
            {
                return Ok("Deleted");
            }
            return BadRequest("Post not found");
        }

        [HttpPut]
        [Route("RatePost/{rating}/{postId}")]
        public async Task<ActionResult<Post>> RatePost(int postId, string rating)
        {
            if (rating == null || postId <=0)
            {
                return BadRequest("Empty kind of rating or invalid ID");
            }
            Boolean updated = await PostService.RatePost(postId, rating);
            if (updated)
            {
                return Created("Sucessfully rated ", postId);
            }
            return BadRequest();
        }
    }
}
