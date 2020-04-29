using System;
using System.Linq;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;

namespace EntityFrameworkTest.Samples
{
    public static class Sample19
    {
        public static async Task Run()
        {
            await using var context = new SampleContext();

            // Batch delete users
            var affectedRows = await context.Accounts
                .Where(account => account.DeletedAt < DateTime.UtcNow.AddYears(-1))
                .DeleteAsync(settings => settings.BatchSize = int.MaxValue);

            Console.WriteLine($"Affected {affectedRows} rows");
        }
    }
}