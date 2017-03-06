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
        public IRestResponse CreateTowelsRequest(int numberOfTowels)
        {

            MonsciergeRequestOptionModel[] model = { new MonsciergeRequestOptionModel()
                {
                    Option = new OptionModel()
                        {
                            Id = 177833,
                            Name = "How many towels do you require?",
                            TemplateId = 123718,
                        },
                    ValueNumber = numberOfTowels
                }
            };

            var request = new RestRequest("/v1/Places/467084/Requests/Anonymous", Method.PUT);
            request.RequestFormat = DataFormat.Json;
            request.AddQueryParameter("placeId", "467084");
            request.AddQueryParameter("deviceToken", "alexa demo");
            request.AddQueryParameter("deviceId", "alexa demo");
            request.AddQueryParameter("firstName", "Matt");
            request.AddQueryParameter("lastName", "Owens");
            request.AddQueryParameter("templateId", "123718");
            request.AddHeader("Authorization", "Bearer S_AECB484B-15D4-4391-AE47-F9BC7FA0CC15");
            request.AddParameter("application/json", JsonConvert.SerializeObject(model), ParameterType.RequestBody);

            var response = _client.Execute(request);

            return response;
        }

        public IRestResponse CreateBrokenToiletSeatRequest()
        {

            var request = new RestRequest("/v1/Places/467084/Requests/Anonymous", Method.PUT);
            request.RequestFormat = DataFormat.Json;
            request.AddQueryParameter("placeId", "467084");
            request.AddQueryParameter("deviceToken", "alexa demo");
            request.AddQueryParameter("deviceId", "alexa demo");
            request.AddQueryParameter("firstName", "Matt");
            request.AddQueryParameter("lastName", "Owens");
            request.AddQueryParameter("templateId", "123781");
            request.AddHeader("Authorization", "Bearer S_AECB484B-15D4-4391-AE47-F9BC7FA0CC15");

            var response = _client.Execute(request);

            return response;
        }

    }
}
