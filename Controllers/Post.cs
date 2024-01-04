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
        [Route("GetPost")]
        public async Task <ActionResult<Post>> GetPost([FromQuery] Guid postGuid)
        {
            if(postGuid != Guid.Empty)
            {
                Post post = await PostService.GetPost(postGuid);
                if (post == null)
                {
                    return NotFound("Post deleted or not found");
                }
                return Ok(post);
            }
            return BadRequest("Invalid GUID");
        }

        [HttpPost]
        [Route("CreatePost")]
        public async Task<ActionResult<Post>> CreatePost([FromBody] Post post)
        {
            if (post == null || post.UserGuid != Guid.Empty)
            {
                return BadRequest("Empty body or invalid User");
            }
            Boolean created = await PostService.CreatePost(post);
            if (created)
            {
                return Created("Created", post);
            }
            return BadRequest();
        }

        [HttpPut]
        [Route("UpdatePost")]
        public async Task<ActionResult<Post>> UpdatePost([FromQuery] Guid postGuid, [FromBody] Post post)
        {
            if (post == null || postGuid == Guid.Empty)
            {
                return BadRequest("Empty body or invalid ID");
            }
            Boolean updated = await PostService.UpdatePost(postGuid, post);
            if (updated)
            {
                return Created("updated", post);
            }
            return BadRequest();
        }

        [HttpPut]
        [Route("DeletePost")]
        public async Task<ActionResult<Post>> DeletePost([FromQuery] Guid postGuid)
        {
            if (postGuid == Guid.Empty)
            {
                return BadRequest("Invalid GUID");
            }
            Boolean deleted = await PostService.DeletePost(postGuid);
            if (deleted)
            {
                return Ok("Deleted");
            }
            return BadRequest("Post not found");
        }

        [HttpPut]
        [Route("RatePost")]
        public async Task<ActionResult<Post>> RatePost([FromQuery] Guid postGuid, [FromQuery] string rating)
        {
            if (rating == null || postGuid == Guid.Empty)
            {
                return BadRequest("Empty kind of rating or invalid GUID");
            }
            Boolean updated = await PostService.RatePost(postGuid, rating);
            if (updated)
            {
                return Created("Sucessfully rated ", postGuid);
            }
            return BadRequest();
        }
    }
}
