using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AlexaSkill.Data.Models
{
    [JsonObject]
    public class AlexaResponseModel
    {
        [JsonProperty("version")]
        public string Version { get; set; }
        [JsonProperty("sessionAttributes")]
        public SessionAttributesModel SessionAttributes { get; set; }
        [JsonProperty("response")]
        public ResponseModel Response { get; set; }

        public AlexaResponseModel()
        {
            Version = "1.0";
            SessionAttributes = new SessionAttributesModel();
            Response = new ResponseModel();
        }

        public AlexaResponseModel(string outputSpeechText) : this()
        {
            Response.OutputSpeech.Text = outputSpeechText;
            Response.Card.Content = outputSpeechText;
        }

        public AlexaResponseModel(string outputSpeechText, bool shouldEndSession) : this()
        {
            Response.OutputSpeech.Text = outputSpeechText;
            Response.ShouldEndSession = shouldEndSession;

            if (shouldEndSession)
            {
                Response.Card.Content = outputSpeechText;
            }
            else
            {
                Response.Card = null;
            }
        }

        public AlexaResponseModel(string outputSpeechText, string cardContent) : this()
        {
            Response.OutputSpeech.Text = outputSpeechText;
            Response.Card.Content = cardContent;
        }
    }
}
