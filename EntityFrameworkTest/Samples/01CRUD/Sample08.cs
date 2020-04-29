using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkTest.Samples
{
    public static class Sample08
    {
        public static async Task Run()
        {
            await using var context = new SampleContext();

            // Delete record
            var account = await context.Accounts
                .FirstOrDefaultAsync(acc => acc.Id == 1);

            if (account == null)
            {
                throw new Exception("Account not found");
            }

            context.Accounts.Remove(account);

            await context.SaveChangesAsync();
        }
    }
}

