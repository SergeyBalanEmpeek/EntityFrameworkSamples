using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameworkTest.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkTest.Samples
{
    public static class Sample24
    {
        public static async Task Run()
        {
            // Dynamic LINQ
            var accounts = await FindAccounts("T", "E", "A");

            accounts.ForEach(account =>
                Console.WriteLine($"Account Id: {account.Id}. Full name: {account.FirstName} {account.LastName}"));
        }

        private static async Task<List<Account>> FindAccounts(params string[] startsWith)
        {
            await using var context = new SampleContext();

            var query = new StringBuilder();
            foreach (var keyword in startsWith)
            {
                if (query.Length > 0) query.Append(" || ");
                query.Append($"account.FirstName.StartsWith(\"{keyword}\")");
            }

            return await context.Accounts
                .WhereDynamic(account => query.ToString())
                .ToListAsync();
        }
    }
}