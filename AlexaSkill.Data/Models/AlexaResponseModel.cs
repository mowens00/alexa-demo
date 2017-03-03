using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexaSkill.Data.Models
{
    public class AlexaResponseModel
    {
        public string Version { get; set; }
        public SessionAttributesModel SessionAttributes { get; set; }
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
