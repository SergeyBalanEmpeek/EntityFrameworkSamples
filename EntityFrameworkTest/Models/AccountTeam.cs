namespace EntityFrameworkTest.Models
{
    public class AccountTeam
    {
        public long Id { get; set; }

        public long AccountId { get; set; }
        public Account Account { get; set; }
        
        public long TeamId { get; set; }
        public Team Team { get; set; }
    }
}



