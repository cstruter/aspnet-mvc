using CSTruter.Mvc.Samples.Sample2.Attributes;
using System.ComponentModel.DataAnnotations;

namespace CSTruter.Mvc.Samples.Sample2.Models
{
    [ResourceType(typeof(Resources.User))]
    public class User
    {
        [Display(Name = "FirstName")]
        public string FirstName { get; set; }

        [Display(Name = "LastName")]
        public string LastName { get; set; }

        [EmailAddress(ErrorMessageResourceName = "Email_InValid")]
        [Required(ErrorMessageResourceName = "Email_Required")]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}