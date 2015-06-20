using Newtonsoft.Json;
using PCHome24OnSales.API.Service.GetOnSaleItems;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Windows.UI.Xaml.Media;

namespace PCHome24OnSales.API.Service
{
    public class OnSaleItem : INotifyPropertyChanged
    {
        [JsonProperty("BlockId")]
        public Int32 BlockId { get; set; }

        [JsonProperty("Nodes")]
        public List<Node> Nodes { get; set; }

        public String BlockTitle { get; set; }

        private SolidColorBrush blockForeground;
        public SolidColorBrush BlockForeground
        {
            get
            {
                return blockForeground;
            }
            set
            {
                if (value != blockForeground)
                {
                    blockForeground = value;
                    NotifyPropertyChanged("BlockForeground");
                }
            }
        }

        public DateTime Date { get; set; }

        public Boolean IsWeekend { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
