using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexaSkill.Data.Models
{
    public class RequestModel
    {
        public string Type { get; set; }
        public string RequestId { get; set; }
        public string Locale { get; set; }
        public string Timestamp { get; set; }
        public IntentModel Intent { get; set; }
    }
}
