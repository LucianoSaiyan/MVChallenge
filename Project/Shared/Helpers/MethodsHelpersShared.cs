using Project.Entities.Model;
using Project.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Project.Shared.Helpers
{
    public static class MethodsHelpersShared
    {   

        public static List<TDestination> MapListDTO<TSource, TDestination>(List<TSource> sourceList)
        {
            List<TDestination> destinationList = new List<TDestination>();
            if (sourceList == null)
            {
                return new List<TDestination>();
            }
            foreach (TSource sourceItem in sourceList)
            { 
                TDestination destinationItem = Map<TSource, TDestination>(sourceItem);
                destinationList.Add(destinationItem);
            }
            return destinationList;
        }

        /// <summary>
        /// Funcion que hace un mapeo de una clase Origen a una Clase Destino,
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TDestination"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static TDestination Map<TSource, TDestination>(TSource source)
        {
            // se obtienen las propiedades del objeto de origen
            PropertyInfo[] sourceProperties = typeof(TSource).GetProperties();
            //arma un dictionary de las propiedades del objeto destino
            Dictionary<string,PropertyInfo> destinationProperties = typeof(TDestination).GetProperties().ToDictionary(p => p.Name);

            TDestination destination = Activator.CreateInstance<TDestination>();

            foreach (PropertyInfo sourceProperty in sourceProperties)
            {
                if (destinationProperties.ContainsKey(sourceProperty.Name))
                {
                    PropertyInfo destinationProperty = destinationProperties[sourceProperty.Name];
                    if (destinationProperty.PropertyType.IsAssignableFrom(sourceProperty.PropertyType))
                    {
                        object value = sourceProperty.GetValue(source);
                        destinationProperty.SetValue(destination, value);
                    }
                    //else if (sourceProperty.PropertyType.Name.Contains("List"))
                    //{
                    //    var listsource = sourceProperty as IList<TSource>;
                    //    //List<TSource> sourceList
                    //    //List<TSource> destinationList = 
                    //    //    MapList<TSource, TDestination>(source);
                    //    var roro = MapList<TSource, TDestination>((List<TSource>)listsource);
                    //    object value = sourceProperty.GetValue(source);
                    //    destinationProperty.SetValue(destination, value);
                    //}
                }
            }
            return destination;
        }

        public static List<TDestination> MapList<TSource, TDestination>(List<TSource> sourceList)
        {
            List<TDestination> destinationList = new List<TDestination>();

            foreach (TSource source in sourceList)
            {
                TDestination destinationItem = Map<TSource, TDestination>(source);
                destinationList.Add(destinationItem);
            }

            return destinationList;
        }

        /// <summary>
        /// Funcion que comprueba que el objeto que se esta brindando es una lista,en caso de ser
        /// true es porque es una lista,en caso de false no lo es
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="nombrePropiedad"></param>
        /// <returns></returns>
        public static bool IsLista<T>(T obj, string nombrePropiedad)
        {
            Type tipo = obj.GetType();
            PropertyInfo propiedad = tipo.GetProperty(nombrePropiedad);

            if (propiedad != null)
            {
                Type tipoPropiedad = propiedad.PropertyType;
                return tipoPropiedad.IsGenericType && tipoPropiedad.GetGenericTypeDefinition() == typeof(List<>);
            }

            return false;
        }

        /// <summary>
        /// Metodo para convertir un objeto a otro 
        /// por ejemplo de un DTO a un objeto normal o viceversa
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TDestination"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static TDestination MapObject<TSource, TDestination>(TSource source)
        {
            var sourceType = typeof(TSource);
            var destinationType = typeof(TDestination);

            // Crear una expresión lambda para el mapeo de propiedades
            var parameter = Expression.Parameter(sourceType, "src");
            var memberBindings = sourceType.GetProperties()
                .Where(srcProp => destinationType.GetProperty(srcProp.Name) != null)
                .Select(srcProp =>
                {
                    var destProp = destinationType.GetProperty(srcProp.Name);
                    var propertyAccess = Expression.Property(parameter, srcProp);
                    return Expression.Bind(destProp, propertyAccess);
                });

            var memberInit = Expression.MemberInit(Expression.New(destinationType), memberBindings);
            var lambda = Expression.Lambda<Func<TSource, TDestination>>(memberInit, parameter);

            var compiledLambda = lambda.Compile();
            return compiledLambda(source);
        }

    }
}
