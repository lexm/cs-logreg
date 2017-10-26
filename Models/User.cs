using System.ComponentModel.DataAnnotations;

namespace logreg.Models
{
    public abstract class BaseEntity {}
    public class User : BaseEntity
    {
        [Display(Name = "First Name")]
        [Required]
        [MinLength(2)]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required]
        [MinLength(2)]
        public string LastName { get; set; }
        [Display(Name = "Email")]
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Display(Name = "Password")]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Confirm Password")]
        [Required]
        [Compare(nameof(Password))]
        [DataType(DataType.Password)]
        public string Confirm { get; set; }
    }

    public class Login : BaseEntity
    {
        [Display(Name = "Email")]
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Display(Name = "Password")]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}