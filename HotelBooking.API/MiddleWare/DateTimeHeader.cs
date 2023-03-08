
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace HotelBooking.API.MiddleWare
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class DateTimeHeader
    {
        private readonly RequestDelegate _next;

        public DateTimeHeader(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {

            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class DateTimeHeaderExtensions
    {
        public static IApplicationBuilder UseDateTimeHeader(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<DateTimeHeader>();
        }
    }
}
