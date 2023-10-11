using Newtonsoft.Json;
using Project.Shared.DTOs;
using System.Reflection;

namespace Project.Test
{
    [TestClass]
    public class MethodHelpersTest
    {
        public void Initialize()
        {

        }

        [TestMethod]
        public void GetProperties_from_Generic_Object_Test()
        {            
            PropertyInfo[] propertyInfos = Methods.GetProperties_from_Generic_Object<OpenWeatherModelDTO>(new OpenWeatherModelDTO());
            Assert.IsNotNull(propertyInfos);
        }
    }
}