using Microsoft.AspNetCore.Mvc;
using ORG.PostsAPI.Interfaces;
using ORG.PostsAPI.Models;

namespace ORG.PostsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WatchLists : Controller
    {
        private readonly IWatchListService WatchListService;
        public WatchLists(IWatchListService watchListService)
        {
            WatchListService=watchListService;
        }

        [HttpGet]
        public async Task <ActionResult<WatchList>> GetWatchList([FromQuery] Guid watchListGuid)
        {
            if (watchListGuid != Guid.Empty)
            {
                WatchList watchList = await WatchListService.GetWatchList(watchListGuid);
                if (watchList == null)
                {
                    return NotFound();
                }
                /*
                Testando... 
                var newWatchList = new WatchList
                {
                    WatchListName = "My WatchList", // Set other properties as needed
                    Posts = new List<int>() // Initialize the Posts list
                };
                newWatchList.Posts.Add(1);
                newWatchList.Posts.Add(2);
                newWatchList.Posts.Add(3);
                newWatchList.Posts.Add(4);*/
                return Ok(watchList);
            }
            return BadRequest("Invalid GUID");
        }

        [HttpPost]
        public async Task<ActionResult<Post>> CreateWatchlist([FromBody] WatchList watchList)
        {
            if (watchList == null)
            {
                return BadRequest("Empty body");
            }
            Boolean created = await WatchListService.CreateWatchList(watchList);
            if (created)
            {
                return Created("Created", watchList);
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<ActionResult<Post>> UpdateWatchList([FromQuery]Guid watchListGuid, [FromBody] WatchList watchList)
        {
            if (watchList == null || watchListGuid != Guid.Empty)
            {
                return BadRequest("Empty body or invalid GUID");
            }
            Boolean updated = await WatchListService.UpdateWatchList(watchListGuid, watchList);
            if (updated)
            {
                return Created("updated", watchList);
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<ActionResult<Post>> DeleteWatchList([FromQuery]  Guid watchListGuid)
        {
            if (watchListGuid == Guid.Empty)
            {
                return BadRequest("Invalid GUID");
            }
            Boolean deleted = await WatchListService.DeleteWatchList(watchListGuid);
            if (deleted)
            {
                return Ok("Deleted");
            }
            return BadRequest("WatchList not found");
        }
    }
}
