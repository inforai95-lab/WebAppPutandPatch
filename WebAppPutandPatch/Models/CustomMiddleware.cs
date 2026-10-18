using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppPutandPatch.Models
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate requestDelegate;
        public CustomMiddleware(RequestDelegate request)
        {
            requestDelegate = request;
        }
        public async Task InvokeAsync(HttpContext Context)
        {
            await Context.Response.WriteAsync("This is first elements");
           
        }
    }
}
