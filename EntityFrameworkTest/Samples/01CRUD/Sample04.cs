using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkTest.Samples
{
    public static class Sample04
    {
        public static async Task Run()
        {
            await using var context = new SampleContext();

            // Find specific record in database
            var account = await context.Accounts
                .Where(acc => acc.Id == 1)
                .FirstOrDefaultAsync();

            if (account != null)
               Console.WriteLine($"Account Id: {account.Id}. Full name: {account.FirstName} {account.LastName}");
        }
    }
}

