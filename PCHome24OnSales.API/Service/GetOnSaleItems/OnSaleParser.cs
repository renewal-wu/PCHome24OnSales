using Newtonsoft.Json;
using PCHome24OnSales.API.Connection;
using PCHome24OnSales.API.View;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

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
                    String sourceResult = filterString(result);

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

            DateTime dateTime = DateTime.Today;
            Boolean isWeekend = false;

            if (collection.Count > 0 && collection[0].Nodes != null && collection[0].Nodes.Count > 0 && collection[0].Nodes[0].ExtraData != null && collection[0].Nodes.Count > 0 && collection[0].Nodes[0].ExtraData.IsWeekendSale == true)
            {
                isWeekend = true;
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

                if (i == 0)
                {
                    collection[i].BlockForeground = SolidColorBrushs.WhiteColorBrush;
                }
                else
                {
                    collection[i].BlockForeground = SolidColorBrushs.GrayColorBrush;
                }

                collection[i].Date = dateTime;
                collection[i].IsWeekend = isWeekend;
            }

            return collection;
        }

        private String filterString(String originalString)
        {
            // filter ;
            String filteredString = originalString.TrimEnd(';');

            // filter all html tags
            filteredString = Regex.Replace(filteredString, @"<[^>]*>", String.Empty);

            return filteredString;
        }
    }
}
