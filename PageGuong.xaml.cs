using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp2
{
    public partial class PageGuong : Page
    {
        public PageGuong()
        {
            InitializeComponent();
            anh.Visibility = Visibility.Collapsed;
            this.DataContext = this;
            
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private bool isMenuVisible = false;

       
        /// Sự kiện nhấn nút điều khiển hiển thị/ẩn menu.
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (isMenuVisible)
            {
                // Nếu menu đang hiển thị, chạy animation ẩn menu.
                Storyboard hideStoryboard = (Storyboard)FindResource("HideMenuStoryboard");
                hideStoryboard.Begin();
            }
            else
            {
                // Nếu menu đang ẩn, chạy animation hiện menu.
                Storyboard showStoryboard = (Storyboard)FindResource("ShowMenuStoryboard");
                showStoryboard.Begin();
            }

            isMenuVisible = !isMenuVisible; // Đảo ngược trạng thái của menu.
        }
        private void PositionSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            UpdateImage(); 
        }


        private void ResetAllButtons()
        {
            // Đặt trạng thái mặc định cho GuongPhang
            GuongPhang.Content = new Image
            {
                Source = new BitmapImage(new Uri("Source\\txtguongphang3.png", UriKind.Relative))
            };

            // Đặt trạng thái mặc định cho GuongCauLoi
            GuongCauLoi.Content = new Image
            {
                Source = new BitmapImage(new Uri("Source\\txtguongcauloi3.png", UriKind.Relative))
            };

            GuongCauLom.Content = new Image
            {
                Source = new BitmapImage(new Uri("Source\\txtguongcaulom3.png", UriKind.Relative))
            };
        }

            private void GuongPhang_Click(object sender, RoutedEventArgs e)
        {
            GuongPhangImage.Visibility = Visibility.Visible;
            GuongCauLoiImage.Visibility = Visibility.Collapsed;
            GuongCauLomImage.Visibility = Visibility.Collapsed;
            UpdateImage();

            ResetAllButtons();
            GuongPhang.Content = new Image
            {
                Source = new BitmapImage(new Uri("Source\\guongphangudl.png", UriKind.Relative))
            };

        }


        private void GuongCauLoi_Click(object sender, RoutedEventArgs e)
        {
            GuongCauLoiImage.Visibility = Visibility.Visible;
            GuongPhangImage.Visibility = Visibility.Collapsed;
            GuongCauLomImage.Visibility = Visibility.Collapsed;
            UpdateImage();

            ResetAllButtons() ;
            GuongCauLoi.Content = new Image
            {
                Source = new BitmapImage(new Uri("Source\\guongcauloiudl.png", UriKind.Relative))
            };

        }

        private void GuongCauLom_Click(object sender, RoutedEventArgs e)
        {
            GuongCauLomImage.Visibility = Visibility.Visible;
            GuongPhangImage.Visibility = Visibility.Collapsed;
            GuongCauLoiImage.Visibility = Visibility.Collapsed;

            UpdateImage();
            ResetAllButtons() ;

            GuongCauLom.Content = new Image
            {
                Source = new BitmapImage(new Uri("Source\\guongcaulomudl.png", UriKind.Relative))
            };

        }
        private void UpdateImage()
        {
            double x = 0, y = 0;
            double guongx;
            double toadox = Canvas.GetLeft(vat);
            double toadoy = Canvas.GetTop(vat);
            double m = 0;
            if (GuongPhangImage != null && GuongPhangImage.Visibility == Visibility.Visible)
            {
                anhScale.ScaleX = 1;
                anhScale.ScaleY = 1;
                guongx = Canvas.GetLeft(GuongPhangImage);
                x = 2 * guongx - toadox;
                y = toadoy;
            }
            else if (GuongCauLoiImage != null && GuongCauLoiImage.Visibility == Visibility.Visible)
            {
                guongx = Canvas.GetLeft(GuongCauLoiImage);
                double tcu = -GuongCauLoiImage.Width / 4;
                double dv = guongx - toadox;
                double da = (tcu * dv) / (dv - tcu);
                x = guongx - da;
                m = -da / dv;
                y = toadoy + vat.Height - anh.Height*m;
                anhScale.ScaleX = m;
                anhScale.ScaleY = m;
            }
            else if (GuongCauLomImage != null && GuongCauLomImage.Visibility == Visibility.Visible)
            {
                guongx = Canvas.GetLeft(GuongCauLomImage);
                double tcu = GuongCauLomImage.Width / 4 ;
                double dv = guongx - toadox;
                double da = (tcu * dv) / (dv - tcu);
                x = guongx - da;
                m = -da / dv;
                y = toadoy + vat.Height - anh.Height * m;
                anhScale.ScaleX = m;
                anhScale.ScaleY = m;
            }
            Canvas.SetLeft(anh, x);
            Canvas.SetTop(anh, y);
            anh.Visibility = Visibility.Visible;
        }


    }
}
