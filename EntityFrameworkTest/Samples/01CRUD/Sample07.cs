using System.Threading.Tasks;
using EntityFrameworkTest.Models;

namespace EntityFrameworkTest.Samples
{
    public static class Sample07
    {
        public static async Task Run()
        {
            await using var context = new SampleContext();

            // Edit record without reading

            // These values will be 'original' for Entity Framework
            var account = new Account
            {
                Id = 5,
            };

            context.Accounts.Attach(account);

            // New values for Entity Framework
            account.FirstName = "John";

            await context.SaveChangesAsync();
        }
    }
}

