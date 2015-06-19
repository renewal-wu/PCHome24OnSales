﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PCHome24OnSales.API.Service.GetOnSaleItems
{
    public class ProductData
    {
        [JsonProperty("Id")]
        public String Id { get; set; }

        [JsonProperty("SaleQtyDaily")]
        public Int32 SaleQuantityDaily { get; set; }
    }
}
