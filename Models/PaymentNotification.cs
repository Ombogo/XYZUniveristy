using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XYZUniversityPaymentsAPI.Models
{
    public class PaymentNotification
    {
        [Key]  // Primary key
        public int PaymentId { get; set; }  // Maps to PaymentId in the database

        [Required]
        [StringLength(50)]
        public required string TransactionId { get; set; }  // Maps to TransactionId in the database

        [Required]
        [ForeignKey("Student")]
        public required string AdmNo { get; set; }  // Maps to AdmNo in the database, and creates a foreign key relationship to Student

        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Amount { get; set; }  // Maps to Amount in the database

        [Required]
        public DateTime PaymentDate { get; set; }  // Maps to PaymentDate in the database

        [Required]
        [StringLength(20)]
        public required string PaymentStatus { get; set; }  // Maps to PaymentStatus in the database

        [StringLength(50)]
        public required string BankReference { get; set; }  // Maps to BankReference in the database

        [StringLength(50)]
        public required string PaymentMethod { get; set; }  // Maps to PaymentMethod in the database

        public DateTime ProcessedDate { get; set; }  // Maps to ProcessedDate in the database
    }
}
