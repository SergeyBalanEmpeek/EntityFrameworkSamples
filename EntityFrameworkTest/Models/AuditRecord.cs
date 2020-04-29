using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkTest.Models
{
    [Table("Audit")]
    public class AuditRecord
    {
        [Key]
        public long Id { get; set; }

        [Column("AuditCodeType")]
        public int Code { get; set; }

        public int? ObjectId { get; set; }

        public DateTime Date { get; set; }

        [MaxLength(128)]
        [Required]
        public string Details { get; set; }

        public long AccountId { get; set; }
        public Account Account { get; set; }

        // Some fields
        public int Data7 { get; set; }
        public int Data8 { get; set; }
        public int Data9 { get; set; }
        public int Data10 { get; set; }
    }
}



