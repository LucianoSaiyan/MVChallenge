using Project.Shared.DTOs;
using System.Reflection;

namespace Project.Service.Validations
{

    public static class OpenWeatherValidations
    {
        public static bool checkvalidate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityDTO"></param>
        /// <param name="propiedadesExcluidas"></param>
        /// <param name="truetoincludeFieldstoValidate"></param>
        /// <exception cref="ArgumentException"></exception>
        public static void ValidateDataInclude(OpenWeatherModelDTO entityDTO, string[] propiedadesExcluidas,bool truetoincludeFieldstoValidate = false)
        {
            List<string> errorMessages = new List<string>();

            //valida que la entidad no puede ser nula
            if (entityDTO == null)
                throw new ArgumentException("DEBE EXISTIR UN REGISTRO");
            
            validatefield<OpenWeatherModelDTO>(ref errorMessages, entityDTO, propiedadesExcluidas, truetoincludeFieldstoValidate);

            if (errorMessages.Any())
                throw new ArgumentException(string.Join(Environment.NewLine, errorMessages));

            //se utiliza para chequear el unit test
            checkvalidate = true;
        }

        /// <summary>
        /// Validacion que toma un objeto,desmenuza sus propiedades y se procesa
        /// </summary>
        /// <typeparam name="R"></typeparam>
        /// <param name="errorMessages">se para una lista List<string> como referencia</param>
        /// <param name="entityDTO">entidad para validar</param>
        /// <param name="propertiesToExcludeValidate">se agregan las propiedades que queremos validar o excluir (accion por defecto)</param>
        /// <param name="truetoincludeFieldstoValidate">parametro que determina si se incluye (true) o excluye (false) </param>
        static void validatefield<R>(ref List<string> errorMessages, R entityDTO, string[] propertiesToExcludeValidate,bool truetoincludeFieldstoValidate)
        {
            //se obtienen las propiedades del objeto 
            PropertyInfo[] properties = entityDTO.GetType().GetProperties();

            List<PropertyInfo> propiedadesParaValidar = null;
            //se filtran las propiedades a validar
            if (propertiesToExcludeValidate != null && propertiesToExcludeValidate.Length > 0)
            {
                //truetoincludeFieldstoValidate determina si se incluyen las propiedades brindadas o se excluyen
                propiedadesParaValidar = properties
                                .Where((truetoincludeFieldstoValidate ?
                                        field => propertiesToExcludeValidate.Contains(field.Name) 
                                        : field => !propertiesToExcludeValidate.Contains(field.Name)))
                                .ToList();
            }

            getpropertiestovalidate(ref errorMessages, entityDTO, propiedadesParaValidar);
        }

        /// <summary>
        /// Recorre las propiedades brindadas y se valida su valor , en caso de que cumpla las condiciones se agregara la informacion
        /// solicitada en la lista errorMessages
        /// </summary>
        /// <typeparam name="R"></typeparam>
        /// <param name="errorMessages"></param>
        /// <param name="entityDTO"></param>
        /// <param name="propiedadesParaValidar"></param>
        static void getpropertiestovalidate<R>(ref List<string> errorMessages, R entityDTO, List<PropertyInfo> propiedadesParaValidar)
        {
            foreach (var field in propiedadesParaValidar)
            {
                // Obtiene el valor de la propiedad actual
                var value = field.GetValue(entityDTO);

                if (field.PropertyType.Name is String && value == null || string.IsNullOrWhiteSpace(value.ToString()))
                    errorMessages.Add($"La propiedad {field.Name} es nula o vacía. {Environment.NewLine} ");

            }
        }

    }
}
