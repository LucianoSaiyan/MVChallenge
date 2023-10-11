using Newtonsoft.Json;
using Project.Entities.Model;
using Project.Service;
using Project.Service.Validations;
using Project.Shared;
using Project.Shared.DTOs;
using Project.Shared.Mappers;

namespace Project.Test
{
    [TestClass]
    public class Api_UnitTest
    {
        string GetByCityResponse= @"Files\Api\GetByCityResponse.json";
        string PostCityRequestError = @"Files\Api\PostCityRequestError.json";
        string PostCityRequestOK = @"Files\Api\PostCityRequestOK.json";
        string PostCityResponseOK = @"Files\Api\PostCityResponseOK.json";
        string city = "Monte Grande";
        public void Initialize()
        {
            city = "Monte Grande";
            GetByCityResponse = @"Files\Api\GetByCityResponse.json";
            PostCityRequestError = @"Files\Api\PostCityRequestError.json";
            PostCityRequestOK = @"Files\Api\PostCityRequestOK.json";
            PostCityResponseOK = @"Files\Api\PostCityResponseOK.json";

        }

        #region Validations

        [TestMethod]
        public void MapEntityToDTO_Test()
        {
            string Mock_RequestAddUsuarios = File.ReadAllText(string.Format(GetByCityResponse));
            OpenWeatherEntity entity = JsonConvert.DeserializeObject<OpenWeatherEntity>(Mock_RequestAddUsuarios);
            OpenWeatherModelDTO mapperenntitydto = OpenWeatherMapper.MapEntityToDTO(entity);
            Assert.IsNotNull(mapperenntitydto);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ValidateExceptionRequestGetByCity_Test()
        {
            OpenWeatherValidations.ValidateDataInclude(new OpenWeatherModelDTO() { city = "" },
                                                       new string[] { nameof(city) },
                                                       true);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ValidateExceptionRequestHttpPut_Test()
        {
            string _postCityRequestError = File.ReadAllText(string.Format(PostCityRequestError));
            OpenWeatherModelDTO Mock_entityDTO = JsonConvert.DeserializeObject<OpenWeatherModelDTO>(_postCityRequestError);
            OpenWeatherValidations.ValidateDataInclude(Mock_entityDTO,
                                                            new string[] { nameof(Mock_entityDTO.Id), nameof(Mock_entityDTO.datehour) },
                                                            false);
        }

        [TestMethod]
        public void ValidateOkRequest_Test()
        {
            string _postCityRequestError = File.ReadAllText(string.Format(PostCityRequestOK));
            OpenWeatherModelDTO Mock_entityDTO = JsonConvert.DeserializeObject<OpenWeatherModelDTO>(_postCityRequestError);
            OpenWeatherValidations.ValidateDataInclude(Mock_entityDTO,
                                            new string[] { nameof(Mock_entityDTO.Id), nameof(Mock_entityDTO.datehour) },
                                            false);
            Assert.IsTrue(OpenWeatherValidations.checkvalidate);

        }


        #endregion

    }
}