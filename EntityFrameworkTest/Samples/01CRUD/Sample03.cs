using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkTest.Samples
{
    public static class Sample03
    {
        public static async Task Run()
        {
            await using var context = new SampleContext();

            // Read from database with filtering
            var accounts = await context.Accounts
                .Where(acc => acc.FirstName.StartsWith("L"))
                .ToListAsync();

            accounts.ForEach(account =>
                Console.WriteLine($"Account Id: {account.Id}. Full name: {account.FirstName} {account.LastName}"));
        }
    }
}

