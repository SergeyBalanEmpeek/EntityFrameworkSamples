using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkTest.Samples
{
    public static class Sample02
    {
        public static async Task Run()
        {
            await using var context = new SampleContext();

            // Read from database
            var accounts = await context.Accounts.ToListAsync();

            accounts.ForEach(account =>
                Console.WriteLine($"Account Id: {account.Id}. Full name: {account.FirstName} {account.LastName}"));
        }
    }
}

