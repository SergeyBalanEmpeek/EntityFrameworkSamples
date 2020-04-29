using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EntityFrameworkTest.Models;
using LinqKit;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkTest.Samples
{
    public static class Sample27
    {
        public static async Task Run()
        {
            var accounts = await FindAccounts(audit =>
                audit.Date >= DateTime.UtcNow.AddYears(-1)
                && audit.Code == 12);

            accounts.ForEach(account =>
                Console.WriteLine($"Account Id: {account.Id}. Full name: {account.FirstName} {account.LastName}"));
        }

        static async Task<List<Account>> FindAccounts(Expression<Func<AuditRecord, bool>> auditFilter)
        {
            await using var context = new SampleContext();

            /* Won't compile
            var accounts = await context.Accounts
                .Where(account => account.AuditRecords.Any(auditFilter))
                .ToListAsync();
            */

            var accounts = await context.Accounts
                .AsExpandable()
                .Where(account => account.AuditRecords.Any(auditFilter.Compile()))
                .ToListAsync();

            return accounts;
        }
    }
}