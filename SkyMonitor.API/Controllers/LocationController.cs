using SkyMonitor.Business.Processes;
using SkyMonitor.Commons.Entities;
using SkyMonitor.Commons.Extensions;
using SkyMonitor.Data.Contracts;
using System.Web.Http;

namespace SkyMonitor.API.Controllers
{
    public class LocationController : ApiController
    {
        public LocationController(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        [HttpPost]
        public async void Post()
        {
            try
            {
                var buffer = await Request.Content.ReadAsByteArrayAsync();

                Packet packet = buffer.Parse();

                var process = new ProtocolProcess(unitOfWork);

                process.Orchestrate(packet);
            }
            catch { }
        }
    }
}