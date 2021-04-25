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
using System.Diagnostics;

namespace VerucavaGameSDK.Views
{
    /// <summary>
    /// Interaction logic for AboutView.xaml
    /// </summary>
    public partial class AboutView : UserControl
    {
        public AboutView()
        {
            InitializeComponent();
        }

        private void buttonLinkGithub1_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("C:\\Program Files (x86)\\Google\\Chrome\\Application\\chrome.exe", "https://github.com/sourcechord/FluentWPF");
        }

        private void nugetButton_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("C:\\Program Files (x86)\\Google\\Chrome\\Application\\chrome.exe", "https://www.nuget.org/packages/FluentWPF");
        }
    }
}
