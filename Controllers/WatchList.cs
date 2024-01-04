using Microsoft.AspNetCore.Mvc;
using ORG.PostsAPI.Interfaces;
using ORG.PostsAPI.Models;

namespace ORG.PostsAPI.Controllers
{
    public class WatchLists : Controller
    {
        private readonly IWatchListService WatchListService;
        public WatchLists(IWatchListService watchListService)
        {
            WatchListService=watchListService;
        }
        [HttpGet]
        [Route("GetWatchList/{watchListId}")]
        public async Task <ActionResult<WatchList>> GetWatchList(int watchListId)
        {
            if (watchListId >= 0)
            {
                WatchList watchList = await WatchListService.GetWatchList(watchListId);
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
            return BadRequest("Invalid ID");
        }

        [HttpPost]
        [Route("CreateWatchList")]
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
        [Route("UpdateWatchList/{listId}")]
        public async Task<ActionResult<Post>> UpdatePost(int listId, [FromBody] WatchList watchList)
        {
            if (watchList == null || listId <=0)
            {
                return BadRequest("Empty body or invalid ID");
            }
            Boolean updated = await WatchListService.UpdateWatchList(listId, watchList);
            if (updated)
            {
                return Created("updated", watchList);
            }
            return BadRequest();
        }

        [HttpPut]
        [Route("DeleteWatchList/{listId}")]
        public async Task<ActionResult<Post>> DeleteWatchList(int listId)
        {
            if (listId <=0)
            {
                return BadRequest("Invalid ID");
            }
            Boolean deleted = await WatchListService.DeleteWatchList(listId);
            if (deleted)
            {
                return Ok("Deleted");
            }
            return BadRequest("WatchList not found");
        }

    }
}
