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
    public class AdvertisementsApiController : ApiController
    {
        private AdvertisementLogic adLogic = new AdvertisementLogic();
        [HttpGet][Route("advertisement/{id}")]
        public HttpResponseMessage GetOneAdvertisementApi(int id)
        {
            try
            {
                AdvertisementModel advertisement = adLogic.GetOneAdvertisement(id);
                return Request.CreateResponse(HttpStatusCode.OK, advertisement);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ExceptionHelper.GetErrorResponse(ex));
            }
        }
        [HttpGet][Route("advertisements/{id}")]
        public HttpResponseMessage GetAdvertisementsBySubcategoryIDApi(int id)
        {
            try
            {
                List<AdvertisementModel> advertisements = adLogic.GetAdvertisementsBySubcategoryID(id);
                return Request.CreateResponse(HttpStatusCode.OK, advertisements);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ExceptionHelper.GetErrorResponse(ex));
            }
        }
        [HttpGet][Route("myadvertisements/{id}")]
        public HttpResponseMessage GetAdvertisementsByUserIDApi(int id)
        {
            try
            {
                List<AdvertisementModel> advertisements = adLogic.GetAdvertisementsByUserID(id);
                return Request.CreateResponse(HttpStatusCode.OK, advertisements);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ExceptionHelper.GetErrorResponse(ex));
            }
        }
        [HttpPost][Route("advertisements/add")]
        public HttpResponseMessage AddAdvertisementApi(AdvertisementModel advertisementModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    List<string> errors = ValidationHelper.ExtractErrors(ModelState);
                    var errorsObject = new { errors };
                    return Request.CreateResponse(HttpStatusCode.BadRequest, errorsObject);
                }
                AdvertisementModel advertisement = adLogic.AddAdvertisement(advertisementModel);
                return Request.CreateResponse(HttpStatusCode.Created, advertisement);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ExceptionHelper.GetErrorResponse(ex));
            }
        }
        [HttpPut][Route("advertisement/{id}")]
        public HttpResponseMessage UpdateAdvertisementApi(int id, AdvertisementModel advertisementModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    List<string> errors = ValidationHelper.ExtractErrors(ModelState);
                    var errorsObject = new { errors };
                    return Request.CreateResponse(HttpStatusCode.BadRequest, errorsObject);
                }
                advertisementModel.id = id;
                AdvertisementModel advertisement = adLogic.UpdateAdvertisement(advertisementModel);
                return Request.CreateResponse(HttpStatusCode.OK, advertisement);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ExceptionHelper.GetErrorResponse(ex));
            }
        }
        [HttpDelete][Route("advertisement/{id}")]
        public HttpResponseMessage DeleteAdvertisementApi(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    List<string> errors = ValidationHelper.ExtractErrors(ModelState);
                    var errorsObject = new { errors };
                    return Request.CreateResponse(HttpStatusCode.BadRequest, errorsObject);
                }
                adLogic.DeleteAdvertisement(id);
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ExceptionHelper.GetErrorResponse(ex));
            }
        }
        //[HttpPost][Route("advertisements/addwithcontactinfo")]
        //public HttpResponseMessage AddAdvertisementApi(UserContactInfoModel userContactInfoModel)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            List<string> errors = ValidationHelper.ExtractErrors(ModelState);
        //            var errorsObject = new { errors };
        //            return Request.CreateResponse(HttpStatusCode.BadRequest, errorsObject);
        //        }
        //        AdvertisementModel advertisement = adLogic.AddAdvertisement(userContactInfoModel.advertisement, userContactInfoModel.contactInfo);
        //        return Request.CreateResponse(HttpStatusCode.Created, advertisement);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.InternalServerError, ExceptionHelper.GetErrorResponse(ex));
        //    }
        //}
        [HttpGet][Route("advertisements/search/{searchText}")]
        public HttpResponseMessage SearchApi(string searchText)
        {
            try
            {
                List<AdvertisementModel> advertisements = adLogic.Search(searchText);
                return Request.CreateResponse(HttpStatusCode.OK, advertisements);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ExceptionHelper.GetErrorResponse(ex));
            }
        }
    }
}
