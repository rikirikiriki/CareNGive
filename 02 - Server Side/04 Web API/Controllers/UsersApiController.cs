using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CareNGive
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api")]
    public class UsersApiController : ApiController
    {
        private UserLogic userLogic = new UserLogic();
        [HttpGet][Route("users/{id}")]
        public HttpResponseMessage GetOneUserApi(int id)
        {
            try
            {
                UserModel user = userLogic.GetOneUser(id);
                return Request.CreateResponse(HttpStatusCode.OK, user);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ExceptionHelper.GetErrorResponse(ex));
            }
        }
        [HttpPost][Route("users/register")]
        public HttpResponseMessage RegisterApi(UserModel userModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    List<string> errors = ValidationHelper.ExtractErrors(ModelState);
                    var errorsObject = new { errors };
                    return Request.CreateResponse(HttpStatusCode.BadRequest, errorsObject);
                }
                UserModel user = userLogic.Register(userModel);
                return Request.CreateResponse(HttpStatusCode.Created, user);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ExceptionHelper.GetErrorResponse(ex));
            }
        }
        //[HttpPost][Route("users/registerwithcontactinfo")]
        //public HttpResponseMessage RegisterApi(UserContactInfoModel userContactInfoModel)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            List<string> errors = ValidationHelper.ExtractErrors(ModelState);
        //            var errorsObject = new { errors };
        //            return Request.CreateResponse(HttpStatusCode.BadRequest, errorsObject);
        //        }
        //        UserModel user = userLogic.Register(userContactInfoModel.user, userContactInfoModel.contactInfo);
        //        return Request.CreateResponse(HttpStatusCode.Created, user);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.InternalServerError, ExceptionHelper.GetErrorResponse(ex));
        //    }
        //}
        [HttpPost][Route("users/login")]
        public HttpResponseMessage LoginApi(CredentialsModel credentialsModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    List<string> errors = ValidationHelper.ExtractErrors(ModelState);
                    var errorsObject = new { errors };
                    return Request.CreateResponse(HttpStatusCode.BadRequest, errorsObject);
                }
                UserModel user = userLogic.Login(credentialsModel);
                if(user!=null)
                    return Request.CreateResponse(HttpStatusCode.OK, user);
                return Request.CreateResponse(HttpStatusCode.NotFound, "User does not exist!");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ExceptionHelper.GetErrorResponse(ex));
            }
        }
    }
}
