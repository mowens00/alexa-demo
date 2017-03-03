using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using AlexaSkill.Data;
using AlexaSkill.Data.Models;

namespace AlexaSkill.Controllers
{
    public class AlexaController : ApiController
    {
        [HttpPost, Route("api/alexa/demo")]
        public AlexaResponseModel Pluralsight(AlexaRequestModel alexaRequest)
        {

            var request = alexaRequest.Request;

            AlexaResponseModel response = null;

            switch (request.Type)
            {
                case "LaunchRequest":
                    response = LaunchRequestHandler(request);
                    break;
                case "IntentRequest":
                    response = IntentRequestHandler(request);
                    break;
                case "SessionEndedRequest":
                    response = SessionEndedRequestHandler(request);
                    break;
            }

            return response;
        }

        private AlexaResponseModel LaunchRequestHandler(RequestModel request)
        {
            var response = new AlexaResponseModel("Welcome to QA Resort. Do you need more towels? Or maybe you forgot a toothbrush");
            response.Response.Card.Title = "Alexo Demo";
            response.Response.Card.Content = "Hello world";
            response.Response.Reprompt.OutputSpeech.Text = "Please pick one, more towels or a toothbrush?";
            response.Response.ShouldEndSession = false;

            if (request.Intent.Name == "AMAZON.NoIntent")
            {
                response.Response.OutputSpeech.Text = "Ok. When would you like them?";
                response.Response.ShouldEndSession = true;
            }

            return response;
        }
        private AlexaResponseModel IntentRequestHandler(RequestModel request)
        {
            AlexaResponseModel response = null;

            switch (request.Intent.Name)
            {
                case "TowelsIntent":
                    response = TowelsIntentHandler(request);
                    break;
                case "ToothbrushIntent":
                    response = ToothbrushIntentHandler(request);
                    break;
            }

            return response;
        }
        private AlexaResponseModel SessionEndedRequestHandler(RequestModel request)
        {
            // return null until we have server side session variables to clear out here
            return null;
        }
        private AlexaResponseModel TowelsIntentHandler(RequestModel request)
        {
            int numberOfTowels = 2;

            if (request.Intent.GetSlots().Any())
            {
                var slotsList = request.Intent.GetSlots();
                // set upper limit on number of towels
                int maxNumberOfTowels = 10;
                var numberOfTowelsValue = slotsList.FirstOrDefault(s => s.Key == "NumberOfTowels").Value;

                if (!string.IsNullOrWhiteSpace(numberOfTowelsValue) && int.TryParse(numberOfTowelsValue, out numberOfTowels) &&
                    !(numberOfTowels >= 1 && numberOfTowels <= maxNumberOfTowels))
                {
                    numberOfTowels = maxNumberOfTowels;
                }
            }

            var output = new StringBuilder(numberOfTowels + "towels are on the way");

            return new AlexaResponseModel(output.ToString());
        }
        private AlexaResponseModel ToothbrushIntentHandler(RequestModel request)
        {
            var output = new StringBuilder("Your toothbrush is on the way");

            return new AlexaResponseModel(output.ToString());
        }
    }
}
