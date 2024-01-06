using Microsoft.AspNetCore.Mvc;
using ORG.PostsAPI.Interfaces;
using ORG.PostsAPI.Models;
using static ORG.PostsAPI.Enums.RateEnum;

namespace ORG.PostsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Posts : Controller
    {
        private readonly IPostService PostService;

        public Posts(IPostService postService)
        {
            PostService=postService;  
        }

        [HttpGet]
        public async Task <ActionResult<Post>> GetPost([FromQuery] Guid postGuid)
        {
            if(postGuid != Guid.Empty)
            {
                Post post = await PostService.GetPost(postGuid);
                if (post == null || !post.Content.Any())
                {
                    return NotFound("Post deleted or not found");
                }
                return Ok(post);
            }
            return BadRequest("Invalid GUID");
        }

        [HttpPost]
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

        [HttpPatch]
        [Route("posts/{postGuid}/rate")] // Improved routing for clarity
        public async Task<IActionResult> RatePost(Guid postGuid, [FromBody] string rating)
        {
            if (rating == null || postGuid == Guid.Empty)
            {
                return BadRequest("Empty rating or invalid GUID");
            }

            if (!Enum.IsDefined(typeof(RatingType), rating))
            {
                return BadRequest("Invalid rating type");
            }

            bool updated = await PostService.RatePost(postGuid, rating);

            if (updated)
            {
                return NoContent(); // Appropriate response for successful PATCH
            }

            return BadRequest();
        }

    }
}
