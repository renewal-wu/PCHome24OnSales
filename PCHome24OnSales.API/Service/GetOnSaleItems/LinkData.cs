using Newtonsoft.Json;
using System;

namespace PCHome24OnSales.API.Service.GetOnSaleItems
{
    public class LinkData
    {
        [JsonProperty("Url")]
        public String Url { get; set; }

        [JsonProperty("Text")]
        public String Text { get; set; }

        [JsonProperty("Text1")]
        public String Text1 { get; set; }

        [JsonProperty("Text2")]
        public String Text2 { get; set; }

        [JsonProperty("Text3")]
        public String Text3 { get; set; }

        public String Price
        {
            get
            {
                if (String.IsNullOrEmpty(Text2) == false)
                {
                    return Text2 + "元";
                }

                return String.Empty;
            }
        }
    }
}
