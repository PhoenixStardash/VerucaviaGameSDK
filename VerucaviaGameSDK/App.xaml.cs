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
using System.Windows.Shapes;
using System.Diagnostics;
using Microsoft.Win32;
using System.Timers;
using System.IO;
using System.Threading;
using PeanutButter.INI;
using System.Media;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace VerucavaGameSDK
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        public string gameArgs = "";
        public string gameDir = "";
        public string staging = "";
        public string appconfig = AppDomain.CurrentDomain.BaseDirectory + @"config\";
        public string approot = AppDomain.CurrentDomain.BaseDirectory;

        public void Application_Startup(object sender, StartupEventArgs e)
        {
            string[] args = Environment.GetCommandLineArgs();

            if (args.Contains("--help"))
            {
                Console.WriteLine("Syntax: VerucaviaNewAgeSDK.exe [noSwitchForAppStart] [--help] [--about] [--verifyconfig] [--setup] [--launch] [--build]");
                Console.WriteLine("");
                Console.WriteLine("--------------------------------------------------------------------------------");
                Console.WriteLine(" SWITCH          DESCRIPTION                                                    ");
                Console.WriteLine("--------------------------------------------------------------------------------");
                Console.WriteLine("--help           Prints the help message");
                Console.WriteLine("--about          Shows the application's version and build config");
                Console.WriteLine("--verifyconfig   For debugging perposes, to wonder why the app crashed.");
                Console.WriteLine("--setup          Use this to set the game path and optional launch arguments.");
                Console.WriteLine("--launch         Launch Verucavia: New Age");
                Console.WriteLine("--build          Builds Verucavia: New Age by using Unreal Automation Tool");
                Console.WriteLine("--------------------------------------------------------------------------------");
                this.Shutdown();
            }
            if (args.Contains("--show-root"))
            {
                Console.WriteLine(appconfig);
                this.Shutdown();
            }
            if (args.Contains("--about"))
            {
                Console.WriteLine("Verucavia: New Age Internal Developer SDK (Version 2.3)");
                Console.WriteLine("Programmed by: Royal-PhoenixTM");
                this.Shutdown();
            }
            if (args.Contains("--build"))
            {
                // Begin Function: VerifyDirectory
                Console.WriteLine("[Build] Verifying if output directory exists...");

                if (Directory.Exists(staging))
                {
                    Console.WriteLine("[Build] SUCCESS: Staging Directory found at: D:\\Data\\Internal\\ExtranStudios\\Build\\VerucaviaNewAge");
                }
                else
                {
                    Console.WriteLine("[Build] ERROR: Staging Directory D:\\Data\\Internal\\ExtranStudios\\Build\\VerucaviaNewAge doesn't exist.");
                }
                RunAutomationTool(); // Function is async, prevent the main application from hanging
            }
            if (args.Contains("--verifyconfig"))
            {
                var ini = new INIFile();
                ini.Load(appconfig + "LauncherConfig.ini");
                var output_opt1 = ini.GetValue("GameConfig", "GameDirectory").ToString();
                var output_opt2 = ini.GetValue("GameConfig", "GameArguments").ToString();

                Console.WriteLine("User specified game directory:");
                Console.WriteLine(output_opt1);
                Console.WriteLine("");
                Console.WriteLine("User specified game launch arguments:");
                Console.WriteLine(output_opt2);


                this.Shutdown();
            }
            if (args.Contains("--setup"))
            {
                if (Directory.Exists(appconfig))
                {
                    var MyIni = new MakeIniFile(appconfig + "LauncherConfig.ini");

                    Console.WriteLine("Specify current path for game: ");
                    string gameDir = Console.ReadLine();
                    MyIni.Write("GameDirectory", gameDir, "GameConfig");
                    Console.WriteLine("");

                    Console.WriteLine("Specify launch arguments (optional): ");
                    string gameArgs = Console.ReadLine();
                    MyIni.Write("GameArguments", gameArgs, "GameConfig");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Folder does not exist. Creating...");

                    Directory.CreateDirectory(@"config");

                    var MyIni = new MakeIniFile(appconfig + "LauncherConfig.ini");

                    Console.WriteLine("Specify current path for game: ");
                    string gameDir = Console.ReadLine();
                    MyIni.Write("GameDirectory", gameDir, "GameConfig");
                    Console.WriteLine("");

                    Console.WriteLine("Specify launch arguments (optional): ");
                    string gameArgs = Console.ReadLine();
                    MyIni.Write("GameArguments", gameArgs, "GameConfig");
                    Console.WriteLine();
                }

                this.Shutdown();
            }
            if (args.Contains("--launch"))
            {
                var ini = new INIFile();
                ini.Load(appconfig + "LauncherConfig.ini");
                var gamePath = ini.GetValue("GameConfig", "GameDirectory").ToString();
                var gameCmdline = ini.GetValue("GameConfig", "GameArguments").ToString();

                Process.Start(gamePath, gameCmdline);

                this.Shutdown();
            }
        }
        public async void RunAutomationTool()
        {
            await Dispatcher.BeginInvoke(new Action(() =>
            {
                Console.WriteLine("[Build] Started build for 'VerucaviaGame'");
            }));
            await Task.Run(() =>
            {
                System.Diagnostics.Process.Start("D:\\Program Files\\Epic Games\\UE_4.26\\Engine\\Build\\BatchFiles\\RunUAT.bat", "-ScriptsForProject=D:/Data/Internal/ExtranStudios/VerucaviaGame/VerucaviaGame.uproject BuildCookRun -nocompileeditor -installed -nop4 -project=D:/Data/Internal/ExtranStudios/VerucaviaGame/VerucaviaGame.uproject -cook -stage -archive -archivedirectory=D:/Data/Internal/ExtranStudios/Build/VerucaviaNewAge -package -ue4exe=%UE4CMD% -ddc=InstalledDerivedDataBackendGraph -pak -prereqs -targetplatform=Win64 -build -target=VerucaviaGame -clientconfig=Development -utf8output").WaitForExit();
            });
            await Dispatcher.BeginInvoke(new Action(() =>
            {
                Console.WriteLine("[Build] Build for 'VerucaviaGame' has finished");
                MessageBox.Show("Build Status", "The current build has completed.", MessageBoxButton.OK, MessageBoxImage.Information);
                
            }));

        }
    }
}
