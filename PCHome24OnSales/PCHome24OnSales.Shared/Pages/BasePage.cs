#if WINDOWS_PHONE_APP
using Windows.UI.ViewManagement;
#endif

using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml.Controls;

namespace PCHome24OnSales.Pages
{
    public class BasePage : Page
    {
        protected virtual void ShowProgressBar()
        {
#if WINDOWS_PHONE_APP
            StatusBar statusBar = StatusBar.GetForCurrentView();
            statusBar.ProgressIndicator.Text = "讀取中...";
            statusBar.ProgressIndicator.ShowAsync();
            statusBar.ShowAsync();
#endif
        }

        protected virtual void HideProgressBar()
        {
#if WINDOWS_PHONE_APP
            StatusBar.GetForCurrentView().HideAsync();
#endif
        }
    }
}
