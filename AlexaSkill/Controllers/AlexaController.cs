using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AlexaSkill.Controllers
{
    public class AlexaController : ApiController
    {
        [HttpPost, Route("api/alexa/demo")]
        public dynamic Pluralsight(dynamic request)
        {
            return new
            {
                version = "1.0",
                sessionAttributes = new {},
                response = new
                {
                    outputSpeech = new
                    {
                        type = "PlainText",
                        text = "Hi Ernie. Matt is the best!"
                    },
                    card = new
                    {
                        type = "Simple",
                        title = "Pluralsight",
                        content = "Hello cruel world!",
                    },
                    shouldEndSession = true
                }
            };

        }
    }
}
