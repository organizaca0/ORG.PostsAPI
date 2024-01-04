using ORG.PostsAPI.Models;
using System;

namespace ORG.PostsAPI.Interfaces
{
    public interface IWatchListService
    {
        Task <WatchList> GetWatchList(Guid WatchListGuid);
        Task<Boolean> CreateWatchList(WatchList WatchList);

        Task<Boolean> UpdateWatchList(Guid WatchListGuid, WatchList updatedWatchList);
        Task<Boolean> DeleteWatchList(Guid WatchListGuid);
    }
}
