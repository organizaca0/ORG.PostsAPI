using Microsoft.EntityFrameworkCore;
using ORG.PostsAPI.Database;
using ORG.PostsAPI.Interfaces;
using ORG.PostsAPI.Models;

namespace ORG.PostsAPI.Services
{
    public class WatchListService : IWatchListService
    {
        private readonly DatabaseContext DbContext;

        public WatchListService(DatabaseContext dbContext)
        {
            DbContext=dbContext;
        }

        public async Task<bool> CreateWatchList(WatchList WatchList)
        {
            WatchList.WatchListGuid = Guid.NewGuid();
            WatchList.Active = true;
            DbContext.WatchLists.Add(WatchList);
            try
            {
                await DbContext.SaveChangesAsync();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public async Task<bool> DeleteWatchList(Guid watchListGuid)
        {
            var listToDelete = await DbContext.WatchLists.FindAsync(watchListGuid);

            if (listToDelete == null)
            {
                return false;
            }

            try
            {
                listToDelete.Active = false;
                await DbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<WatchList> GetWatchList(Guid watchListGuid)
        {
            WatchList watchList = await DbContext.WatchLists.FirstOrDefaultAsync(p => p.WatchListGuid == watchListGuid);
            return watchList?.Active == true ? watchList : null;
        }

        public async Task<bool> UpdateWatchList(Guid watchListGuid, WatchList updatedWatchList)
        {
            WatchList existingList = await DbContext.WatchLists.FirstOrDefaultAsync(p => p.WatchListGuid == watchListGuid);

            if (existingList != null)
            {
                existingList.WatchListName = updatedWatchList.WatchListName;
                existingList.Posts = updatedWatchList.Posts;
                await DbContext.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
