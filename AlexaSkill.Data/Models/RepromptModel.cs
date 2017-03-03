using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AlexaSkill.Data.Models
{
    public class RepromptModel
    {
        [JsonProperty("outputSpeech")]
        public OutputSpeechModel OutputSpeech { get; set; }

        public RepromptModel()
        {
            OutputSpeech = new OutputSpeechModel();
        }
    }
}
