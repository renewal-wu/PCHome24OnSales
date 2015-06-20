using PCHome24OnSales.API.Service;
using PCHome24OnSales.API.Service.GetOnSaleItems;
using PCHome24OnSales.API.Utility;
using PCHome24OnSales.API.View;
using PCHome24OnSales.Pages;
using PCHome24OnSales.ViewModel;
using System;
using System.Threading.Tasks;
using Windows.System;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Media;
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

            if (viewModel.Source != null && viewModel.Source.Count > 0)
            {
                IndexListView.SelectedIndex = 0;
            }

            HideProgressBar();
        }

        private void OnIndexListViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems == null || e.AddedItems.Count <= 0)
            {
                if (e.RemovedItems != null && e.RemovedItems.Count > 0)
                {
                    IndexListView.SelectedItem = e.RemovedItems[0];
                }
            }
        }

        private void OnItemListViewClick(object sender, ItemClickEventArgs e)
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

        private async void OnRefreshButtonClick(object sender, RoutedEventArgs e)
        {
            Int32 currentIndexItemIndex = IndexListView.SelectedIndex;
            await initialData();
            if (viewModel.Source != null && viewModel.Source.Count > currentIndexItemIndex)
            {
                IndexListView.SelectedIndex = currentIndexItemIndex;
            }
        }

        protected override void ShowProgressBar()
        {
            LoadProgressBar.Visibility = Visibility.Visible;
        }

        protected override void HideProgressBar()
        {
            LoadProgressBar.Visibility = Visibility.Collapsed;
        }
    }
}
