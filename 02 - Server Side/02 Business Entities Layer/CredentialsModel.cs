using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareNGive
{
    public class CredentialsModel
    {
        [Required(ErrorMessage = "Missing email.")]
        [RegularExpression(@"^[\w.]+@[\w.]+.[\w.]+$")]
        public string emailAddress { get; set; }
        [Required(ErrorMessage = "Missing password.")]
        public string password { get; set; }
    }
}
