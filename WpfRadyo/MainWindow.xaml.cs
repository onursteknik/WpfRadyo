using AxAXVLC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace WpfRadyo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            vlc = new AxVLCPlugin2();
            WinFormHost.Child = vlc;
        }
        AxVLCPlugin2 vlc;
        private void radyoSec(string link, string radyoadi)
        {
            vlc.playlist.stop();
            vlc.playlist.items.clear();
            vlc.playlist.add(link);
            vlc.playlist.play();
        }
        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string link = btn.Name;
            if (link == "btnAlem") radyoSec("http://17703.live.streamtheworld.com/ALEM_FM128AAC_SC", "Alem FM");
            else if (link == "btnBest") radyoSec("rtmp://37.247.100.100:1935/best/bestfm.stream", "Best FM");
            else if (link == "btnJoyTurk") radyoSec("rtmp://kralfms.radyotvonline.com:80/dyg/kralfm64", "Kral FM");
            else if (link == "btnJoyAkustik") radyoSec("http://195.142.3.83/power/PowerTurk_mpeg_128_home/icecast.audio", "Powerturk FM");
            else if (link == "btnKral") radyoSec("http://17753.live.streamtheworld.com/JOY_TURK128AAC_SC", "JoyTurk");
            else if (link == "btnKralPop") radyoSec("rtmp://46.20.3.194:80/show/viva64/viva64", "RadyoViva");
            else if (link == "btnPower") radyoSec("rtmp://37.247.100.100:80/show/show64", "Show Radyo");
            else if (link == "btnViva") radyoSec("http://radyo.dogannet.tv/slowturk", "Slowturk");
            else if (link == "btnShow") radyoSec("http://17703.live.streamtheworld.com/JOYTURK_AKUSTIKAAC", "Joyturk Akustik");
            else radyoSec("rtmp://kralpopfms.radyotvonline.com:80/dyg/kralpop64", "Kral POP");
        }

        private void Ust_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton==MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void btnKapat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnKucult_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnDurdur_Click(object sender, RoutedEventArgs e)
        {
            vlc.playlist.pause();
        }
        
       
    }
}
