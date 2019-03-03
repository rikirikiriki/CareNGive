using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.ModelBinding;

namespace CareNGive
{
    public static class ValidationHelper
    {
        public static List<string> ExtractErrors(ModelStateDictionary modelState)
        {
            List<string> errors = new List<string>();
            foreach (var prop in modelState.Values)
            {
                foreach (var err in prop.Errors)
                {
                    errors.Add(err.ErrorMessage);
                }
            }
            return errors;
        }
    }
}