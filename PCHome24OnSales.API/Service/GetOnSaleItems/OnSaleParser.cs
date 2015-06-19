using Newtonsoft.Json;
using PCHome24OnSales.API.Connection;
using System;
using System.Collections.Generic;

namespace PCHome24OnSales.API.Service
{
    public class OnSaleParser : IParser<IList<OnSaleItem>>
    {
        private List<String> titleArray = new List<String>()
        {
            "每日三檔特賣",
            "3C數位/手機",
            "家電/生活",
            "食日用/時尚"
        };

        public IList<OnSaleItem> Parse(String source)
        {
            String[] resultArray = source.Split(new String[] { "var WelcomeJson = ", "var OnsaleJson = " }, StringSplitOptions.RemoveEmptyEntries);

            List<OnSaleItem> collection = new List<OnSaleItem>();

            foreach (String result in resultArray)
            {
                try
                {
                    String sourceResult = result.TrimEnd(';').Replace("<br \\/>", Environment.NewLine);

                    var onSaleItem = JsonConvert.DeserializeObject<List<OnSaleItem>>(sourceResult);

                    if (onSaleItem != null)
                    {
                        collection.AddRange(onSaleItem);
                    }
                }
                catch (Exception ex)
                {

                }
            }

            for (Int32 i = 0; i < collection.Count; i++)
            {
                if (titleArray.Count > i)
                {
                    collection[i].BlockTitle = titleArray[i];
                }
                else
                {
                    collection[i].BlockTitle = "特賣";
                }
            }

            return collection;
        }
    }
}
