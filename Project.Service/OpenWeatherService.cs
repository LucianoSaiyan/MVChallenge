using Microsoft.Extensions.Logging;
using Project.Application.Abstractions;
using Project.Entities.Model;
using Project.Service.Validations;
using Project.Shared;
using Project.Shared.DTOs;
using Project.Shared.Helpers;
using Project.Shared.Mappers;

namespace Project.Service
{

    public interface IOpenWeatherService : IService<OpenWeatherModelDTO>
    {
        Task<ResponseService<List<OpenWeatherModelDTO>>> HttpGet();
        Task<ResponseService<OpenWeatherModelDTO>> HttpGetId(int id);
        Task<ResponseService<List<OpenWeatherModelDTO>>> HttpGetByCity(string id);
        Task<ResponseService<OpenWeatherModelDTO>> HttpPost(OpenWeatherModelDTO entityDTO);
        Task<ResponseService<OpenWeatherModelDTO>> HttpPut(OpenWeatherModelDTO entityDTO);
        Task<ResponseService<int>> HttpDelete(int id);
    }

    public class OpenWeatherService : IOpenWeatherService
    {
        #region Variables and Properties

        IApplication<OpenWeatherEntity> _OpenWeather;
        IOpenWeatherApplication _OpenWeatherApp;
        public ILogger Logger { get; }
        #endregion

        #region Constructor

        public OpenWeatherService(IApplication<OpenWeatherEntity> OpenWeather,
                                        IOpenWeatherApplication OpenWeatherApp)

        {
            _OpenWeather = OpenWeather;
            _OpenWeatherApp = OpenWeatherApp;
        }


        #endregion

        #region Implemented Methods

        public async Task<ResponseService<OpenWeatherModelDTO>> HttpGetId(int id)
        {
            ResponseService<OpenWeatherModelDTO> responseService = new ResponseService<OpenWeatherModelDTO>();
            if (id == 0)
            {
                responseService.HttpResponseMessage.StatusCode = System.Net.HttpStatusCode.NotFound;
                return responseService;
            }

            try
            {
                var rro = await _OpenWeather.GetByIdAsync(id);
                //invocacion de Get by id de Users
                var dto = OpenWeatherMapper.MapEntityToDTO(rro);
                responseService.Data = dto;
                responseService.Message = "";
                responseService.HttpResponseMessage.StatusCode = responseService.Data != null ?
                                                                        System.Net.HttpStatusCode.OK :
                                                                        System.Net.HttpStatusCode.NotFound;
                return responseService;
            }
            catch (Exception ex)
            {
                //Logger.LogCritical()
                responseService.Message = ex.Message;
                responseService.HttpResponseMessage.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                return responseService;
            }
        }

        public async Task<ResponseService<List<OpenWeatherModelDTO>>> HttpGet()
        {
            ResponseService<List<OpenWeatherModelDTO>> responseService = new ResponseService<List<OpenWeatherModelDTO>>();
            try
            {
                #region Call Data
                IList<OpenWeatherEntity> IListOpenWeather = await _OpenWeather.GetAllAsync();
                //MAPPER 
                List<OpenWeatherModelDTO> list_OpenWeather = IListOpenWeather != null ? OpenWeatherMapper.MapListEntityToDTO(IListOpenWeather.ToList())
                                                                                        : new List<OpenWeatherModelDTO>();
                #endregion

                #region Response
                responseService.Data = OpenWeatherMapper.MapListEntityToDTO(IListOpenWeather.ToList());
                responseService.Message = $"CANTIDAD DE REGISTROS {list_OpenWeather.Count}";
                responseService.HttpResponseMessage.StatusCode = responseService.Data != null
                                                            ? System.Net.HttpStatusCode.OK
                                                            : System.Net.HttpStatusCode.NotFound;

                return responseService;
                #endregion
            }
            catch (Exception ex)
            {
                responseService.Message = ex.Message;
                responseService.HttpResponseMessage.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                return responseService;
            }
        }

        public async Task<ResponseService<List<OpenWeatherModelDTO>>> HttpGetByCity(string city)
        {
            ResponseService<List<OpenWeatherModelDTO>> responseService = new ResponseService<List<OpenWeatherModelDTO>>();
            try
            {
                #region Validate
                OpenWeatherValidations.ValidateDataInclude(new OpenWeatherModelDTO() { city = city },
                                                            new string[]{nameof(city)},
                                                            true);                
                #endregion
                #region Call Data
                List<OpenWeatherEntity> entity = await _OpenWeatherApp.GetOpenWeatherByCity(city);
                #endregion

                var list_OpenWeather = OpenWeatherMapper.MapListEntityToDTO(entity);
                #region Response
                responseService.Data = entity == null ? null : list_OpenWeather;
                responseService.Message = $"CANTIDAD DE REGISTROS {list_OpenWeather.Count} OBTENIDOS";
                responseService.HttpResponseMessage.StatusCode = responseService.Data != null
                                                            ? System.Net.HttpStatusCode.OK
                                                            : System.Net.HttpStatusCode.NotFound;
                #endregion
                return responseService;
               
            }
            catch (ArgumentException ex)
            {
                responseService.Message = ex.Message;
                responseService.HttpResponseMessage.StatusCode = System.Net.HttpStatusCode.BadRequest;
                return responseService;
            }
            catch (Exception ex)
            {
                responseService.Message = ex.Message;
                responseService.HttpResponseMessage.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                return responseService;
            }
        }

        public async Task<ResponseService<OpenWeatherModelDTO>> HttpPost(OpenWeatherModelDTO entityDTO)
        {
            ResponseService<OpenWeatherModelDTO> responseService = new ResponseService<OpenWeatherModelDTO>();

            try
            {
                OpenWeatherValidations.ValidateDataInclude(entityDTO,
                                                            new string[] { nameof(entityDTO.Id) , nameof(entityDTO.datehour) },
                                                            false);

                #region Mapper

                var entity = OpenWeatherMapper.MapDTOToEntity(entityDTO);

                #endregion

                Tuple<int, OpenWeatherEntity> entityret = await _OpenWeather.SaveAsync(entity);

                OpenWeatherModelDTO entitydto = MethodsHelpersShared.Map<OpenWeatherEntity, OpenWeatherModelDTO>(entityret.Item2);

                responseService.Data = entitydto;
                responseService.Message = $"SE INGRESARON {entityret.Item1} REGISTROS";
                responseService.HttpResponseMessage.StatusCode = entityret.Item1 > 0
                                                            ? System.Net.HttpStatusCode.OK
                                                            : System.Net.HttpStatusCode.NotFound;
                return responseService;
            }
            catch (ArgumentException ex)
            {
                responseService.Message = ex.Message;
                responseService.HttpResponseMessage.StatusCode = System.Net.HttpStatusCode.BadRequest;
                return responseService;
            }
            catch (Exception ex)
            {
                responseService.Message = ex.Message;
                responseService.HttpResponseMessage.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                return responseService;
            }
        }

        public async Task<ResponseService<OpenWeatherModelDTO>> HttpPut(OpenWeatherModelDTO entityDTO)
        {
            ResponseService<OpenWeatherModelDTO> responseService = new ResponseService<OpenWeatherModelDTO>();

            try
            {
                //OpenWeatherValidations.ValidateData(entityDTO);
                OpenWeatherValidations.ValidateDataInclude(entityDTO,
                                                            new string[] { nameof(entityDTO.Id), nameof(entityDTO.datehour) },
                                                            false);

                #region Mapper 
                OpenWeatherEntity entity = OpenWeatherMapper.MapDTOToEntity(entityDTO);
                #endregion

                //ACTUALIZAR EL USUARIO  
                int entityret = await _OpenWeather.UpdateAsync(entity);
                OpenWeatherModelDTO entitydto = MethodsHelpersShared.Map<OpenWeatherEntity, OpenWeatherModelDTO>(entity);

                return new ResponseService<OpenWeatherModelDTO>(entityret,
                                                        $"SE MODIFICARON {entityret} REGISTROS",
                                                        entityDTO,
                                                        entityret > 0 ? System.Net.HttpStatusCode.OK : System.Net.HttpStatusCode.NotFound);
            }
            catch (ArgumentException ex)
            {
                responseService.Message = ex.Message;
                responseService.HttpResponseMessage.StatusCode = System.Net.HttpStatusCode.BadRequest;
                return responseService;
            }
            catch (Exception ex)
            {
                responseService.Message = ex.Message;
                responseService.HttpResponseMessage.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                return responseService;
            }
            
        }

        public async Task<ResponseService<int>> HttpDelete(int id)
        {
            ResponseService<int> responseService = new ResponseService<int>();

            try
            {
                #region Validate 
                if (id == 0)
                    throw new ArgumentException("El Id debe ser mayor a 0");
                #endregion

                //ELIMINAR REGISTRO
                int entityret = await _OpenWeather.DeleteAsync(id);

                responseService.Data = entityret;
                responseService.Message = $"SE MODIFICARON {entityret} REGISTROS";
                responseService.HttpResponseMessage.StatusCode = entityret > 0
                                            ? System.Net.HttpStatusCode.OK
                                            : System.Net.HttpStatusCode.NotFound;
                return responseService;
            }
            catch (Exception ex)
            {
                responseService.Message = ex.Message;
                responseService.HttpResponseMessage.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                return responseService;
            }
        }

        #endregion
    }
}