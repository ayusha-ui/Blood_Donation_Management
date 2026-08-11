using System;
using System.ComponentModel.DataAnnotations;

namespace Blood_Donation_Management.Models
{
    public class User
    {
        public Guid Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string BloodGroup { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Password { get; set; }

        public bool IsDonor { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}