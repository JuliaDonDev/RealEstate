using System.Collections.Generic;
using Newtonsoft.Json;

namespace RealEstate.Models
{
    public class SoldEstate
    {
        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("soldPrice")] 
        public string Price { get; set; }

        [JsonProperty("area")]
        public string Area { get; set; }

        [JsonProperty("variableData")]
        public Dictionary<string, string> VariableData { get; set; }
    }
}
