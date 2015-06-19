using PCHome24OnSales.API.Service;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace PCHome24OnSales.ViewModel
{
    public class MainPageViewModel
    {
        public ObservableCollection<OnSaleItem> Source { get; set; }

        public MainPageViewModel()
        {
            Source = new ObservableCollection<OnSaleItem>();
        }

        public async Task Initial()
        {
            Source.Clear();

            var getOnSaleItems = await GetOnSaleItemsService.Invoke();

            if (getOnSaleItems != null)
            {
                foreach (var onSaleItem in getOnSaleItems)
                {
                    Source.Add(onSaleItem);
                }
            }
        }
    }
}
