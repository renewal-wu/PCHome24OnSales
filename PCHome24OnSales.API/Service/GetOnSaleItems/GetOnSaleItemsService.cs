using PCHome24OnSales.API.Connection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PCHome24OnSales.API.Service
{
    public class GetOnSaleItemsService : IService<IList<OnSaleItem>, OnSaleParser>
    {
        public Uri TargetUri
        {
            get
            {
                String date = DateTime.Today.ToString("yyyyMMdd");
                return new Uri(String.Format("http://24h.pchome.com.tw/onsale/v2/{0}/data.json", date), UriKind.Absolute);
            }
        }

        public static async Task<IList<OnSaleItem>> Invoke()
        {
            GetOnSaleItemsService service = new GetOnSaleItemsService();
            var result = await BaseConnection.Connect(service);
            return result;
        }
    }
}
