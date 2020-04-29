using System.Threading.Tasks;
using EntityFrameworkTest.Models;

namespace EntityFrameworkTest.Samples
{
    public static class Sample01
    {
        public static async Task Run()
        {
            await using var context = new SampleContext();

            var account = new Account()
            {
                FirstName = "Lando",
                LastName = "Norris",
            };

            // Insert new data
            context.Accounts.Add(account);

            await context.SaveChangesAsync();
        }
    }
}

