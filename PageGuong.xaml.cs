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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for PageGuong.xaml
    /// </summary>
    public partial class PageGuong : Page
    {
        private bool isMenuVisible = false;
        public PageGuong()
        {
            InitializeComponent();
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
    }
}
