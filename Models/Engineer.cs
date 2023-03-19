using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using System.Reflection.Metadata.Ecma335;

namespace ADASSESSMENT.Models
{
    public class Engineer
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string EmailAddress { get; set; } = string.Empty;
        [Required]
        public int ContactNumber { get; set; } = 0;
        [Required]
        public List<Address?> Addresses { get; set; } = new List<Address?>();
        public string Date { get; set; } = DateTime.Now.ToString("d");
        [Required]
        public List<TimeSlot?> TimeSlots { get; set; } = new List<TimeSlot?>();
        [Required]
        [StringLength(7, ErrorMessage = "Must be less than 7 characters long.")]
        public string? VRN { get; set; }
        public List<JobCategory?> JobCategories { get; set; } = new List<JobCategory?>();
        public string Comments { get; set; } = string.Empty;


        public int? EngineerId { get; set; } = 0;
        public int? AddressId { get; set; } = 0;
        public int? TimeSlotId { get; set; } = 0;
        public int? JobCategoryId { get; set; } = 0;


        [NotMapped]
        public Address? Address { get; set; }
        [NotMapped]
        public TimeSlot? TimeSlot { get; set;}

        public string EngineerAddress { get; set; }

        public string BookedSlot { set; get; }

        public string SelectedJob { set; get; }








    }
}
