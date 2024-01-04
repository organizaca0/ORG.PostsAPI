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

        public async Task<bool> DeleteWatchList(int watchListId)
        {
            var listToDelete = await DbContext.WatchLists.FindAsync(watchListId);

            if (listToDelete == null)
            {
                return false;
            }

            try
            {
                DbContext.WatchLists.Remove(listToDelete);
                await DbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<WatchList> GetWatchList(int WatchListId)
        {
            WatchList watchList = await DbContext.WatchLists.FirstOrDefaultAsync(p => p.WatchListId == WatchListId);
            return watchList;
        }

        public async Task<bool> UpdateWatchList(int WatchListId, WatchList updatedWatchList)
        {
            WatchList existingList = await DbContext.WatchLists.FirstOrDefaultAsync(p => p.WatchListId == WatchListId);

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
