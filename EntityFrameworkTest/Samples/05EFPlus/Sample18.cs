using System;
using System.Linq;
using System.Threading.Tasks;
using EntityFrameworkTest.Models;
using Z.EntityFramework.Plus;

namespace EntityFrameworkTest.Samples
{
    public static class Sample18
    {
        public static async Task Run()
        {
            await using var context = new SampleContext();

            // Batch update users
            var affectedRows = await context.Accounts
                .Where(account =>
                    account.DeletedAt.HasValue == false
                    && account.Teams.Any(team => team.TeamId == 1))
                .UpdateAsync(account => new Account { DeletedAt = DateTime.UtcNow });

            Console.WriteLine($"Affected {affectedRows} rows");
        }
    }
}