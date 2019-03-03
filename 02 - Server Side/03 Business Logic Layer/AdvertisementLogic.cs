using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareNGive
{
    public class AdvertisementLogic:BaseLogic
    {
        public AdvertisementModel GetOneAdvertisement(int id)
        {
            return DB.Advertisements.Where(a => a.AdID == id).Select(a => new AdvertisementModel
            { id=a.AdID, userID=a.UserID, contactName = a.User.FirstName + " " + a.User.LastName, categoryID=a.CategoryID, categoryName = a.Category.CategoryName, typeID=a.TypeID, adType = a.Type.TypeName, adName = a.AdName, description = a.Description, amount = a.Quantity, phoneNumber1 = a.ContactInfo.Phone1, phoneNumber2 = a.ContactInfo.Phone2, address = a.ContactInfo.Address, neighborhood = a.ContactInfo.Neighborhood, city = a.ContactInfo.City, state = a.ContactInfo.State, country = a.ContactInfo.Country, postalCode = a.ContactInfo.PostalCode, creationDate = a.CreationDate.ToString()
            }).SingleOrDefault();
        }

        public List<AdvertisementModel> GetAdvertisementsBySubcategoryID(int id)
        {
            return DB.Advertisements.Where(a => a.CategoryID == id).Select(a => new AdvertisementModel
            { id = a.AdID, contactName = a.User.FirstName + "" + a.User.LastName, categoryName = a.Category.CategoryName, adType = a.Type.TypeName, adName = a.AdName, description = a.Description, amount = a.Quantity, phoneNumber1 = a.ContactInfo.Phone1, phoneNumber2 = a.ContactInfo.Phone2, address = a.ContactInfo.Address, neighborhood = a.ContactInfo.Neighborhood, city = a.ContactInfo.City, state = a.ContactInfo.State, country = a.ContactInfo.Country, postalCode = a.ContactInfo.PostalCode, creationDate = a.CreationDate.ToString()
            }).ToList();
        }

        public List<AdvertisementModel> GetAdvertisementsByUserID(int id)
        {
            return DB.Advertisements.Where(a => a.UserID == id).Select(a => new AdvertisementModel
            {
                id = a.AdID,
                userID = a.UserID,
                contactName = a.User.FirstName + " " + a.User.LastName,
                categoryID = a.CategoryID,
                categoryName = a.Category.CategoryName,
                typeID = a.TypeID,
                adType = a.Type.TypeName,
                adName = a.AdName,
                description = a.Description,
                amount = a.Quantity,
                phoneNumber1 = a.ContactInfo.Phone1,
                phoneNumber2 = a.ContactInfo.Phone2,
                address = a.ContactInfo.Address,
                neighborhood = a.ContactInfo.Neighborhood,
                city = a.ContactInfo.City,
                state = a.ContactInfo.State,
                country = a.ContactInfo.Country,
                postalCode = a.ContactInfo.PostalCode,
                creationDate = a.CreationDate.ToString()
            }).ToList();
        }

        public AdvertisementModel AddAdvertisement(AdvertisementModel advertisementModel)
        {
            ContactInfo contactInfo = new ContactInfo
            { UserID=advertisementModel.userID, Phone1 = advertisementModel.phoneNumber1, Phone2 = advertisementModel.phoneNumber2, Address = advertisementModel.address, Neighborhood = advertisementModel.neighborhood, City = advertisementModel.city, State = advertisementModel.state, Country = advertisementModel.country, PostalCode = advertisementModel.postalCode };
            DB.ContactInfo.Add(contactInfo);
            DB.SaveChanges();
            Advertisement advertisement = new Advertisement
            {UserID=advertisementModel.userID, CategoryID=advertisementModel.categoryID, TypeID=advertisementModel.typeID, AdName= advertisementModel.adName, Description= advertisementModel.description, Quantity= advertisementModel.amount, ContactID= contactInfo.ContactID};
            DB.Advertisements.Add(advertisement);
            DB.SaveChanges();
            return GetOneAdvertisement(advertisement.AdID);
        }

        public AdvertisementModel UpdateAdvertisement(AdvertisementModel advertisementModel)
        {
            Advertisement advertisement = DB.Advertisements.Where(a => a.AdID == advertisementModel.id).SingleOrDefault();
            advertisement.ContactInfo.Phone1 = advertisementModel.phoneNumber1;
            advertisement.ContactInfo.Phone2 = advertisementModel.phoneNumber2;
            advertisement.ContactInfo.Address = advertisementModel.address;
            advertisement.ContactInfo.Neighborhood = advertisementModel.neighborhood;
            advertisement.ContactInfo.City = advertisementModel.city;
            advertisement.ContactInfo.State = advertisementModel.state;
            advertisement.ContactInfo.Country = advertisementModel.country;
            advertisement.ContactInfo.PostalCode = advertisementModel.postalCode;
            advertisement.CategoryID = advertisementModel.categoryID;
            advertisement.TypeID = advertisementModel.typeID;
            advertisement.AdName = advertisementModel.adName;
            advertisement.Description = advertisementModel.description;
            advertisement.Quantity = advertisementModel.amount;
            DB.SaveChanges();
            return GetOneAdvertisement(advertisement.AdID);
        }

        public void DeleteAdvertisement(int id)
        {
            Advertisement advertisement = DB.Advertisements.Where(a => a.AdID == id).SingleOrDefault();
            if (advertisement != null)
            {
                DB.Advertisements.Remove(advertisement);
                DB.SaveChanges();
            }
        }
        //public AdvertisementModel AddAdvertisement(AdvertisementModel advertisementModel, ContactInfoModel contactInfoModel)
        //{
        //    ContactInfoLogic contactInfoLogic = new ContactInfoLogic();
        //    ContactInfoModel contactInfo = contactInfoLogic.AddContactInfo(contactInfoModel);
        //    advertisementModel.contactID = contactInfo.id;
        //    AdvertisementModel advertisement = AddAdvertisement(advertisementModel);
        //    return advertisement;
        //}
        public List<AdvertisementModel> Search(string searchText)
        {
            return DB.Advertisements.Where(a =>  a.AdName.Contains(searchText) || a.Description.Contains(searchText) || a.Category.CategoryName.Contains(searchText) || a.Category.Description.Contains(searchText) || a.ContactInfo.Country.Contains(searchText) || a.ContactInfo.State.Contains(searchText) || a.ContactInfo.City.Contains(searchText) || a.ContactInfo.Neighborhood.Contains(searchText)).Select(a => new AdvertisementModel { id = a.AdID, contactName = a.User.FirstName + "" + a.User.LastName, categoryName = a.Category.CategoryName, adType = a.Type.TypeName, adName = a.AdName, description = a.Description, amount = a.Quantity, phoneNumber1 = a.ContactInfo.Phone1, phoneNumber2 = a.ContactInfo.Phone2, address = a.ContactInfo.Address, neighborhood = a.ContactInfo.Neighborhood, city = a.ContactInfo.City, state = a.ContactInfo.State, country = a.ContactInfo.Country, postalCode = a.ContactInfo.PostalCode, creationDate = a.CreationDate.ToString() }).ToList();
        }
        public List<AdvertisementModel> SearchOrderBy(string searchText)
        {
            return DB.Advertisements.Where(a => a.AdName.Contains(searchText) || a.Description.Contains(searchText) || a.Category.CategoryName.Contains(searchText) || a.Category.Description.Contains(searchText) || a.ContactInfo.Country.Contains(searchText) || a.ContactInfo.State.Contains(searchText) || a.ContactInfo.City.Contains(searchText) || a.ContactInfo.Neighborhood.Contains(searchText)).OrderByDescending(a=>a.CreationDate).Select(a => new AdvertisementModel { id = a.AdID, contactName = a.User.FirstName + "" + a.User.LastName, categoryName = a.Category.CategoryName, adType = a.Type.TypeName, adName = a.AdName, description = a.Description, amount = a.Quantity, phoneNumber1 = a.ContactInfo.Phone1, phoneNumber2 = a.ContactInfo.Phone2, address = a.ContactInfo.Address, neighborhood = a.ContactInfo.Neighborhood, city = a.ContactInfo.City, state = a.ContactInfo.State, country = a.ContactInfo.Country, postalCode = a.ContactInfo.PostalCode, creationDate = a.CreationDate.ToString() }).ToList();
        }
    }
}
