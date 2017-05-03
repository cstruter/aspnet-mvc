using CSTruter.Mvc.Samples.Sample3.Attributes;
using System.ComponentModel.DataAnnotations;

namespace CSTruter.Mvc.Samples.Sample3.Models
{
    [ResourceType(typeof(Resources.User))]
    public class User
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [EmailAddress(ErrorMessageResourceName = "Email_InValid")]
        [Required(ErrorMessageResourceName = "Email_Required")]
        public string Email { get; set; }
    }
}