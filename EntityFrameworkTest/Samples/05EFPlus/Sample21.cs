using System;
using System.Linq;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;

namespace EntityFrameworkTest.Samples
{
    public static class Sample21
    {
        public static async Task Run()
        {
            await using var context = new SampleContext();

            // Queries Grouping

            // Prepare queries
            var futureAccounts = context.Accounts.Future();
            var futureTeams = context.Team.Future();

            // Load both queries together
            var accounts = await futureAccounts.ToListAsync();

            // No need to use await here - it's already loaded
            var teams = futureTeams.ToList();

            accounts.ForEach(account =>
                Console.WriteLine($"Account Id: {account.Id}. Full name: {account.FirstName} {account.LastName}"));

            teams.ForEach(team =>
                Console.WriteLine($"Team Id: {team.Id}. Name: {team.Name}"));
        }
    }
}