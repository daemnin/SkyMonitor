using SkyMonitor.Commons.Entities;
using SkyMonitor.Data.Contracts;
using System.Web.Http;

namespace SkyMonitor.API.Controllers
{
    public abstract class ApiController : System.Web.Http.ApiController
    {
        protected IUnitOfWork unitOfWork;

        public ApiController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        protected IHttpActionResult GetErrorResult(Response response)
        {
            if (response == null)
            {
                return InternalServerError();
            }

            if (!response.Succeeded)
            {
                if (response.Errors != null)
                {
                    foreach (string error in response.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                return BadRequest(ModelState);
            }

            return null;
        }
    }
}