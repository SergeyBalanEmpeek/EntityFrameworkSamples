using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkTest.Samples
{
    public static class Sample05
    {
        public static async Task Run()
        {
            await using var context = new SampleContext();

            // Find specific record in database - alternative
            var account = await context.Accounts.FirstOrDefaultAsync(acc => acc.Id == 1);

            if (account != null)
               Console.WriteLine($"Account Id: {account.Id}. Full name: {account.FirstName} {account.LastName}");
        }
    }
}

