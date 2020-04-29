using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkTest.Samples
{
    public static class Sample10
    {
        public static async Task Run()
        {
            await using var context = new SampleContext();

            // Projections - select specific columns from tables (anonymous type)
            var auditData = await context.Audit
                .Select(audit => new
                {
                    audit.Id,
                    audit.Code,
                    audit.Date,
                    AccountFullName = audit.Account.FirstName + " " + audit.Account.LastName
                })
                .ToListAsync();

            auditData.ForEach(data =>
                Console.WriteLine($"Record Id: {data.Id}. Action code: {data.Code}. User {data.AccountFullName} did something at {data.Date}"));
        }
    }
}

