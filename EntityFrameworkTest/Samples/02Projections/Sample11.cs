using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkTest.Samples
{
    public static class Sample11
    {
        public static async Task Run()
        {
            await using var context = new SampleContext();

            // Projections - select specific columns from tables (concrete type )
            var auditData = await context.Audit
                .Select(audit => new ResponseModel
                {
                    Id = audit.Id,
                    Code = audit.Code,
                    Date = audit.Date,
                    AccountFullName = audit.Account.FirstName + " " + audit.Account.LastName
                })
                .ToListAsync();

            auditData.ForEach(data =>
                Console.WriteLine($"Record Id: {data.Id}. Action code: {data.Code}. User {data.AccountFullName} did something at {data.Date}"));
        }

        class ResponseModel
        {
            public long Id { get; set; }
            public int Code { get; set; }
            public DateTime Date { get; set; }
            public string AccountFullName { get; set; }
        }
    }
}

