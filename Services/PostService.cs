using Microsoft.EntityFrameworkCore;
using ORG.PostsAPI.Database;
using ORG.PostsAPI.Interfaces;
using ORG.PostsAPI.Models;
using Ganss.Xss;

namespace ORG.PostsAPI.Services
{
    public class PostService : IPostService
    {
        private readonly DatabaseContext DbContext;

        public PostService(DatabaseContext dbContext)
        {
            DbContext=dbContext;
        }

        public async Task<Boolean> CreatePost(Post post)
        {
            post.ReadTime = CalculateReadTime(post.Content);
            post.PositiveScore = 0;
            post.NegativeScore = 0;
            post.Content = SanitizeHtml(post.Content);
            DbContext.Posts.Add(post);
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
        public async Task<bool> DeletePost(int postId)
        {
            var postToDelete = await DbContext.Posts.FindAsync(postId);

            if (postToDelete == null)
            {
                return false;
            }

            try
            {
                DbContext.Posts.Remove(postToDelete);
                await DbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> RatePost(int postId, string rating)
        {
            var postToRate = await DbContext.Posts.FindAsync(postId);

            if (postToRate == null)
            {
                return false;
            }

            try
            {
                switch (rating)
                {
                    case "positive":
                        postToRate.PositiveScore ++;
                        break;
                    case "negative":
                        postToRate.NegativeScore ++;
                        break;
                }

                await DbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task <Post> GetPost(int postId)
        {
            Post post = await DbContext.Posts.FirstOrDefaultAsync(p => p.PostId == postId);
            return post;
        }
        public async Task<bool> UpdatePost(int postId, Post updatedPost)
        {
            Post existingPost = await DbContext.Posts.FirstOrDefaultAsync(p => p.PostId == postId);

            if (existingPost != null)
            {
                existingPost.Title = updatedPost.Title;
                existingPost.Content = SanitizeHtml(updatedPost.Content);
                existingPost.Tags = updatedPost.Tags;
                existingPost.ReadTime = CalculateReadTime(updatedPost.Content);

                try
                {
                    await DbContext.SaveChangesAsync();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public IEnumerable<Post> GetAllPosts()
        {
            throw new NotImplementedException();
        }
        public static string CalculateReadTime(string postContent)
        {
            const int wordsPerMinute = 180;
            const int wordsPerSecond = 60;
            int wordCount = CountWords(postContent);

            if (wordCount == 0)
            {
                return "0min";
            }

            double readTimeMinutes = (double)wordCount / wordsPerMinute;

            if (readTimeMinutes < 1)
            {
                // If read time is less than 1 minute, format as seconds
                int readTimeSeconds = (int)(readTimeMinutes * wordsPerSecond);
                return $"{readTimeSeconds}s";
            }

            // Format read time in minutes
            return $"{(int)readTimeMinutes}min";
        }
        private static int CountWords(string text)
        {
            // Simple word count logic (considering space as a word separator)
            if (string.IsNullOrWhiteSpace(text))
            {
                return 0;
            }

            string[] words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return words.Length;
        }
        
        ///<summary>
        /// Isso limpa o HTML de possíveis ataques XSS.
        ///</summary>
        private string SanitizeHtml (string htmlContent)
        {
            var sanitizer = new HtmlSanitizer();
            return sanitizer.Sanitize(htmlContent);
        }


    }
}
