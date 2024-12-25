using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Annotations;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;


namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for PageThauKinh.xaml
    /// </summary>
    public partial class PageThauKinh : Page
    {
        private bool isMenuVisible = false;
        public PageThauKinh()
        {
            InitializeComponent();
            DataContext = this;
            Toadox = 150;
            Tieucu = 150;
            anh.Visibility = Visibility.Collapsed;
            Canvas.SetLeft(vat, Toadox);
            Canvas.SetTop(vat, 176);
            Canvas.SetLeft(anh, -50);
            Canvas.SetTop(anh, -50);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (isMenuVisible)
            {
                // Nếu menu đang hiển thị, ẩn nó
                Storyboard hideStoryboard = (Storyboard)FindResource("HideMenuStoryboard");
                hideStoryboard.Begin();
            }
            else
            {
                // Nếu menu không hiển thị, hiển thị nó
                Storyboard showStoryboard = (Storyboard)FindResource("ShowMenuStoryboard");
                showStoryboard.Begin();
            }

            // Đảo ngược trạng thái
            isMenuVisible = !isMenuVisible;
        }

        private double _toadox;
        private double _tieucu;

        public double Toadox
        {
            get { return _toadox; }
            set
            {
                _toadox = value;
                OnPropertyChanged(nameof(Toadox));
            }
        }
        
        
        public double Tieucu
        {
            get { return _tieucu; }
            set
            {
                _tieucu = value;
                OnPropertyChanged(nameof(Tieucu));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        
        private void ThauKinhHoiTu_Click(object sender, RoutedEventArgs e)
        {
            tkht.Visibility = Visibility.Visible;
            tkpk.Visibility = Visibility.Collapsed;
            UpdateImage();

            TKHT.Content = new System.Windows.Controls.Image { Source = new BitmapImage(new Uri("Source/txttkhtudl.png", UriKind.Relative)) };
            TKPK.Content = new System.Windows.Controls.Image { Source = new BitmapImage(new Uri("Source/txttkpk.png", UriKind.Relative)) };
        }

        private void ThauKinhPhanKy_Click(object sender, RoutedEventArgs e)
        {
            tkht.Visibility = Visibility.Collapsed;
            tkpk.Visibility = Visibility.Visible;
            UpdateImage();
            TKPK.Content = new System.Windows.Controls.Image { Source = new BitmapImage(new Uri("Source/txttkpkudl.png", UriKind.Relative)) };
            TKHT.Content = new System.Windows.Controls.Image { Source = new BitmapImage(new Uri("Source/txttkht.png", UriKind.Relative)) };
        }
        private void Slider_ValueChanged1(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            UpdateImage(); // Gọi hàm cập nhật hình ảnh
        }
        private void Slider_ValueChanged2(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            UpdateImage(); // Gọi hàm cập nhật hình ảnh
        }

        private void UpdateImage()
        {
            if (tkht.Visibility == Visibility.Collapsed && tkpk.Visibility == Visibility.Collapsed)
            {
                anh.Visibility = Visibility.Collapsed;
                return;
            }
            double x = 0; // Giá trị mặc định
            double y = 0; // Giá trị mặc định
            double m = 0; // Không gây lỗi, nhưng cũng nên khởi tạo
            Toadox = Canvas.GetLeft(vat);
            double toadoy = Canvas.GetTop(vat);
            double thaukinhx = (tkht.Visibility == Visibility.Visible) ? Canvas.GetLeft(tkht) : Canvas.GetLeft(tkpk);
            double nTieucu = thaukinhx- Tcu.Value;
            nTieucu = (tkht.Visibility== Visibility.Visible) ? nTieucu : (-nTieucu);
            double dx = thaukinhx - Toadox;
            if (dx == nTieucu) return;
            double da = nTieucu * dx / (dx - nTieucu);
            m = -da / dx;
            x = thaukinhx + da;
            y = (tkht.Visibility == Visibility.Visible) ? (m < 0 ? (toadoy + Math.Abs(anh.Height * m)) : (toadoy - Math.Abs(anh.Height * (1 - m) / 2))) : (toadoy + Math.Abs(anh.Height * (1 - m) / 2));
            if (Math.Abs(m) > 5) m = 5; // Giới hạn scale
            anhScale.ScaleX = m;
            anhScale.ScaleY = m;  
            // Cập nhật vị trí
            Canvas.SetLeft(anh, x);
            Canvas.SetTop(anh, y);
            anh.Visibility = Visibility.Visible;
        }


    }
}
