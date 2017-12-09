using SkyMonitor.API.Models;
using SkyMonitor.Business.Processes;
using SkyMonitor.Data.Contracts;
using System.Web.Http;

namespace SkyMonitor.API.Controllers
{
    [RoutePrefix("api/device/alarm")]
    public class AlarmController : ApiController
    {
        public AlarmController(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        [HttpPost]
        [Route(Name = "Enable")]
        public IHttpActionResult Enable(AlarmModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var process = new AlarmProcess(unitOfWork);

            var response = process.Enable(model.DeviceId);

            return GetErrorResult(response) ?? Ok(new { response.Succeeded });
        }

        [HttpPost]
        [Route(Name = "Disable")]
        public IHttpActionResult Disable(AlarmModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var process = new AlarmProcess(unitOfWork);

            var response = process.Disable(model.DeviceId);

            return GetErrorResult(response) ?? Ok(new { response.Succeeded });
        }
    }
}