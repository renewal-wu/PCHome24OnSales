using Newtonsoft.Json;
using System;

namespace PCHome24OnSales.API.Service.GetOnSaleItems
{
    public class ImageData
    {
        [JsonProperty("Src")]
        public String Source { get; set; }

        [JsonProperty("Title")]
        public String Title { get; set; }

        public String ImageSourceUrl
        {
            get
            {
                if (String.IsNullOrEmpty(Source) == false)
                {
                    return "http://24h.pchome.com.tw/" + Source;
                }

                return null;
            }
        }
    }
}
