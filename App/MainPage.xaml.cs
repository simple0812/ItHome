using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
using App.Controls;

//“空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 上有介绍

namespace App
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            fvControl.ItemsSource = new List<string>() {"/Images/1.jpg", "/Images/1.jpg" , "/Images/2.jpg", "/Images/2.jpg" };
        }

        private async void MainPage_OnLoaded(object sender, RoutedEventArgs e)
        {
            await ShowSystemTray();
            coverLayer.LogoAnimate.Begin();
            new CustomMsg().Alert("hahahh呵呵呵");
        }

        private async Task ShowSystemTray()
        {
            var statusbar = "Windows.UI.ViewManagement.StatusBar";
            if (ApiInformation.IsTypePresent(statusbar))
            {
                await Windows.UI.ViewManagement.StatusBar.GetForCurrentView().HideAsync();
            }
        }


        private void Pivot_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = pivot.SelectedItem as PivotItem;
            if (item != null) new CustomMsg().Alert(item.Header.ToString());
        }
    }
}
