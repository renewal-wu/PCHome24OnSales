using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCHome24OnSales.API.Service.GetOnSaleItems
{
    public class Node
    {
        [JsonProperty("Id")]
        public Int32 Id { get; set; }

        [JsonProperty("Link")]
        public LinkData Link { get; set; }

        [JsonProperty("Img")]
        public ImageData Img { get; set; }

        [JsonProperty("Img1")]
        public ImageData Img1 { get; set; }

        public ImageData Image
        {
            get
            {
                return Img ?? Img1;
            }
        }

        [JsonProperty("ExtraData")]
        public ExtraData ExtraData { get; set; }
    }
}
