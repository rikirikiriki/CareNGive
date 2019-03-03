using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareNGive
{
    public class ContactInfoLogic:BaseLogic
    {
        public ContactInfoModel GetOneContactInfo(int id)
        {
            return DB.ContactInfo.Where(c => c.ContactID == id).Select(c => new ContactInfoModel
            { id=c.ContactID, userID=c.UserID, phoneNumber1=c.Phone1, phoneNumber2=c.Phone2, address=c.Address, neighborhood=c.Neighborhood, city=c.City, state=c.State, country=c.Country, postalCode=c.PostalCode}).SingleOrDefault();
        }

        public ContactInfoModel AddContactInfo(ContactInfoModel contactInfoModel)
        {
            ContactInfo contactInfo = new ContactInfo
            { UserID=contactInfoModel.userID, Phone1 = contactInfoModel.phoneNumber1, Phone2 = contactInfoModel.phoneNumber2, Address = contactInfoModel.address, Neighborhood=contactInfoModel.neighborhood, City=contactInfoModel.city, State=contactInfoModel.state, Country=contactInfoModel.country, PostalCode=contactInfoModel.postalCode };
            DB.ContactInfo.Add(contactInfo);
            DB.SaveChanges();
            return GetOneContactInfo(contactInfo.ContactID);
        }
    }
}
