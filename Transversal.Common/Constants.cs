namespace Common
{
    public static class Constants
    {
        public struct StatusCode
        {
            public const int CodeDefault = 0;
            /// <summary>
            /// La solicitud ha tenido éxito
            /// </summary>
            public const int Code200 = 200;
            public const int Code204 = 204;
            /// <summary>
            /// Esta respuesta significa que el servidor no pudo interpretar la solicitud dada una sintaxis inválida.
            /// </summary>
            public const int Code400 = 400;
            /// <summary>
            /// Es necesario autenticar para obtener la respuesta solicitada. Esta es similar a 403, pero en este caso, la autenticación es posible.
            /// </summary>
            public const int Code401 = 401;
            /// <summary>
            /// El cliente no posee los permisos necesarios para cierto contenido, por lo que el servidor está rechazando otorgar una respuesta apropiada.
            /// </summary>
            public const int Code403 = 403;
            /// <summary>
            /// El servidor no pudo encontrar el contenido solicitado. Este código de respuesta es uno de los más famosos dada su alta ocurrencia en la web.
            /// </summary>
            public const int Code404 = 404;
            /// <summary>
            /// La petición estaba bien formada pero no se pudo seguir debido a errores de semántica.
            /// </summary>
            public const int Code422 = 422;
            /// <summary>
            /// El servidor ha encontrado una situación que no sabe cómo manejarla.
            /// </summary>
            public const int Code500 = 500;
        }
        public struct CodeResponse
        {
            /// <summary>
            /// 00 ok
            /// </summary>
            public const string CodeForRequestOK = "00";
            /// <summary>
            /// 01 vacio
            /// </summary>
            public const string CodeForEmptyField = "01";
            /// <summary>
            /// 02 incorrecto
            /// </summary>
            public const string CodeForWrongField = "02";
            /// <summary>
            /// 03 error de servidor
            /// </summary>
            public const string CodeForServerError = "03";
        }

        public struct Mensaje
        {
            public const string Aceptado = "Aceptado";
            public const string NoContent = "No hay datos";
            public const string InternalServer = "Error interno de servidor";

            //public const string MESSAGE_QUERY = "Consulta exitosa.";
           // public const string MESSAGE_QUERY_EMPTY = "No se encontraron registros.";
            public const string Save = "Se registró correctamente.";
            public const string Update = "Se actualizó correctamente.";
            public const string Delete = "Se eliminó correctamente.";
            public const string Exists = "El registro ya existe.";
            public const string Activate = "El registro ha sido activado.";
            public const string Token = "Token generado correctamente.";
            public const string TokenErorr = "El usuario y/o contraseña es incorrecta, compruébala.";
            public const string Validate = "Errores de validación.";
            public const string Failed = "Operación fallida.";
            public const string Exception = "Hubo un error inesperado.";
            public const string UserInactive = "El usuario esta inactivo.";
            public const string ContraseniaError = "contraseña es incorrecta.";
            public const string Unauthorized = "No hay ningún token de autenticación asociado.";
        }

        public const string ValidationErrorCode = "01";
        public const string GetDataFromBDErrorCode = "02";
        public const string LogicErrorCode = "03";
        public const string ServerErrorCode = "500";

        public const string Cors = "Access-Control-Allow-Origin";
        public const string PolicyName = "CorsPolicy";
        public const string CodeForApiKeyPrivateKey = "KEK";
        public const string Bearer = "Bearer ";

        public const string LanguageESP = "ESP";
        public const string LanguageENG = "ENG";

        public const string OK = "OK";
        public const int MerchantCodeLenght = 7;
        public const string Api_Security = "ApiSecurity";

        public static object MerchantNotFound { get; set; }
        public static object DateTimeFormats { get; internal set; }

        public static class SupportedAlgorithm
        {
            public const string Rsa = "RSA";
        }

        public static class SupportedKeyFormats
        {
            public const string Pkcs1 = "PKCS#1";
            public const string Pkcs8 = "PKCS#8";
        }

        public static class EntityStatus
        {
            public const string Active = "1";
            public const string Inactive = "0";

        }
        
    }
}
