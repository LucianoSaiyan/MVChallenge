using Newtonsoft.Json;
using Project.Entities.Model;
using Project.Shared;
using Project.Shared.DTOs;
using Project.Shared.Helpers;
using Project.Shared.Validations;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Project.Test
{
    [TestClass]
    public class OpenWeather_UnitTest
    {
        string OpenWeatherresponse = @"Files\OpenWeatherFiles\OpenWeatherresponse.json";
        public void Initialize()
        {

        }

        #region Validations Add

        [TestMethod]
        public void ResponseOpenWeatherMock_Test()
        {
            string Mock_RequestAddUsuarios = File.ReadAllText(string.Format(OpenWeatherresponse));
            OpenWeatherEntity Mock_ResponseGetUsuarios_Deserialized = JsonConvert.DeserializeObject<OpenWeatherEntity>(Mock_RequestAddUsuarios);
            Assert.IsNotNull(Mock_ResponseGetUsuarios_Deserialized);            
        }
                
        [TestMethod]
        public void Integration_Test()
        {
            string urlMock_bsas = @"http://api.openweathermap.org/data/2.5/weather?q=Buenos%20Aires,ar&appid=611937859ca286c26b566a258ec7affb";
            HttpClient Http = new HttpClient();
            var rrresponseService = Http.GetStringAsync(urlMock_bsas);
            rrresponseService.Wait();
            if (rrresponseService.IsCompleted)
            {
                var valuemock = JsonConvert.DeserializeObject<OpenWeather>(rrresponseService.Result);
                Assert.IsNotNull(valuemock);
            }
            else
            {
                var rrr = rrresponseService.Result;
                Assert.IsNull(rrr);
            }


        }


        #endregion



    }
}