using System;
using System.Threading.Tasks;
using Windows.Web.Http;

namespace PCHome24OnSales.API.Connection
{
    public class BaseConnection
    {
        public async static Task<TData> Connect<TData, TParser>(IService<TData, TParser> service)
            where TParser : IParser<TData>, new()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                using (var serviceConnection = await httpClient.GetAsync(service.TargetUri))
                {
                    var serviceResultString = await serviceConnection.Content.ReadAsStringAsync();

                    TData dataResult;

                    if (String.IsNullOrWhiteSpace(serviceResultString))
                    {
                        dataResult = default(TData);
                    }
                    else
                    {
                        TParser parser = new TParser();
                        dataResult = parser.Parse(serviceResultString);
                    }

                    return dataResult;
                }
            }
        }
    }
}
