using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public static class HttpRequestExtensionMethods
{
    public static bool IsAjax(this
HttpRequest request, string httpVerb = "")
    {
        if (request == null)
        {
            throw new ArgumentNullException
("Request object is Null.");
        }

        if (!string.IsNullOrEmpty(httpVerb))
        {
            if (request.Method != httpVerb)
            {
                return false;
            }
        }

        if (request.Headers != null)
        {
            return request.Headers["X-Requested-With"]
== "XMLHttpRequest";
        }

        return false;
    }

}
