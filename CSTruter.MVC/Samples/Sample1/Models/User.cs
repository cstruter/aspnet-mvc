using System.ComponentModel.DataAnnotations;

namespace CSTruter.Mvc.Samples.Sample1.Models
{
    public class User
    {
        [Display(Name = "FirstName", ResourceType = typeof(Resources.User))]
        public string FirstName { get; set; }

        [Display(Name = "LastName", ResourceType = typeof(Resources.User))]
        public string LastName { get; set; }

        [EmailAddress(ErrorMessageResourceName = "Email_InValid", ErrorMessageResourceType = typeof(Resources.User))]
        [Required(ErrorMessageResourceName = "Email_Required", ErrorMessageResourceType = typeof(Resources.User))]
        [Display(Name = "Email", ResourceType = typeof(Resources.User))]
        public string Email { get; set; }
    }
}