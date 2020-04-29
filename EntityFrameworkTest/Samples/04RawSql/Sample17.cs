using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkTest.Samples
{
    public static class Sample17
    {
        public static async Task Run()
        {
            await using var context = new SampleContext();

            // Select data from SQL (raw sql)
            var results = await context.Sample17Model
                .FromSqlRaw(@"
SELECT
    Accounts.Id,
    (SELECT COUNT(*) FROM Audit WHERE Audit.AccountId = Accounts.Id AND Audit.AuditCodeType = 2)  AS NumberOfLogs
FROM Accounts
WHERE Accounts.FirstName = {0}", "Sergii")
                .ToListAsync();

            results.ForEach(result =>
               Console.WriteLine($"Account ID {result.Id}. AuditEntries = {result.NumberOfLogs}"));
        }
    }

    public class Sample17Model
    {
        public long Id { get; set; }
        public int NumberOfLogs { get; set; }
    }
}