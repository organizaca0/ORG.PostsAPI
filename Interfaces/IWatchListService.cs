using ORG.PostsAPI.Models;

namespace ORG.PostsAPI.Interfaces
{
    public interface IWatchListService
    {
        Task <WatchList> GetWatchList(int WatchListId);
        Task<Boolean> CreateWatchList(WatchList WatchList);

        Task<Boolean> UpdateWatchList(int WatchListId,WatchList updatedWatchList);
        Task<Boolean> DeleteWatchList(int postId);
    }
}
