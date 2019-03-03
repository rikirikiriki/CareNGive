using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareNGive
{
    public class ContactInfoModel
    {
        public int id { get; set; }
        [Required]
        public int userID { get; set; }
        [RegularExpression(@"^05\d-?[1-9]\d{6}$")]
        [Required(ErrorMessage = "Missing phone number.")]
        public string phoneNumber1 { get; set; }
        [RegularExpression(@"^05\d-?[1-9]\d{6}$")]
        public string phoneNumber2 { get; set; }
        public string address { get; set; }
        public string neighborhood { get; set; }
        [Required(ErrorMessage = "Missing city.")]
        public string city { get; set; }
        public string state { get; set; }
        [Required(ErrorMessage = "Missing country.")]
        public string country { get; set; }
        public string postalCode { get; set; }
    }
}