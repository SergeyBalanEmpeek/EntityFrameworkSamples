using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Z.EntityFramework.Plus;

namespace EntityFrameworkTest.Samples
{
    public static class Sample15
    {
        public static async Task Run()
        {
            await using var context = new SampleContext();

            // Filtering with EntityFrameworkPlus
            var accounts = await context.Accounts
                .IncludeFilter(account => account.AuditRecords.Where(record => record.Code == 2))
                .Where(account => account.FirstName == "Sergii")
                .ToListAsync();

            accounts.ForEach(data =>
                Console.WriteLine($"Account ID {data.Id}). AuditEntries = {data.AuditRecords.Count}"));
        }
    }
}