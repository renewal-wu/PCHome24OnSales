using PCHome24OnSales.API.Service;
using PCHome24OnSales.API.Service.GetOnSaleItems;
using PCHome24OnSales.API.Utility;
using PCHome24OnSales.API.View;
using PCHome24OnSales.Pages;
using PCHome24OnSales.ViewModel;
using System;
using System.Threading.Tasks;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Navigation;


namespace PCHome24OnSales
{
    public sealed partial class MainPage : BasePage
    {
        private MainPageViewModel viewModel { get; set; }

        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;

            viewModel = new MainPageViewModel();

            this.DataContext = viewModel;
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            initialData();
        }

        private async Task initialData()
        {
            ShowProgressBar();
            await viewModel.Initial();
            HideProgressBar();
        }

        private void OnSaleItemsClick(object sender, ItemClickEventArgs e)
        {
            var clickItem = e.ClickedItem as Node;

            if (clickItem != null &&
                clickItem.Link != null &&
                String.IsNullOrEmpty(clickItem.Link.Url) == false &&
                Uri.IsWellFormedUriString(clickItem.Link.Url, UriKind.RelativeOrAbsolute))
            {
                Launcher.LaunchUriAsync(new Uri(clickItem.Link.Url, UriKind.RelativeOrAbsolute));
            }
        }

        private void OnSalesPivotSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems != null)
            {
                foreach (var addedItem in e.AddedItems)
                {
                    var item = addedItem as OnSaleItem;
                    if (item != null)
                    {
                        item.BlockForeground = SolidColorBrushs.WhiteColorBrush;
                    }
                }
            }

            if (e.RemovedItems != null)
            {
                foreach (var removedItem in e.RemovedItems)
                {
                    var item = removedItem as OnSaleItem;
                    if (item != null)
                    {
                        item.BlockForeground = SolidColorBrushs.GrayColorBrush;
                    }
                }
            }
        }

        private void OnSaleItemHolding(object sender, Windows.UI.Xaml.Input.HoldingRoutedEventArgs e)
        {
            FrameworkElement senderElement = sender as FrameworkElement;
            var sourceData = senderElement.DataContext as Node;
            if (sourceData.ExtraData != null && sourceData.ExtraData.IsUnlimitedSale == false)
            {
                FlyoutBase flyoutBase = this.Resources["OnSaleItemFlyout"] as FlyoutBase;
                flyoutBase.ShowAt(senderElement);
            }
        }

        private async void OnAddAppointmentClick(object sender, RoutedEventArgs e)
        {
            var senderElement = sender as FrameworkElement;
            if (senderElement != null)
            {
                var sourceData = senderElement.DataContext as Node;
                if (sourceData != null)
                {
                    var result = await AppointmentHelper.AddReminder(sourceData, this.viewModel.Source[0].Date, this.viewModel.Source[0].IsWeekend);
                    if (result == true)
                    {

                    }
                }
            }
        }

        private async void OnRefreshButtonClick(object sender, RoutedEventArgs e)
        {
            Int32 currentPivotItemIndex = OnSalesPivot.SelectedIndex;
            await initialData();
            if (viewModel.Source != null && viewModel.Source.Count > currentPivotItemIndex)
            {
                OnSalesPivot.SelectedIndex = currentPivotItemIndex;
            }
        }
    }
}
