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
using ImProcessor.Helper;
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

            OriginalViewer.ImageSource = BitmapFrame.Create(_image.Mats![0].ToBitmapSource());

            this.S1.Value = 2;
        }

        //private Image _image = new Image(@"C:\Users\haeer\Pictures\1.jpg");
        //private Image _image = new Image(@"C:\Users\haeer\Pictures\hela.tif");
        private Image _image = new Image(@"C:\Users\haeer\Pictures\d48.tif");


        private void ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
        {
            Application.Current.Dispatcher.InvokeAsync(() =>
            {
                var img = _image.SetLut(LutHelper.Blue);

                PresentViewer.ImageSource = BitmapFrame.Create(img.Mats[0].ToBitmapSource());

            });
        }
    }
}
