using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareNGive
{
    public enum AdvertisementType { Product=1, Service}
    public class AdvertisementModel
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Missing user ID.")]
        public int userID { get; set; }
        [Required(ErrorMessage = "Missing category ID.")]
        public int categoryID { get; set; }
        [Required(ErrorMessage = "Missing advertisement type.")]
        public int typeID { get; set; }
        public int contactID { get; set; }
        public string contactName { get; set; }
        public string categoryName { get; set; }
        //[Required(ErrorMessage = "Missing advertisement type.")]
        //public AdvertisementType adTypeEnum { get; set; }
        public string adType { get; set; }
        [Required(ErrorMessage = "Missing advertisement name.")]
        public string adName { get; set; }
        [StringLength(200)]
        public string description { get; set; }
        public short? amount { get; set; }
        public string phoneNumber1 { get; set; }
        [RegularExpression(@"^05\d-?[1-9]\d{6}$")]
        public string phoneNumber2 { get; set; }
        public string address { get; set; }
        public string neighborhood { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string postalCode { get; set; }
        public string creationDate { get; set; }
        //public int creationMonth { get; set; }
        //public int creationYear { get; set; }
        //public int creationHour { get; set; }
        //public int creationMin { get; set; }
        public string photo { get; set; }
    }
}








