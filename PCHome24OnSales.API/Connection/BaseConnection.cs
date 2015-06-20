using System;
using System.Threading.Tasks;
using Windows.Web.Http;

namespace PCHome24OnSales.API.Connection
{
    public class BaseConnection
    {
        public static UInt32 MaxRetryTimes = 3;

        public async static Task<TData> Connect<TData, TParser>(IService<TData, TParser> service)
            where TParser : IParser<TData>, new()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                TData dataResult = default(TData);
                Int32 retryTimes = 0;

            Connection:
                using (var serviceConnection = await httpClient.GetAsync(service.TargetUri))
                {
                    if (serviceConnection.StatusCode == HttpStatusCode.Ok)
                    {
                        var serviceResultString = await serviceConnection.Content.ReadAsStringAsync();

                        if (String.IsNullOrWhiteSpace(serviceResultString))
                        {
                            dataResult = default(TData);
                        }
                        else
                        {
                            TParser parser = new TParser();
                            dataResult = parser.Parse(serviceResultString);
                        }
                    }
                    else if (retryTimes < MaxRetryTimes)
                    {
                        retryTimes++;
                        serviceConnection.Dispose();
                        goto Connection;
                    }

                    return dataResult;
                }
            }
        }
    }
}
