using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace App.Controls
{
    public sealed partial class CoverLayer : UserControl
    {
        public StackPanel StackPanel => sp;
        public Storyboard CoverAnimate => sbCover;
        public Storyboard LogoAnimate => sb;

        public CoverLayer()
        {
            this.InitializeComponent();
            sb.Completed += async (obj, args) =>
            {
                await ShowAnimate();
                await Task.Delay(3000);
                sbCover.Begin();
            };
            sbCover.Completed += (obj, args) =>
            {
                this.Visibility = Visibility.Collapsed;
            };
        }

        private async Task ShowAnimate()
        {
            var spChildren = sp.Children;
            var len = spChildren.Count;

            for (int i = 0; i < len; i++)
            {
                await Task.Delay(200);

                var tb = (TextBlock)spChildren[i];
                var storyboard = new Storyboard();
                DoubleAnimation da = new DoubleAnimation
                {
                    From = 0,
                    To = 1,
                    Duration = new TimeSpan(0, 0, 0, 1),
                    FillBehavior = FillBehavior.HoldEnd
                };
                Storyboard.SetTarget(da, tb);
                Storyboard.SetTargetProperty(da, "Opacity");
                storyboard.Children.Add(da);
                storyboard.Begin();
            }
        }
    }
}
