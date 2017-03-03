using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AlexaSkill.Data.Models
{
    public class OutputSpeechModel
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }

        public OutputSpeechModel()
        {
            Type = "PlainText";
        }
    }
}
