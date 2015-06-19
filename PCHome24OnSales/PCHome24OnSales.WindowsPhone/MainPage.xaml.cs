using PCHome24OnSales.API.Service.GetOnSaleItems;
using PCHome24OnSales.ViewModel;
using System;
using Windows.System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;


namespace PCHome24OnSales
{
    public sealed partial class MainPage : Page
    {
        private MainPageViewModel viewModel { get; set; }

        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;

            viewModel = new MainPageViewModel();

            this.DataContext = viewModel;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            viewModel.Initial();
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
    }
}
