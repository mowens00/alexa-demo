using System.Threading.Tasks;
using AlexaSkill.Models;
using Newtonsoft.Json;
using RestSharp;

namespace AlexaSkill.Client
{
    public class MonsApiClient
    {
        private readonly RestClient _client;

        public MonsApiClient(string baseUrl)
        {
            _client = new RestClient(baseUrl);
        }

        // PUT - create towels request
        public async Task<IRestResponse<object>> CreateTowelsRequest(int numberOfTowels)
        {
            var model = new MonsciergeRequestModel()
            {
                // i'm using request template Towels under Bathroom Requests on QA Resort (placeId = 467084)
                RequestTemplateId = 123718,
                Options = new [] {
                    new MonsciergeRequestOptionsModel()
                    {
                        Option = new MonsciergeRequestOptionModel()
                        {
                            Id = 177833,
                            Name = "How many towels do you require?",
                            TemplateId = 123718,
                            ValueNumber = numberOfTowels
                        }
                    }
                },
                // request user for matt owens
                RequestUserId = 53161
            };

            var request = new RestRequest("/v1/Requests", Method.PUT);
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Authorization", "S_AECB484B-15D4-4391-AE47-F9BC7FA0CC15");
            request.AddParameter("application/json", JsonConvert.SerializeObject(model), ParameterType.RequestBody);

            var response = await _client.ExecutePostTaskAsync<object>(request);

            return response;
        }
    }
}
