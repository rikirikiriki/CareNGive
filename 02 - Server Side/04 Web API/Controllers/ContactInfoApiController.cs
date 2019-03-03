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
    public class ContactInfoApiController : ApiController
    {
        private ContactInfoLogic contactInfoLogic = new ContactInfoLogic();
        [HttpPost][Route("contactinfo/add")]
        public HttpResponseMessage AddContactInfo(ContactInfoModel contactInfoModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    List<string> errors = ValidationHelper.ExtractErrors(ModelState);
                    var errorsObject = new { errors };
                    return Request.CreateResponse(HttpStatusCode.BadRequest, errorsObject);
                }
                ContactInfoModel contactInfo = contactInfoLogic.AddContactInfo(contactInfoModel);
                return Request.CreateResponse(HttpStatusCode.Created, contactInfo);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ExceptionHelper.GetErrorResponse(ex));
            }
        }
    }
}
