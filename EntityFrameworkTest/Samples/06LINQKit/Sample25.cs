using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityFrameworkTest.Models;
using LinqKit;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkTest.Samples
{
    public static class Sample25
    {
        public static async Task Run()
        {
            // Predicate Builder
            var accounts = await FindAccounts("T", "E", "A");

            accounts.ForEach(account =>
                Console.WriteLine($"Account Id: {account.Id}. Full name: {account.FirstName} {account.LastName}"));
        }

        private static async Task<List<Account>> FindAccounts(params string[] startsWith)
        {
            await using var context = new SampleContext();

            var predicate = PredicateBuilder.New<Account>(true);
            foreach (string keyword in startsWith)
            {
                predicate = predicate.Or (p => p.FirstName.StartsWith(keyword));
            }

            return await context.Accounts.Where(predicate).ToListAsync();
        }
    }
}