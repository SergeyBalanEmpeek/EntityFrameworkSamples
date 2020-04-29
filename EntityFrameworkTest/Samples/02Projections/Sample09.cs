using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkTest.Samples
{
    public static class Sample09
    {
        public static async Task Run()
        {
            await using var context = new SampleContext();

            // Select all columns from tables
            var auditData = await context.Audit
                .Include(audit => audit.Account)
                .ToListAsync();

            auditData.ForEach(data =>
                Console.WriteLine($"Record Id: {data.Id}. Action code: {data.Code}. User {data.Account.FirstName} {data.Account.LastName} did something at {data.Date}"));
        }
    }
}

