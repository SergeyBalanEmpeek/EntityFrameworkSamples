using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EntityFrameworkTest.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkTest.Samples
{
    public static class Sample13
    {
        public static async Task Run()
        {
            await using var context = new SampleContext();

            // Projections - select specific columns from tables (concrete type + expression)
            var accounts = await context.Accounts
                .Select(AccountDtoModel.FromAccount)
                .ToListAsync();

            accounts.ForEach(data =>
                Console.WriteLine($"Account: {data.FullName} (Id={data.Id}). AuditEntries = {data.NumberOfLogs}"));
        }

        class AccountDtoModel
        {
            public long Id { get; set; }
            public string FullName { get; set; }
            public long NumberOfLogs { get; set; }

            public static Expression<Func<Account, AccountDtoModel>> FromAccount
            {
                get
                {
                    return account => new AccountDtoModel
                    {
                        Id = account.Id,
                        FullName = $"{account.FirstName} {account.LastName}",
                        NumberOfLogs = account.AuditRecords.Count
                    };
                }
            }
        }
    }
}

