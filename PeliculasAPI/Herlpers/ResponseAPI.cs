namespace PeliculasAPI.Herlpers
{
    public static class ResponseAPI
    {
        public static object EntityInsertedSuccess(Object entity)
        {
            return new
            {
                Message = "Información registrada con exito",
                Data = entity
            };
        }
    }
}
