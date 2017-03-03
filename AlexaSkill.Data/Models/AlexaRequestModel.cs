using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexaSkill.Data.Models
{
    public class AlexaRequestModel
    {
        public SessionModel Session { get; set; }
        public RequestModel Request { get; set; }
        public string Version { get; set; }
    }
}
