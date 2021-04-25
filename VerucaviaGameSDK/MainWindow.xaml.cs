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
using VerucavaGameSDK;
using VerucavaGameSDK.ViewModels;
using VerucaviaGameSDK;

namespace VerucavaGameSDK
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
             InitializeComponent();
             DataContext = new MainViewModel();
        }

        private void MainAppWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.OemTilde)
            {
                ConsoleBox objShowConsole = new ConsoleBox();
                this.Visibility = Visibility.Visible;
                objShowConsole.Show();
                Console.WriteLine("[VerucaviaGameSDK.App.Drawing] Completed drawing of form 'ConsoleBox.xaml'");
            }
        }

        private void ButtonSettings_Click(object sender, RoutedEventArgs e)
        {
            ConfigWindow objShowConf = new ConfigWindow();
            this.Visibility = Visibility.Visible;
            objShowConf.Show();
        }
    }
}
