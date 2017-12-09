using SkyMonitor.API.Models;
using SkyMonitor.Business.Processes;
using SkyMonitor.Data.Contracts;
using System.Web.Http;

namespace SkyMonitor.API.Controllers
{
    public class DeviceController : ApiController
    {
        public DeviceController(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public IHttpActionResult Post(DeviceModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var process = new DeviceProcess(unitOfWork);

            var response = process.Create(model.Id, model.Name, model.Range);

            return GetErrorResult(response) ?? Ok(new { response.Succeeded });
        }

        [HttpPost]
        [Route("api/device/assign")]
        public IHttpActionResult Assign(AssignModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var process = new DeviceProcess(unitOfWork);

            var response = process.Assign(model.DeviceId, model.Phone);

            return GetErrorResult(response) ?? Ok(new { response.Succeeded });
        }
    }
}
