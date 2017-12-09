using SkyMonitor.Business.Processes;
using SkyMonitor.Commons.Entities;
using SkyMonitor.Commons.Extensions;
using SkyMonitor.Data.Contracts;
using System.IO;

namespace SkyMonitor.API.Controllers
{
    public class LocationController : ApiController
    {
        public LocationController(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public void Post(MemoryStream stream)
        {
            try
            {
                Packet packet = stream.Parse();

                var process = new ProtocolProcess(unitOfWork);

                process.Orchestrate(packet);
            }
            catch { }
        }
    }
}
