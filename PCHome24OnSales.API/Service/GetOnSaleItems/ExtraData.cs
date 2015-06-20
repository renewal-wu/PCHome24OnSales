using Newtonsoft.Json;
using System;

namespace PCHome24OnSales.API.Service.GetOnSaleItems
{
    public class ExtraData
    {
        [JsonProperty("Prod")]
        public ProductData Product { get; set; }

        [JsonProperty("Onsale")]
        public OnsaleData Onsale { get; set; }

        [JsonProperty("Time")]
        public String Time { get; set; }

        public String CurrentTime
        {
            get
            {
                String result = String.Empty;

                if (Onsale != null && String.IsNullOrEmpty(Onsale.Time) == false)
                {
                    result = Onsale.Time;
                }
                else
                {
                    result = Time;
                }

                return result;
            }
        }

        public String TimeString
        {
            get
            {
                String result = CurrentTime;

                String[] timeArray = HourArray;
                if (timeArray != null && timeArray.Length > 0)
                {
                    timeArray[0] = transHour(timeArray[0]);
                    result = String.Join(":", timeArray);
                }

                return result;
            }
        }

        public String[] HourArray
        {
            get
            {
                String[] result = null;

                if (String.IsNullOrEmpty(CurrentTime) == false)
                {
                    String[] timeArray = CurrentTime.Split(new String[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                    if (timeArray != null && timeArray.Length > 0)
                    {
                        result = timeArray;
                    }
                }

                return result;
            }
        }

        private String transHour(String originHour)
        {
            if (String.IsNullOrEmpty(originHour) == false)
            {
                Int32 resultHourInt = 0;
                if (Int32.TryParse(originHour, out resultHourInt) && resultHourInt >= 24)
                {
                    resultHourInt = resultHourInt % 24;
                    return resultHourInt.ToString("D2");
                }
            }

            return originHour;
        }
    }
}
