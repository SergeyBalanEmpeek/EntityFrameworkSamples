using System;
using System.Linq;
using System.Threading.Tasks;
using EntityFrameworkTest.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkTest.Samples
{
    public static class Sample12
    {
        public static async Task Run()
        {
            await using var context = new SampleContext();

            // Projections - a wrong way (concrete type + constructor)
            var accounts = await context.Accounts
                .Include(account => account.AuditRecords)
                .Select(account => new AccountDtoModel(account))
                .ToListAsync();

            accounts.ForEach(data =>
                Console.WriteLine($"Account: {data.FullName} (Id={data.Id}). AuditEntries = {data.NumberOfLogs}"));
        }

        class AccountDtoModel
        {
            public long Id { get; set; }
            public string FullName { get; set; }
            public long NumberOfLogs { get; set; }

            public AccountDtoModel(Account account)
            {
                Id = account.Id;
                FullName = $"{account.FirstName} {account.LastName}";
                NumberOfLogs = account.AuditRecords.Count;
            }
        }
    }
}

