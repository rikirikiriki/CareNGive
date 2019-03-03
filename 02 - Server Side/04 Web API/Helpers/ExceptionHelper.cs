using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CareNGive
{
    public static class ExceptionHelper
    {
        public static string GetErrorResponse(Exception ex)
        {
#if DEBUG
            return ex.Message;
#else
            return "Error occured, Please try again";
#endif
        }
    }
}