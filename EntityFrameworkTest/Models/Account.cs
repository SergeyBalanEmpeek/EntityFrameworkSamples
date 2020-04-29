using System;
using System.Collections.Generic;

namespace EntityFrameworkTest.Models
{
    public class Account
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<AuditRecord> AuditRecords { get; set; }

        public ICollection<AccountTeam> Teams { get; set; }

        public DateTime? DeletedAt { get; set; }

        // Some fields
        public int Data5 { get; set; }
        public int Data6 { get; set; }
        public int Data7 { get; set; }
        public int Data8 { get; set; }
        public int Data9 { get; set; }
        public int Data10 { get; set; }
    }
}

