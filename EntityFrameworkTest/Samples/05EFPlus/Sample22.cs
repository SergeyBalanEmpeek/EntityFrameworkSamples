using System;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;

namespace EntityFrameworkTest.Samples
{
    public static class Sample22
    {
        public static async Task Run()
        {
            await using var context = new SampleContext();

            // Queries Grouping

            // Prepare queries
            var futureTeamFirst = context.Team.DeferredFirstOrDefault().FutureValue();
            var futureAccountCount = context.Accounts.DeferredCount().FutureValue();
            var futureAccountData10Sum = context.Accounts.DeferredSum(account => account.Data10).FutureValue();

            // Execute all of them
            var firstTeam = await futureTeamFirst.ValueAsync();

            // No need to use await here - they are already loaded
            var accountCount = futureAccountCount.Value;
            var accountData10Sum = futureAccountData10Sum.Value;

            Console.WriteLine($"Team Id: {firstTeam.Id}. Name: {firstTeam.Name}");
            Console.WriteLine($"Accounts Count: {accountCount}");
            Console.WriteLine($"Sum of Data 10 Field: {accountData10Sum}");
        }
    }
}