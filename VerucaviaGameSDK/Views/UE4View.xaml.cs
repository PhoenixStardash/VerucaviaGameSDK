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
using PeanutButter.INI;

namespace VerucavaGameSDK.Views
{
    /// <summary>
    /// Interaction logic for UE4View.xaml
    /// </summary>
    /// 
    public partial class UE4View : UserControl
    {
        public string appconfig = AppDomain.CurrentDomain.BaseDirectory + @"config\";

        public string game = @"D:\Data\Internal\ExtranStudios\Build\VerucaviaNewAge\WindowsNoEditor\VerucaviaGame.exe";
        public string gameArgs = "-log -crashreports";
        public string proj_EditorAssociation = "D:\\Program Files\\Epic Games\\UE_4.26\\Engine\\Binaries\\Win64\\UE4Editor.exe";
        public string proj_EditorArgs = "D:\\Data\\Internal\\ExtranStudios\\VerucaviaGame\\VerucaviaGame.uproject -log -crashreports";
        public string UE_PLUGIN_DIR = @"D:\Program Files\Epic Games\UE_4.26\Engine\Plugins";

        public UE4View()
        {
            InitializeComponent();
        }

        private async void ue425Button_Click(object sender, RoutedEventArgs e)
        {
            await Task.Run(() =>
            {
                Process.Start("D:\\Program Files\\Epic Games\\UE_4.25\\Engine\\Binaries\\Win64\\UE4Editor.exe", "-log");
            });

        }

        private async void ue426Button_Click(object sender, RoutedEventArgs e)
        {
            await Task.Run(() =>
            {
                Process.Start("D:\\Program Files\\Epic Games\\UE_4.26\\Engine\\Binaries\\Win64\\UE4Editor.exe", "-log");
            });

        }

        private async void configButton_Click(object sender, RoutedEventArgs e)
        {
            await Task.Run(() =>
            {
                Process.Start("C:\\Users\\PhoenixTM\\AppData\\Local\\Programs\\Microsoft VS Code\\Code.exe", "D:\\Data\\Internal\\ExtranStudios\\VerucaviaGame\\Config\\DefaultEngine.ini");
            });
        }

        private async void uprojectEditButton_Click(object sender, RoutedEventArgs e)
        {
            await Task.Run(() =>
            {
                Process.Start("C:\\Users\\PhoenixTM\\AppData\\Local\\Programs\\Microsoft VS Code\\Code.exe", "D:\\Data\\Internal\\ExtranStudios\\VerucaviaGame\\VerucaviaGame.uproject");
            });
        }

        private async void pluginsButton_Click(object sender, RoutedEventArgs e)
        {
            await Task.Run(() =>
            {
                Process.Start("explorer", UE_PLUGIN_DIR);
            });
        }

        private async void launchEditorButton_Click(object sender, RoutedEventArgs e)
        {
            await Task.Run(() =>
            {
                Process.Start(proj_EditorAssociation, proj_EditorArgs);
            });
        }

        private async void launchStandaloneButton_Click(object sender, RoutedEventArgs e)
        {
            await Task.Run(() =>
            {
                var ini = new INIFile();
                ini.Load(appconfig + "LauncherConfig.ini");
                var gamePath = ini.GetValue("GameConfig", "GameDirectory").ToString();
                var gameCmdline = ini.GetValue("GameConfig", "GameArguments").ToString();

                Process.Start(gamePath, gameCmdline);
            });
        }

        private async void restartButton_Click(object sender, RoutedEventArgs e)
        {
            await Task.Run(() =>
            {
                Process process = Process.GetProcessesByName("UE4Editor").FirstOrDefault();
                if (process != null)
                {
                    process.CloseMainWindow();
                }
                Process.Start(proj_EditorAssociation, proj_EditorArgs);
            });

        }

        private async void contentFolderButton_Click(object sender, RoutedEventArgs e)
        {
            await Task.Run(() =>
            {
                Process.Start("explorer", "D:\\Data\\Internal\\ExtranStudios\\VerucaviaGame\\Content");
            });
        }

        private async void screenshotsButton_Click(object sender, RoutedEventArgs e)
        {
            await Task.Run(() =>
            {
                Process.Start("explorer", "D:\\Data\\Internal\\ExtranStudios\\VerucaviaGame\\Saved\\Screenshots\\Windows");
            });
        }

        private async void quitButton_Click(object sender, RoutedEventArgs e)
        {
            await Task.Run(() =>
            {
                Process process = Process.GetProcessesByName("UE4Editor").FirstOrDefault();
                if (process != null)
                {
                    process.CloseMainWindow();
                }
            });
        }
    }
}
