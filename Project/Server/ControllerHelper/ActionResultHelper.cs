using Microsoft.AspNetCore.Mvc;
using Project.Shared;

namespace Project.ControllerHelper
{

    public interface IActionResultHelper
    {
        IActionResult GetActionResult<T>(ResponseService<T> responseServiceObject);
    }

    public class ActionResultHelper : IActionResultHelper
    {                
        public IActionResult GetActionResult<T>(ResponseService<T> responseServiceObject)
        {
            //responseServiceObject.HttpResponseMessage.StatusCode se setea en las clases Services implementadas
            switch (responseServiceObject.HttpResponseMessage.StatusCode)
            {
                case System.Net.HttpStatusCode.OK:
                    return new OkObjectResult(responseServiceObject);
                case System.Net.HttpStatusCode.BadRequest:
                    return new BadRequestObjectResult(responseServiceObject);
                case System.Net.HttpStatusCode.NotFound:
                    return new NotFoundObjectResult(responseServiceObject);
                case System.Net.HttpStatusCode.InternalServerError:
                    return new ObjectResult(responseServiceObject)
                    {
                        StatusCode = 500
                    };
                case System.Net.HttpStatusCode.Conflict:
                    return new ConflictObjectResult(responseServiceObject);
                default:
                    return new ObjectResult(responseServiceObject)
                    {
                        StatusCode = 500,
                        Value = responseServiceObject
                    };
            }
        }
    }

}
