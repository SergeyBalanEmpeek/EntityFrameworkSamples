using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EntityFrameworkTest.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkTest.Samples
{
    public static class Sample26
    {
        private static readonly Expression<Func<Account, bool>> ActiveAccount = account =>
            !account.DeletedAt.HasValue
            && account.Teams.Any(team => !team.Team.DeletedAt.HasValue);

        public static async Task Run()
        {
            await using var context = new SampleContext();

            // Top level filtering without LinqKit
            var accounts = await context.Accounts
                .Where(ActiveAccount)
                .ToListAsync();

            accounts.ForEach(account =>
                Console.WriteLine($"Account Id: {account.Id}. Full name: {account.FirstName} {account.LastName}"));
        }
    }
}