namespace PeliculasAPI.Herlpers
{
    public static class ResponseAPI
    {
        public const string ERROR_GENERAL = "Error interno en el servidor.";
        public static object EntityInsertedSuccess(Object entity)
        {
            return new
            {
                Message = "Información registrada con exito.",
                Data = entity
            };
        }

        public static object EntityNotFound(long id)
        {
            return new
            {
                Message = $"No se encuentran registros pertenecientes al Id {id}.",
                Id = id
            };
        }

        public static object EntityUpdate(object entity)
        {
            return new
            {
                Message = "Registro actualizado con exito.",
                Data = entity
            };
        }

        public static object EntityDelete(long id)
        {
            return new
            {
                Message = $"Registro con id {id} eliminado con exito.",
                Id = id,
            };

        }
    }
}
