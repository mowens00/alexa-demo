using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using AlexaSkill.Client;
using AlexaSkill.Data;
using AlexaSkill.Data.Models;
using RestSharp;

namespace AlexaSkill.Controllers
{
    public class AlexaController : ApiController
    {
        [HttpPost, Route("api/alexa/demo")]
        public AlexaResponseModel Alexa(AlexaRequestModel alexaRequest)
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
            var response = new AlexaResponseModel("Welcome to QA Resort. Please let us know if there is anything we can do to help.");
            response.Response.Card.Title = "Alexo Demo";
            response.Response.Card.Content = "Monscierge Alexa Demo";
            response.Response.Reprompt.OutputSpeech.Text = "How can we help?";
            response.Response.ShouldEndSession = false;

            if (request.Intent.Name == "AMAZON.NoIntent")
            {
                response.Response.OutputSpeech.Text = "Ok.";
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
                case "BrokenToiledSeatIntent":
                    response = BrokenToiletSeatIntentHandler();
                    break;
                case "AMAZON.CancelIntent":
                case "AMAZON.StopIntent":
                    response = CancelOrStopIntentHandler(request);
                    break;
            }

            return response;
        }

        private AlexaResponseModel SessionEndedRequestHandler(RequestModel request)
        {
            // return null until we have server side session variables to clear out here
            return null;
        }

        private AlexaResponseModel CancelOrStopIntentHandler(RequestModel request)
        {
            return new AlexaResponseModel("Canceling your request. Please let me know if you need anything else", true);
        }

        private AlexaResponseModel TowelsIntentHandler(RequestModel request)
        {
            int numberOfTowels = 3;

            // check intent slots to see if user provided us with a number of towels
            if (request.Intent.GetSlots().Any())
            {
                var slotsList = request.Intent.GetSlots();
                // set upper limit on number of towels
                int maxNumberOfTowels = 10;
                var numberOfTowelsValue = slotsList.FirstOrDefault(s => s.Key == "NumberOfTowels").Value;

                if (!string.IsNullOrWhiteSpace(numberOfTowelsValue) &&
                    int.TryParse(numberOfTowelsValue, out numberOfTowels) &&
                    !(numberOfTowels >= 1 && numberOfTowels <= maxNumberOfTowels))
                {
                    // if provided number of towels is outside of the range, send 3.
                    numberOfTowels = 3;
                }

                return new AlexaResponseModel("Thank you for your request. " + numberOfTowels + " towels are on the way", true);
            }
            // call api to open towels request
            var client = new MonsApiClient("https://api-test.monscierge.com");
            IRestResponse apiResp = client.CreateTowelsRequest(numberOfTowels);

            if (apiResp.StatusCode != HttpStatusCode.OK)
            {
                return new AlexaResponseModel("We're sorry, something went wrong with your request. Please try again.", true);
            }

            return new AlexaResponseModel("No problem. We'll send " + numberOfTowels + " more towels to your room right away.", true);

        }
        private AlexaResponseModel BrokenToiletSeatIntentHandler()
        {
            // call api to open broken toilet seat request
            var client = new MonsApiClient("https://api-test.monscierge.com");
            IRestResponse apiResp = client.CreateBrokenToiletSeatRequest();

            if (apiResp.StatusCode != HttpStatusCode.OK)
            {
                return new AlexaResponseModel("We're sorry, something went wrong with your request. Please try again.", true);
            }

            return new AlexaResponseModel("We're sorry about your broken toilet seat. An engineer will arrive shortly to fix it.", true);
        }
    }
}
