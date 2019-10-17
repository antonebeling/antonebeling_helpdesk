using System.ComponentModel.DataAnnotations;

namespace Helpdesk_evry.Models
{
    public class ContactModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required]
        public string Message { get; set; }
    }
}