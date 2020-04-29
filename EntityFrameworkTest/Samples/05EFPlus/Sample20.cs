using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Z.EntityFramework.Plus;

namespace EntityFrameworkTest.Samples
{
    public static class Sample20
    {
        public static async Task Run()
        {
            await using var context = new SampleContext();

            // Regular data load
            var result = await context.Accounts
                .Where(account => account.Id == 1)
                .Include(account => account.Teams)
                    .ThenInclude(accountTeam => accountTeam.Team)
                .Include(account => account.AuditRecords)
                .ToListAsync();

            // Optimized data load
            var result2 = await context.Accounts
                .Where(account => account.Id == 1)
                .IncludeOptimized(account => account.Teams.Select(accountTeam => accountTeam.Team))
                .IncludeOptimized(account => account.AuditRecords)
                .ToListAsync();
        }
    }
}