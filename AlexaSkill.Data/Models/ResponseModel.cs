using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexaSkill.Data.Models
{
    public class ResponseModel
    {
        public OutputSpeechModel OutputSpeech { get; set; }
        public CardModel Card { get; set; }
        public RepromptModel Reprompt { get; set; }
        public bool ShouldEndSession { get; set; }
    }
}
