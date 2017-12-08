using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace SkyMonitor.Commons.Entities
{
    public class Response
    {
        public bool Succeeded { get; set; }
        public JToken Result { get; set; }
        public ICollection<string> Errors { get; set; }

        public Response()
        {
            Errors = new HashSet<string>();
        }
    }
}
