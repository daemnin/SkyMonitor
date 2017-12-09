using SkyMonitor.API.Models;
using SkyMonitor.Business.Processes;
using SkyMonitor.Data.Contracts;
using System.Web.Http;

namespace SkyMonitor.API.Controllers
{
    public class AlarmController : ApiController
    {
        public AlarmController(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        [HttpPost]
        [Route("api/device/alarm/enable")]
        public IHttpActionResult Enable(AlarmModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var process = new AlarmProcess(unitOfWork);

            var response = process.Enable(model.DeviceId);

            return GetErrorResult(response) ?? Ok(new { response.Succeeded });
        }

        [HttpPost]
        [Route("api/device/alarm/disable")]
        public IHttpActionResult Disable(AlarmModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var process = new AlarmProcess(unitOfWork);

            var response = process.Disable(model.DeviceId);

            return GetErrorResult(response) ?? Ok(new { response.Succeeded });
        }
    }
}