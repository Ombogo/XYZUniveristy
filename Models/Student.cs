
using System.ComponentModel.DataAnnotations;

namespace XYZUniversityPaymentsAPI.Models
{
    public class Student
    {
        [Key]  // AdmNo is the primary key
        public required string AdmNo { get; set; }  // Maps to AdmNo in the database


        /// <summary>
        /// The first name of the student
        /// </summary>
        /// <example>John, Jane</example>
        [Required]
        [StringLength(50)]
        public required string FirstName { get; set; }  // Maps to FirstName in the database


        /// <summary>
        /// The second name of the student
        /// </summary>
        /// <example>Doe</example>
        [Required]
        [StringLength(50)]
        public required string LastName { get; set; }  // Maps to LastName in the database

        [Required]
        public DateTime DateOfBirth { get; set; }  // Maps to DateOfBirth in the database

        [Required]
        [StringLength(20)]
        public required string EnrollmentStatus { get; set; }  // Maps to EnrollmentStatus in the database

        public DateTime EnrollmentDate { get; set; }  // Maps to EnrollmentDate in the database

        [StringLength(100)]
        public required string Program { get; set; }  // Maps to Program in the database

        [StringLength(100)]
        public required string Email { get; set; }  // Maps to Email in the database

        [StringLength(15)]
        public required string PhoneNumber { get; set; }  // Maps to PhoneNumber in the database
    }
}
