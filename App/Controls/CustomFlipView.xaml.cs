using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace App.Controls
{
    public sealed partial class CustomFlipView : UserControl
    {
        public List<string> ItemsSource
        {
            get { return fv.ItemsSource as List<string>; }
            set
            {
                fv.ItemsSource = value;
                var list = fv.ItemsSource as List<string>;
                if (list != null)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        var item = list[i];
                        var ellipse = new Ellipse()
                        {
                            Width = 6,
                            Height = 6,
                            Fill = i == 0 ? new SolidColorBrush(Colors.DarkGreen) : new SolidColorBrush(Colors.Gray),
                            HorizontalAlignment = HorizontalAlignment.Right,
                            Margin = new Thickness(3)
                        };
                        sp.Children.Add(ellipse);
                    }
                }
            }
        }

        public CustomFlipView()
        {
            this.InitializeComponent();
            fv.SelectionChanged += (sender, args) =>
            {
                Debug.Write("SelectionChanged" + fv.SelectedIndex);
                var index = fv.SelectedIndex;
                List<Ellipse> ellipses = new List<Ellipse>();
                Utils.TreeHelper.FindChildren<Ellipse>(ellipses, sp);
                for (int i = 0; i < ellipses.Count; i++)
                {
                    var item = ellipses[i];

                    item.Fill = index == i ? new SolidColorBrush(Colors.DarkGreen) : new SolidColorBrush(Colors.Gray);
                }
            };

        }
    }
}
