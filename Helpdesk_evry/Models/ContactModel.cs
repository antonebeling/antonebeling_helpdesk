using System.ComponentModel.DataAnnotations;

namespace Helpdesk_evry.Models
{
    public class ContactModel
    {
        [Required]
        [Display(Name = "Förnamn")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Efternamn")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "E-postadress")]
        [EmailAddress]
        public string EmailAddress { get; set; }

        //[Required]
        //public int PhonePre { get; set; }

        [Required]
        [Display(Name = "Telefon")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Ämne")]
        public string Subject { get; set; }

        [Required]
        [Display(Name = "Avdelning")]
        public string[] serviceDepartments { get; set; }

        [Required]
        [Display(Name = "Typ av ärende")]
        public string[] typeOfProblems { get; set; }

        [Required]
        [Display(Name = "Meddelande")]
        public string Message { get; set; }

        public int PageId { get; set; }
    }
}