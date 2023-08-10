using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ImProcessor.Extensions;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using OpenCvSharp;
using OpenCvSharp.WpfExtensions;
using Image = ImProcessor.Models.Image;
using Window = System.Windows.Window;

namespace ImProcessor.Examples
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.S1.ValueChanged += ValueChanged;

            this.S1.Value = 1;

            OriginalViewer.ImageSource = BitmapFrame.Create(_image.Mats[0].ToBitmapSource());
            //OriginalViewer.ImageSource = BitmapFrame.Create(img.GetOriginal().ToBitmapSource());
        }

        private Image _image = new Image(@"C:\Users\haeer\Pictures\1.jpg");

        private void ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
        {
            Application.Current.Dispatcher.InvokeAsync(() =>
            {
                var img = _image.SetLut((ColormapTypes)S1.Value);

                if (img.Mats!.Length != 1) throw new Exception("error");

                PresentViewer.ImageSource = BitmapFrame.Create(img.Mats[0].ToBitmapSource());


                //PresentChartsView.Series = new ISeries[]
                //{
                //    new ColumnSeries<float>()
                //    {
                //        Values = data.ToList()
                //    }
                //};
            });
        }
    }
}
