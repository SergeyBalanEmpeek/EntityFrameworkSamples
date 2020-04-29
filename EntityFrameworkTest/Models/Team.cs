using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkTest.Models
{
    public class Team
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<AccountTeam> Accounts { get; set; }

        public DateTime? DeletedAt { get; set; }

        // Some fields
        public int Data4 { get; set; }
        public int Data5 { get; set; }
        public int Data6 { get; set; }
        public int Data7 { get; set; }
        public int Data8 { get; set; }
        public int Data9 { get; set; }
        public int Data10 { get; set; }
    }
}



