using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace AlexaSkill.Models
{
    [JsonObject]
    public class MonsciergeRequestOptionModel
    {
        [JsonProperty("option")]
        public OptionModel Option { get; set; }
        [JsonProperty("value_number")]
        public int ValueNumber { get; set; }
    }
}