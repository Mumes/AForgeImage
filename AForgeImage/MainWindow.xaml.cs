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
using Microsoft.Win32;
using System.Drawing;
using GonImageProcessor;
namespace AForgeImage
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png*|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                BitmapImage mapimg;
                Bitmap img;
                mapimg= new BitmapImage(new Uri(op.FileName));
                imgPhoto.Source = mapimg;
                img = new Bitmap(op.FileName);
                ImgProcessor gon = new ImgProcessor(img);
                gon.calcCross();
                textBoxX.Text = $"Cмещение X {gon.X.ToString()}";
                textBoxY.Text = $"Смещение Y {gon.Y.ToString()}";
            }
        }
    }
}
