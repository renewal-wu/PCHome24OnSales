using Newtonsoft.Json;
using PCHome24OnSales.API.Service.GetOnSaleItems;
using System;
using System.Collections.Generic;

namespace PCHome24OnSales.API.Service
{
    public class OnSaleItem
    {
        [JsonProperty("BlockId")]
        public Int32 BlockId { get; set; }

        [JsonProperty("Nodes")]
        public List<Node> Nodes { get; set; }

        public String BlockTitle { get; set; }
    }
}
