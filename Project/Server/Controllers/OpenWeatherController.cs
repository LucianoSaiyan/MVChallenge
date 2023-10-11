using Microsoft.AspNetCore.Mvc;
using Project.ControllerHelper;
using Project.Service;
using Project.Shared;
using Project.Shared.DTOs;

namespace Project.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OpenWeatherController : ControllerBase
    {
        #region Variables and Properties
        
        private readonly IOpenWeatherService _OpenWeatherService;
        public IActionResultHelper ActionResultHelper { get; }
        #endregion

        #region Constructor

        public OpenWeatherController(IOpenWeatherService openWeatherService, IActionResultHelper actionResultHelper)
        {
            _OpenWeatherService = openWeatherService;
            ActionResultHelper = actionResultHelper;
        }

        #endregion

        #region Methods Http

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            ResponseService<List<OpenWeatherModelDTO>> responseserviceobject =
                    await _OpenWeatherService.HttpGet();
            return ActionResultHelper.GetActionResult(responseserviceobject);
        }

        [HttpGet("id")]
        public async Task<IActionResult> Get(int id)
        {
            ResponseService<OpenWeatherModelDTO> responseserviceobject = await _OpenWeatherService.HttpGetId(id);
            return ActionResultHelper.GetActionResult(responseserviceobject);
        }

        [HttpGet("city/{city}")]
        public async Task<IActionResult> Get(string city)
        {
            ResponseService<List<OpenWeatherModelDTO>> responseserviceobject = await _OpenWeatherService.HttpGetByCity(city);
            return ActionResultHelper.GetActionResult(responseserviceobject);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] OpenWeatherModelDTO entityDTO)
        {
            ResponseService<OpenWeatherModelDTO> responseserviceobject = await _OpenWeatherService.HttpPost(entityDTO);
            return ActionResultHelper.GetActionResult(responseserviceobject);
        }

        /// <summary>
        /// SIN FUNCIONALIDAD
        /// </summary>
        /// <param name="usuarioDTO"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] OpenWeatherModelDTO usuarioDTO)
        {
            ResponseService<OpenWeatherModelDTO> responseserviceobject = await _OpenWeatherService.HttpPut(usuarioDTO);
            return ActionResultHelper.GetActionResult(responseserviceobject);
        }

        /// <summary>
        ///  SIN PROBAR DADO QUE HAY QUE BRINDARLE UNA CIUDAD PARA QUE ENCUENTRE O BIEN BIFURCAR LA ENTIDAD QUE INTERVIENE
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            ResponseService<int> responseserviceobject = await _OpenWeatherService.HttpDelete(id);
            return ActionResultHelper.GetActionResult(responseserviceobject);
        }


        #endregion

    }
}