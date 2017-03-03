using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AlexaSkill.Data.Models
{
    [JsonObject]
    public class ResponseModel
    {
        [JsonProperty("outputSpeech")]
        public OutputSpeechModel OutputSpeech { get; set; }
        [JsonProperty("card")]
        public CardModel Card { get; set; }
        [JsonProperty("reprompt")]
        public RepromptModel Reprompt { get; set; }
        [JsonProperty("shouldEndSession")]
        public bool ShouldEndSession { get; set; }

        public ResponseModel()
        {
            OutputSpeech = new OutputSpeechModel();
            Card = new CardModel();
            Reprompt = new RepromptModel();
        }

    }
}
