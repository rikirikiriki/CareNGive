using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CareNGive
{
    public class UserLogic:BaseLogic
    {
        public UserModel GetOneUser(int id)
        {
            return DB.Users.Where(u => u.UserID == id).Select(u => new UserModel
            { id=u.UserID, fName = u.FirstName, lName = u.LastName, emailAddress = u.Email, password=u.Password }).SingleOrDefault();
        }

        public UserModel Register (UserModel userModel)
        {
            int id = CheckUserExistence(userModel);
            if (id == 0)
            { 
                /*var sha1 = new SHA1CryptoServiceProvider();*/
                User user = new User
                {FirstName=userModel.fName, LastName=userModel.lName, Email=userModel.emailAddress,
                    /*PasswordHash = sha1.ComputeHash(userModel.password)*/
                    Password = userModel.password};
                DB.Users.Add(user);
                DB.SaveChanges();
                return GetOneUser(user.UserID);
            }
            return null;
        }

        //public UserModel Register(UserModel userModel, ContactInfoModel contactInfoModel)
        //{
        //    UserModel user =  Register(userModel);
        //    ContactInfoLogic contactInfoLogic = new ContactInfoLogic();
        //    contactInfoLogic.AddContactInfo(contactInfoModel);
        //    return user;
        //}

        public UserModel Login (CredentialsModel credentialsModel)
        {
            int id = CheckUserExistence(credentialsModel);
            if (id != 0)
                return GetOneUser(id);
            return null;
        }

        public int CheckUserExistence (CredentialsModel credentialsModel)
        {
            foreach (User item in DB.Users)
            {
                if (item.Email == credentialsModel.emailAddress)
                    return item.UserID;
            }
            return 0;
        }

        //public bool CheckUserPassword (UserModel userModel)
        //{
        //    int userID = CheckUserExistence(userModel);
        //    if (userID!=0)
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        
    }
}