using Project.Shared;
using Newtonsoft.Json;
using System.Reflection;
using Project.Client.Helpers;

namespace Project.Helpers
{
    public static class Methods
    {
        /// <summary>
        /// Metodo que obtiene las propiedades de una clase ordenando por el id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public static PropertyInfo[] GetProperties_from_Generic_Object<T>(T data) where T : class
        {
            try
            {
                PropertyInfo[] propertyInfos = data.GetType().GetProperties()
                    //ordena las propiedades para que el id quede primera dado que todas las entitades heredan de la interface IEntity
                    .OrderByDescending(pi => pi.Name == Constants.id)
                    .ToArray();
                return propertyInfos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Metodo que obtiene las propiedades de una clase que se para por 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public static async Task<PropertyInfo[]> GetProperties_from_Generic_Object_Async<T>(T data) where T : class
        {
            try
            {
                PropertyInfo[] propertyInfos = data.GetType().GetProperties()
                    //ordena las propiedades para que el id quede primera dado que todas las entitades heredan de la interface IEntity
                    .OrderByDescending(pi => pi.Name == Constants.id)
                    .ToArray();
                return await Task.FromResult(propertyInfos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Metodo que obtiene las propiedades de una clase exceptuando el id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public static async Task<PropertyInfo[]> GetProperties_from_Generic_Object_Exclude_id_Async<T>(T data) where T : class
        {
            try
            {
                PropertyInfo[] propertyInfos = data.GetType().GetProperties()
                    .Where(pi => pi.Name != Constants.id)
                    .ToArray();
                return await Task.FromResult(propertyInfos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion que arma un dictionary para obtener clave y valor de un objeto brindado
        /// </summary>
        /// <typeparam name="T">Objeto que tomara la funcion para actuar como tal</typeparam>
        /// <param name="data">Parametro del objeto instanciado</param>
        /// <returns></returns>
        public static Dictionary<object, object> GetPropertiesandValues<T>(T data)
        {
            try
            {
                Dictionary<object, object> keyValuePairs = new Dictionary<object, object>();
                
                PropertyInfo[] propertyInfos = data.GetType().GetProperties()
                    .OrderByDescending(pi => pi.Name == Constants.id)
                    .ToArray();
                foreach (PropertyInfo propertyInfo in propertyInfos)
                {
                    keyValuePairs.Add(propertyInfo.Name, propertyInfo.GetValue(data) ?? string.Empty);
                }
                return keyValuePairs;
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

    }
}
