using SkyMonitor.API.Models;
using SkyMonitor.Business.Processes;
using SkyMonitor.Data.Contracts;
using System.Web.Http;

namespace SkyMonitor.API.Controllers
{
    public class AccountController : ApiController
    {
        public AccountController(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public IHttpActionResult Post(UserModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var process = new AccountProcess(unitOfWork);

            var response = process.Create(model.Name, model.Phone);

            return GetErrorResult(response) ?? Ok(new { Succeeded = response.Succeeded, Result = response.Result });
        }
    }
}