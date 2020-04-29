using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkTest.Samples
{
    public static class Sample16
    {
        public static async Task Run()
        {
            await using var context = new SampleContext();

            // Select data from SQL (stored procedure)
            var accounts = await context.Accounts
                .FromSqlRaw("sp_GetAccountsByFirstName @FirstName = {0}", "Sergii")
                .ToListAsync();

            accounts.ForEach(data =>
                Console.WriteLine($"Account ID = {data.Id}). Account Name = {data.FirstName} {data.LastName}"));
        }
    }
}