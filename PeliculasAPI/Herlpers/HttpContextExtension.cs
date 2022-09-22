using Microsoft.EntityFrameworkCore;

namespace PeliculasAPI.Herlpers;

public static class HttpContextExtension
{
    public static async Task InsertParametersPagination(this HttpContext httpContext, 
        double numberRecords, int numberRecordsPage)
    {
        double numberPages = Math.Ceiling(numberRecords / numberRecordsPage);
        httpContext.Response.Headers.Add("CantidadPaginas", numberPages.ToString());
    }
}