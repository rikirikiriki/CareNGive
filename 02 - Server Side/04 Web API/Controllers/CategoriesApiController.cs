using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CareNGive.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api")]
    public class CategoriesApiController : ApiController
    {
        CategoriesLogic categoriesLogic = new CategoriesLogic();
        [HttpGet][Route("categories/{id}")]
        public HttpResponseMessage GetOneCategoryApi(int id)
        {
            try
            {
                CategoryModel category = categoriesLogic.GetOneCategory(id);
                return Request.CreateResponse(HttpStatusCode.OK, category);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ExceptionHelper.GetErrorResponse(ex));
            }
        }
        [HttpGet][Route("categories")]
        public HttpResponseMessage GetAllCategoriesApi()
        {
            try
            {
                List<CategoryModel> categories = categoriesLogic.GetAllCategories();
                return Request.CreateResponse(HttpStatusCode.OK, categories);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ExceptionHelper.GetErrorResponse(ex));
            }
        }
        [HttpGet]
        [Route("subcategories/{categoryID}")]
        public HttpResponseMessage GetSubCategoriesApi(int categoryID)
        {
            try
            {
                List<CategoryModel> subCategories = categoriesLogic.GetSubCategories(categoryID);
                return Request.CreateResponse(HttpStatusCode.OK, subCategories);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ExceptionHelper.GetErrorResponse(ex));
            }
        }
        [HttpGet]
        [Route("categories/names")]
        public HttpResponseMessage GetCategoryNamesApi()
        {
            try
            {
                List<string> categoryNames = categoriesLogic.GetCategoryNames();
                return Request.CreateResponse(HttpStatusCode.OK, categoryNames);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ExceptionHelper.GetErrorResponse(ex));
            }
        }
        //[HttpGet]
        //[Route("subcategories/{categoryName}")]
        //public HttpResponseMessage GetSubCategoriesApi(string categoryName)
        //{
        //    try
        //    {
        //        List<CategoryModel> subCategories = categoriesLogic.GetSubCategories(categoryName);
        //        return Request.CreateResponse(HttpStatusCode.OK, subCategories);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.InternalServerError, ExceptionHelper.GetErrorResponse(ex));
        //    }
        //}
        [HttpGet][Route("subcategories/names/{categoryName}")]
        public HttpResponseMessage GetSubCategoryNamesApi(string categoryName)
        {
            try
            {
                List<string> subCategoryNames = categoriesLogic.GetSubCategoryNames(categoryName);
                return Request.CreateResponse(HttpStatusCode.OK, subCategoryNames);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ExceptionHelper.GetErrorResponse(ex));
            }
        }
        [HttpGet][Route("categoryName/{adID}")]
        public HttpResponseMessage GetCategoryNameByIDApi(int adID)
        {
            try
            {
                string categoryName = categoriesLogic.GetCategoryNameByID(adID);
                return Request.CreateResponse(HttpStatusCode.OK, categoryName);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ExceptionHelper.GetErrorResponse(ex));
            }
        }
        //[HttpPost][Route("categories/add")]
        //public HttpResponseMessage AddCategoryApi(CategoryModel categoryModel)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            List<string> errors = ValidationHelper.ExtractErrors(ModelState);
        //            var errorsObject = new { errors };
        //            return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
        //        }
        //        CategoryModel category = categoriesLogic.AddCategory(categoryModel);
        //        return Request.CreateResponse(HttpStatusCode.Created, category);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.InternalServerError, ExceptionHelper.GetErrorResponse(ex));
        //    }
        //}
    }
}
