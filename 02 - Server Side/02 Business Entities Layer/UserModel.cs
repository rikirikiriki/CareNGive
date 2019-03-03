using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareNGive
{
    public class UserModel:CredentialsModel
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Missing first name.")]
        public string fName { get; set; }
        [Required(ErrorMessage = "Missing last name.")]
        public string lName { get; set; }
        //[Required(ErrorMessage = "Missing email.")]
        //[RegularExpression(@"^[\w.]+@[\w.]+.[\w.]+$")]
        //public string emailAddress { get; set; }
        //[Required(ErrorMessage = "Missing password.")]
        //public string password { get; set; }
        //public byte[] password { get; set; }

    }
}