using System;
using System.Collections.Generic;
using System.Diagnostics;
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


namespace VerucavaGameSDK.Views
{
    /// <summary>
    /// Interaction logic for AppsView.xaml
    /// </summary>
    public partial class AppsView : UserControl
    {
        public AppsView()
        {
            InitializeComponent();
        }
        private async void nppButton_Click(object sender, RoutedEventArgs e)
        {
            await Task.Run(() =>
            {
                Process.Start("notepad++.exe");
            });

        }

        private async void vscodeButton_Click(object sender, RoutedEventArgs e)
        {
            await Task.Run(() =>
            {
                Process.Start("C:\\Users\\PhoenixTM\\AppData\\Local\\Programs\\Microsoft VS Code\\Code.exe");
            });
        }

        private async void vs2019Button_Click(object sender, RoutedEventArgs e)
        {
            await Task.Run(() =>
            {
                Process.Start("D:\\Program Files\\Microsoft Visual Studio\\2019\\Community\\Common7\\IDE\\devenv.exe");
            });
        }

        private async void gimpButton_Click(object sender, RoutedEventArgs e)
        {
            await Task.Run(() =>
            {
                Process.Start("C:\\Program Files\\GIMP 2\\bin\\gimp-2.8.exe");
            });

        }

        private async void pdnButton_Click(object sender, RoutedEventArgs e)
        {
            await Task.Run(() =>
            {
                Process.Start("C:\\Program Files\\paint.net\\PaintDotNet.exe");
            });
           
        }

        private async void sm4Button_Click(object sender, RoutedEventArgs e)
        {
            await Task.Run(() =>
            {
                Process.Start("C:\\Program Files\\ShaderMap 4\\bin\\ShaderMap.exe");
            });
        }

        private async void psButton_Click(object sender, RoutedEventArgs e)
        {
            await Task.Run(() =>
            {
                Process.Start("C:\\Program Files\\Adobe\\Adobe Photoshop CC 2018\\Photoshop.exe");
            });
        }

        private async void blender1Button_Click(object sender, RoutedEventArgs e)
        {
            await Task.Run(() =>
            {
                Process.Start("C:\\Program Files\\Blender Foundation\\Blender\\blender.exe");
            });
 
        }

        private async void blender2Button_Click(object sender, RoutedEventArgs e)
        {
            await Task.Run(() =>
            {
                Process.Start("D:\\Program Files\\Blender\\versions\\2.83\\blender.exe");
            });
            
        }

        private async void audacityButton_Click(object sender, RoutedEventArgs e)
        {
            await Task.Run(() =>
            {
                Process.Start("C:\\Program Files (x86)\\Audacity\\audacity.exe");
            });
        }
    }
}
