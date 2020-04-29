using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Z.EntityFramework.Plus;

namespace EntityFrameworkTest.Samples
{
    public static class Sample23
    {
        public const string Accounts = "Accounts";

        public static async Task Run()
        {
            // Caching

            // 1. Read from a database and put into cache
            await using var context = new SampleContext();
            var users1= await context.Accounts.FromCacheAsync(Accounts);

            // 2. Read from cache (even if we are using another context)
            await using var anotherContext = new SampleContext();
            var users2= await anotherContext.Accounts.FromCacheAsync(Accounts);

            // 3. Read from cache and put into cache (doesn't clear previous cache)
            var users3= await context.Accounts.Where(a => !a.DeletedAt.HasValue).FromCacheAsync(Accounts);

            // 4. Read from cache
            var users4= await anotherContext.Accounts.FromCacheAsync(Accounts);

            // 5. Read from cache
            var users5= await context.Accounts.Where(a => !a.DeletedAt.HasValue).FromCacheAsync(Accounts);

            // 6. Clean all cached entries by tag
            QueryCacheManager.ExpireTag(Accounts);

            // 7. Read from a database and put into cache
            var users7= await context.Accounts.FromCacheAsync(Accounts);

            // 8. Read from cache. Cache will be removed in 5 minutes
            var users8 = await context.Accounts.FromCacheAsync(
                new MemoryCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)}, Accounts);

            // 9. Read from cache. Cache will be removed after 20 minutes of inactivity
            var users9 = await context.Accounts.FromCacheAsync(
                new MemoryCacheEntryOptions { SlidingExpiration = TimeSpan.FromMinutes(20)}, Accounts);
        }
    }
}