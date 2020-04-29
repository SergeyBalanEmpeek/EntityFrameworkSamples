using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkTest.Samples
{
    public static class Sample14
    {
        public static async Task Run()
        {
            await using var context = new SampleContext();

            // Filtering in projections
            var accounts = await context.Accounts
                .Where(account => account.FirstName == "Sergii")
                .Select(account => new
                {
                    account.Id,
                    NumberOfLogs = account.AuditRecords.Count(audit => audit.Code == 2)
                })
                .ToListAsync();

            accounts.ForEach(data =>
               Console.WriteLine($"Account ID {data.Id}). AuditEntries = {data.NumberOfLogs}"));
        }
    }
}

