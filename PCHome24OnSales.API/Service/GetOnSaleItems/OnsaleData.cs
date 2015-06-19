using Newtonsoft.Json;
using System;

namespace PCHome24OnSales.API.Service.GetOnSaleItems
{
    public class OnsaleData
    {
        [JsonProperty("Sign")]
        public String Sign { get; set; }

        [JsonProperty("Style")]
        public String Style { get; set; }

        [JsonProperty("Time")]
        public String Time { get; set; }
    }
}
