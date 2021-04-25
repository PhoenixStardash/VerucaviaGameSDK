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


namespace VerucavaGameSDK
{
    /// <summary>
    /// Interaction logic for ConsoleBox.xaml
    /// </summary>
    public partial class ConsoleBox
    {
        public static string staging = @"D:\Data\Internal\ExtranStudios\Build\VerucaviaNewAge";
        public static string ue4cmd = @"D:\Program Files\Epic Games\UE_4.26\Engine\Binaries\Win64\UE4Editor-Cmd.exe";
        public static string buildtool = "AutomationTool";
        
        public ConsoleBox()
        {
            InitializeComponent();
            conprint("[CONSOLE] Console Initalized, for commands type 'sdk_help'");
        }
       

        // Intergrate a sound player with the console.
        private void playSound(string path)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer();
            player.SoundLocation = path;
            player.Load();
            player.Play();
        }
        private void StopSound()
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer();
            player.Stop();
        }
        private void consoleInput_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        // Register the event handler to allow for pressing enter and the command sending.
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.KeyDown += new KeyEventHandler(consoleInput_KeyDown);
        }

        // Allow for easily printing to console.
        private void conprint(string line)
        {
            consoleHistory.AppendText("\n" + line.ToString());
        }
        public async void RunAutomationTool()
        {
            await Dispatcher.BeginInvoke(new Action(() =>
            {
                conprint("[Build] Started build for 'VerucaviaGame'");
            }));
            await Task.Run(() =>
            {
                System.Diagnostics.Process.Start("D:\\Data\\Software\\UE4-VerucaviaGameEditor\\Engine\\Build\\BatchFiles\\RunUAT.bat", "-ScriptsForProject=D:/Data/Internal/ExtranStudios/VerucaviaGame/VerucaviaGame.uproject BuildCookRun -nocompileeditor -installed -nop4 -project=D:/Data/Internal/ExtranStudios/VerucaviaGame/VerucaviaGame.uproject -cook -stage -archive -archivedirectory=D:/Data/Internal/ExtranStudios/Build/VerucaviaNewAge -package -ue4exe=%UE4CMD% -ddc=InstalledDerivedDataBackendGraph -pak -prereqs -targetplatform=Win64 -build -target=VerucaviaGame -clientconfig=Development -utf8output").WaitForExit();
            });
            await Dispatcher.BeginInvoke(new Action(() =>
            {
                conprint("[Build] Build for 'VerucaviaGame' has finished");
            }));

        }

        private void consoleRun_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (consoleInput.Text == "sdk_help")
                {
                    conprint("CMD: " + consoleInput.Text);
                    conprint("======= Available Commands =======");
                    conprint("");
                    conprint("sdk_help - Prints this help message");
                    conprint("sdk_version - Prints version information to the console");
                    conprint("app_exit - Closes the application");
                    conprint("list_apps - Lists available apps to start");
                    conprint("StartApp('<appname>') - Starts requested app from list");
                    conprint("launch_editor - Starts the Unreal Engine 4 Editor.");
                    conprint("launch_game - Starts Verucavia: New Age");
                    conprint("call Editor.CloseMainWindow() - Asks Unreal Engine to Close");
                    conprint("con_clear - Clears the console");
                    conprint("snd_play - Opens a file dialog to select a file, SOUND FILES ONLY!");
                    conprint("game_build_all - Builds the game from scratch");
                    conprint("game_start - Starts the game. Available parameters: -map <mapname>, will default to sp_mainmenu if none is specified.");
                    consoleInput.Text = "";
                }
                // Console commands
                if (consoleInput.Text == "game_build_all")
                {
                    conprint("");
                    conprint("CMD: " + consoleInput.Text);
                    consoleInput.Text = "";

                    // Begin Function: VerifyDirectory
                    conprint("[Build] Verifying if output directory exists...");

                    if (Directory.Exists(staging))
                    {
                        conprint("[Build] SUCCESS: Staging Directory found at: D:\\Data\\Internal\\ExtranStudios\\Build\\VerucaviaNewAge");
                    }
                    else
                    {
                        conprint("[Build] ERROR: Staging Directory D:\\Data\\Internal\\ExtranStudios\\Build\\VerucaviaNewAge doesn't exist.");
                    }



                    RunAutomationTool(); // Function is async, prevent the main application from hanging

                }
                if (consoleInput.Text == "game_start")
                {
                    Process.Start("D:\\Data\\Internal\\ExtranStudios\\Build\\VerucaviaNewAge\\WindowsNoEditor\\VerucaviaGame.exe", "-log -crashreports");
                    conprint("Starting game...No map specified, defaulting to sp_mainmenu");
                    consoleInput.Text = "";
                }
                if (consoleInput.Text == "game_start -map Devtest_Gameplay")
                {
                    conprint("CMD: " + consoleInput.Text);
                    Process.Start("D:\\Data\\Internal\\ExtranStudios\\Build\\VerucaviaNewAge\\WindowsNoEditor\\VerucaviaGame.exe", "/Game/Levels/Development/Prototyping/Devtest_Gameplay -log -crashreports");
                    conprint("Starting game on map /Game/Levels/Development/Prototyping/Devtest_Gameplay");
                    consoleInput.Text = "";
                }
                if (consoleInput.Text == "game_start -map Trainyard")
                {
                    conprint("CMD: " + consoleInput.Text);
                    Process.Start("D:\\Data\\Internal\\ExtranStudios\\Build\\VerucaviaNewAge\\WindowsNoEditor\\VerucaviaGame.exe", "/Game/Trainyard/Maps/Trainyard -log -crashreports");
                    conprint("Starting game on map /Game/Trainyard/Maps/Trainyard");
                    consoleInput.Text = "";
                }
                if (consoleInput.Text == "game_start -map SpringLandscape")
                {
                    conprint("CMD: " + consoleInput.Text);
                    Process.Start("D:\\Data\\Internal\\ExtranStudios\\Build\\VerucaviaNewAge\\WindowsNoEditor\\VerucaviaGame.exe", "/Game/SpringLandscape/Maps/Overview/Overview -log -crashreports");
                    conprint("Starting game on map /Game/SpringLandscape/Maps/Overview/Overview");
                    consoleInput.Text = "";
                }
                if (consoleInput.Text == "sdk_version")
                {
                    conprint("CMD: " + consoleInput.Text);
                    conprint("Verucavia: New Age Internal Developer SDK (Version 2.3)");
                    consoleInput.Text = "";
                }
                if (consoleInput.Text == "app_exit")
                {
                    conprint("CMD: " + consoleInput.Text);
                    conprint("[System] Exit Request Recieved, shutting down components...");
                    consoleInput.Text = "";
                    Environment.Exit(0);
                }
                if (consoleInput.Text == "StartApp('npp')")
                {
                    conprint("CMD: " + consoleInput.Text);
                    conprint("[Launcher] Starting application: Notepad++, please wait.");
                    Process.Start("notepad++.exe");
                    consoleInput.Text = "";
                }
                if (consoleInput.Text == "StartApp('vscode')")
                {
                    conprint("CMD: " + consoleInput.Text);
                    conprint("[Launcher] Starting application: Visual Studio Code, please wait.");
                    Process.Start("C:\\Users\\PhoenixTM\\AppData\\Local\\Programs\\Microsoft VS Code\\Code.exe");
                    consoleInput.Text = "";
                }
                if (consoleInput.Text == "StartApp('vs2019')")
                {
                    conprint("CMD: " + consoleInput.Text);
                    conprint("[Launcher] Starting application: Visual Studio 2019, please wait.");
                    Process.Start("D:\\Program Files\\Microsoft Visual Studio\\2019\\Community\\Common7\\IDE\\devenv.exe");
                    consoleInput.Text = "";
                }
                if (consoleInput.Text == "StartApp('gimp2')")
                {
                    conprint("CMD: " + consoleInput.Text);
                    conprint("[Launcher] Starting application: GIMP 2, please wait.");
                    Process.Start("C:\\Program Files\\GIMP 2\\bin\\gimp-2.8.exe");
                    consoleInput.Text = "";
                }
                if (consoleInput.Text == "StartApp('pdn')")
                {
                    conprint("CMD: " + consoleInput.Text);
                    conprint("[Launcher] Starting application: Paint.NET, please wait.");
                    Process.Start("C:\\Program Files\\paint.net\\PaintDotNet.exe");
                    consoleInput.Text = "";
                }
                if (consoleInput.Text == "StartApp('photoshop')")
                {
                    conprint("CMD: " + consoleInput.Text);
                    conprint("[Launcher] Starting application: Adobe Photoshop CC 2018, please wait.");
                    Process.Start("C:\\Program Files\\Adobe\\Adobe Photoshop CC 2018\\Photoshop.exe");
                    consoleInput.Text = "";
                }
                if (consoleInput.Text == "StartApp('sm4')")
                {
                    conprint("CMD: " + consoleInput.Text);
                    conprint("[Launcher] Starting application: ShaderMap 4, please wait.");
                    Process.Start("C:\\Program Files\\ShaderMap 4\\bin\\ShaderMap.exe");
                    consoleInput.Text = "";
                }
                if (consoleInput.Text == "StartApp('blender279')")
                {
                    conprint("CMD: " + consoleInput.Text);
                    conprint("[Launcher] Starting application: Blender 2.79, please wait.");
                    Process.Start("C:\\Program Files\\Blender Foundation\\Blender\\blender.exe");
                    consoleInput.Text = "";
                }
                if (consoleInput.Text == "StartApp('blender283')")
                {
                    conprint("CMD: " + consoleInput.Text);
                    conprint("[Launcher] Starting application: Blender 2.83, please wait.");
                    Process.Start("D:\\Program Files\\Blender\\versions\\2.83\\blender.exe");
                    consoleInput.Text = "";
                }
                if (consoleInput.Text == "launch_editor")
                {
                    conprint("CMD: " + consoleInput.Text);
                    conprint("[Launcher] Starting Unreal Engine 4, Params (code-defined): D:\\Data\\Internal\\ExtranStudios\\VerucaviaGame\\VerucaviaGame.uproject -log -name [DEV] NightmarePhoenix");
                    Process.Start("D:\\Program Files\\Epic Games\\UE_4.25\\Engine\\Binaries\\Win64\\UE4Editor.exe", "D:\\Data\\Internal\\ExtranStudios\\VerucaviaGame\\VerucaviaGame.uproject -log -name [DEV] NightmarePhoenix");
                    consoleInput.Text = "";
                }
                if (consoleInput.Text == "launch_game")
                {
                    conprint("CMD: " + consoleInput.Text);
                    conprint("[Launcher] Starting Verucavia: New Age, Params (code-defined): D:\\Data\\Internal\\ExtranStudios\\VerucaviaGame\\VerucaviaGame.uproject -listen -game -log -name [DEV] NightmarePhoenix");
                    Process.Start("D:\\Program Files\\Epic Games\\UE_4.25\\Engine\\Binaries\\Win64\\UE4Editor.exe", "D:\\Data\\Internal\\ExtranStudios\\VerucaviaGame\\VerucaviaGame.uproject -listen -game -log -name [DEV] NightmarePhoenix");
                    consoleInput.Text = "";
                }
                if (consoleInput.Text == "call Editor.CloseMainWindow()")
                {
                    {
                        conprint("CMD: " + consoleInput.Text);
                        Process process = Process.GetProcessesByName("UE4Editor").FirstOrDefault();
                        if (process != null)
                        {
                            process.CloseMainWindow();
                        }
                        conprint("[Debug] Sent CloseMainWindow() command to process 'UE4Editor.exe'");
                        consoleInput.Text = "";
                    }
                }
                if (consoleInput.Text == "list_apps")
                {
                    conprint("CMD: " + consoleInput.Text);
                    conprint("======== [Available Apps] ========");
                    conprint("");
                    conprint("Notepad++ [Syntax: StartApp ('npp')]");
                    conprint("Visual Studio Code [Syntax: StartApp ('vscode')]");
                    conprint("Visual Studio 2019 [Syntax: StartApp('vs2019')]");
                    conprint("GIMP 2 [Syntax: StartApp ('gimp2')");
                    conprint("Paint.NET [Syntax: StartApp('pdn')");
                    conprint("Adobe Photoshop CC 2018 [Syntax: StartApp('photoshop')");
                    conprint("ShaderMap 4 [Syntax: StartApp('sm4')");
                    conprint("Blender 2.79 [Syntax: StartApp('blender279')");
                    conprint("Blender 2.83 [Syntax: StartApp('blender283')");
                    conprint("");
                    consoleInput.Text = "";
                }
                if (consoleInput.Text == "con_clear")
                {
                    consoleHistory.Document.Blocks.Clear();
                }
                if (consoleInput.Text == "snd_play")
                {
                    conprint("CMD: " + consoleInput.Text);
                    conprint("[Music Player] Select a sound file. Like UE4, the only supported format is WAV.");
                    OpenFileDialog dialog = new OpenFileDialog();
                    dialog.Filter = "";
                    if (dialog.ShowDialog() == true)
                    {
                        string path = dialog.FileName;
                        playSound(path);
                        conprint("[Music Player] Playing sound file: " + path);
                    }
                    consoleInput.Text = "";
                }
                if (consoleInput.Text == "snd_stop")
                {
                    conprint("CMD: " + consoleInput.Text);
                    StopSound();
                    conprint("[Music Player] Audio playback haulted by user.");
                    consoleInput.Text = "";
                }
            }
            catch
            {

            }

        }

        // Same functionality for the submit command button. Don't bother me.
        private void consoleInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                try
                {
                    if (consoleInput.Text == "sdk_help")
                    {
                        conprint("CMD: " + consoleInput.Text);
                        conprint("======= Available Commands =======");
                        conprint("");
                        conprint("sdk_help - Prints this help message");
                        conprint("sdk_version - Prints version information to the console");
                        conprint("app_exit - Closes the application");
                        conprint("list_apps - Lists available apps to start");
                        conprint("StartApp('<appname>') - Starts requested app from list");
                        conprint("launch_editor - Starts the Unreal Engine 4 Editor.");
                        conprint("launch_game - Starts Verucavia: New Age");
                        conprint("call Editor.CloseMainWindow() - Asks Unreal Engine to Close");
                        conprint("con_clear - Clears the console");
                        conprint("con_close - Closes the console");
                        conprint("snd_play - Opens a file dialog to select a file, SOUND FILES ONLY!");
                        conprint("snd_stop - Stops the current audio file playback");
                        conprint("game_build_all - Builds the game from scratch");
                        conprint("game_start - Starts the game. Available parameters: -map <mapname>, will default to sp_mainmenu if none is specified.");
                        consoleInput.Text = "";
                    }
                    // Console commands
                    if (consoleInput.Text == "game_build_all")
                    {
                        conprint("");
                        conprint("CMD: " + consoleInput.Text);
                        consoleInput.Text = "";

                        // Begin Function: VerifyDirectory
                        conprint("[Build] Verifying if output directory exists...");

                        if (Directory.Exists(staging))
                        {
                            conprint("[Build] SUCCESS: Directory found at: D:\\Data\\Internal\\ExtranStudios\\Build\\VerucaviaNewAge");
                        }
                        else
                        {
                            conprint("[Build] ERROR: Directory D:\\Data\\Internal\\ExtranStudios\\Build\\VerucaviaNewAge doesn't exist.");
                        }


                        RunAutomationTool(); // Function is async, prevent the main application from hanging

                    }
                    if (consoleInput.Text == "game_start")
                    {
                        conprint("CMD: " + consoleInput.Text);
                        Process.Start("D:\\Data\\Internal\\ExtranStudios\\Build\\VerucaviaNewAge\\WindowsNoEditor\\VerucaviaGame.exe", "-log -crashreports");
                        conprint("Starting game...No map specified, defaulting to sp_mainmenu");
                        consoleInput.Text = "";
                    }
                    if (consoleInput.Text == "game_start -map Devtest_Gameplay")
                    {
                        conprint("CMD: " + consoleInput.Text);
                        Process.Start("D:\\Data\\Internal\\ExtranStudios\\Build\\VerucaviaNewAge\\WindowsNoEditor\\VerucaviaGame.exe", "/Game/Levels/Development/Prototyping/Devtest_Gameplay -log -crashreports");
                        conprint("Starting game on map /Game/Levels/Development/Prototyping/Devtest_Gameplay");
                        consoleInput.Text = "";
                    }
                    if (consoleInput.Text == "game_start -map Trainyard")
                    {
                        conprint("CMD: " + consoleInput.Text);
                        Process.Start("D:\\Data\\Internal\\ExtranStudios\\Build\\VerucaviaNewAge\\WindowsNoEditor\\VerucaviaGame.exe", "/Game/Trainyard/Maps/Trainyard -log -crashreports");
                        conprint("Starting game on map /Game/Trainyard/Maps/Trainyard");
                        consoleInput.Text = "";
                    }
                    if (consoleInput.Text == "game_start -map SpringLandscape")
                    {
                        conprint("CMD: " + consoleInput.Text);
                        Process.Start("D:\\Data\\Internal\\ExtranStudios\\Build\\VerucaviaNewAge\\WindowsNoEditor\\VerucaviaGame.exe", "/Game/SpringLandscape/Maps/Overview/Overview -log -crashreports");
                        conprint("Starting game on map /Game/SpringLandscape/Maps/Overview/Overview");
                        consoleInput.Text = "";
                    }

                    if (consoleInput.Text == "sdk_version")
                    {
                        conprint("CMD: " + consoleInput.Text);
                        conprint("Verucavia: New Age Internal Developer SDK (Version 2.3)");
                        consoleInput.Text = "";
                    }
                    if (consoleInput.Text == "app_exit")
                    {
                        conprint("CMD: " + consoleInput.Text);
                        conprint("[System] Exit Request Recieved, shutting down components...");
                        consoleInput.Text = "";
                        Environment.Exit(0);
                    }
                    if (consoleInput.Text == "StartApp('npp')")
                    {
                        conprint("CMD: " + consoleInput.Text);
                        conprint("[Launcher] Starting application: Notepad++, please wait.");
                        Process.Start("notepad++.exe");
                        consoleInput.Text = "";
                    }
                    if (consoleInput.Text == "StartApp('vscode')")
                    {
                        conprint("CMD: " + consoleInput.Text);
                        conprint("[Launcher] Starting application: Visual Studio Code, please wait.");
                        Process.Start("C:\\Users\\PhoenixTM\\AppData\\Local\\Programs\\Microsoft VS Code\\Code.exe");
                        consoleInput.Text = "";
                    }
                    if (consoleInput.Text == "StartApp('vs2019')")
                    {
                        conprint("CMD: " + consoleInput.Text);
                        conprint("[Launcher] Starting application: Visual Studio 2019, please wait.");
                        Process.Start("D:\\Program Files\\Microsoft Visual Studio\\2019\\Community\\Common7\\IDE\\devenv.exe");
                        consoleInput.Text = "";
                    }
                    if (consoleInput.Text == "StartApp('gimp2')")
                    {
                        conprint("CMD: " + consoleInput.Text);
                        conprint("[Launcher] Starting application: GIMP 2, please wait.");
                        Process.Start("C:\\Program Files\\GIMP 2\\bin\\gimp-2.8.exe");
                        consoleInput.Text = "";
                    }
                    if (consoleInput.Text == "StartApp('pdn')")
                    {
                        conprint("CMD: " + consoleInput.Text);
                        conprint("[Launcher] Starting application: Paint.NET, please wait.");
                        Process.Start("C:\\Program Files\\paint.net\\PaintDotNet.exe");
                        consoleInput.Text = "";
                    }
                    if (consoleInput.Text == "StartApp('photoshop')")
                    {
                        conprint("CMD: " + consoleInput.Text);
                        conprint("[Launcher] Starting application: Adobe Photoshop CC 2018, please wait.");
                        Process.Start("C:\\Program Files\\Adobe\\Adobe Photoshop CC 2018\\Photoshop.exe");
                        consoleInput.Text = "";
                    }
                    if (consoleInput.Text == "StartApp('sm4')")
                    {
                        conprint("CMD: " + consoleInput.Text);
                        conprint("[Launcher] Starting application: ShaderMap 4, please wait.");
                        Process.Start("C:\\Program Files\\ShaderMap 4\\bin\\ShaderMap.exe");
                        consoleInput.Text = "";
                    }
                    if (consoleInput.Text == "StartApp('blender279')")
                    {
                        conprint("CMD: " + consoleInput.Text);
                        conprint("[Launcher] Starting application: Blender 2.79, please wait.");
                        Process.Start("C:\\Program Files\\Blender Foundation\\Blender\\blender.exe");
                        consoleInput.Text = "";
                    }
                    if (consoleInput.Text == "StartApp('blender283')")
                    {
                        conprint("CMD: " + consoleInput.Text);
                        conprint("[Launcher] Starting application: Blender 2.83, please wait.");
                        Process.Start("D:\\Program Files\\Blender\\versions\\2.83\\blender.exe");
                        consoleInput.Text = "";
                    }
                    if (consoleInput.Text == "launch_editor")
                    {
                        conprint("CMD: " + consoleInput.Text);
                        conprint("[Launcher] Starting Unreal Engine 4, Params (code-defined): D:\\Data\\Internal\\ExtranStudios\\VerucaviaGame\\VerucaviaGame.uproject -log -name [DEV] NightmarePhoenix");
                        Process.Start("D:\\Program Files\\Epic Games\\UE_4.25\\Engine\\Binaries\\Win64\\UE4Editor.exe", "D:\\Data\\Internal\\ExtranStudios\\VerucaviaGame\\VerucaviaGame.uproject -log -name [DEV] NightmarePhoenix");
                        consoleInput.Text = "";
                    }
                    if (consoleInput.Text == "launch_game")
                    {
                        conprint("CMD: " + consoleInput.Text);
                        conprint("[Launcher] Starting Verucavia: New Age, Params (code-defined): D:\\Data\\Internal\\ExtranStudios\\VerucaviaGame\\VerucaviaGame.uproject -listen -game -log -name [DEV] NightmarePhoenix");
                        Process.Start("D:\\Program Files\\Epic Games\\UE_4.25\\Engine\\Binaries\\Win64\\UE4Editor.exe", "D:\\Data\\Internal\\ExtranStudios\\VerucaviaGame\\VerucaviaGame.uproject -listen -game -log -name [DEV] NightmarePhoenix");
                        consoleInput.Text = "";
                    }
                    if (consoleInput.Text == "call Editor.CloseMainWindow()")
                    {
                        {
                            conprint("CMD: " + consoleInput.Text);
                            Process process = Process.GetProcessesByName("UE4Editor").FirstOrDefault();
                            if (process != null)
                            {
                                process.CloseMainWindow();
                            }
                            conprint("[Debug] Sent CloseMainWindow() command to process 'UE4Editor.exe'");
                            consoleInput.Text = "";
                        }
                    }
                    if (consoleInput.Text == "con_clear")
                    {
                        consoleInput.Text = "";
                        consoleHistory.Document.Blocks.Clear();
                    }
                    if (consoleInput.Text == "con_close")
                    {
                        consoleInput.Text = "";
                        this.Close();
                    }
                    if (consoleInput.Text == "list_apps")
                    {
                        conprint("CMD: " + consoleInput.Text);
                        conprint("======== [Available Apps] ========");
                        conprint("");
                        conprint("Notepad++ [Syntax: StartApp ('npp')]");
                        conprint("Visual Studio Code [Syntax: StartApp ('vscode')]");
                        conprint("Visual Studio 2019 [Syntax: StartApp('vs2019')]");
                        conprint("GIMP 2 [Syntax: StartApp ('gimp2')");
                        conprint("Paint.NET [Syntax: StartApp('pdn')");
                        conprint("Adobe Photoshop CC 2018 [Syntax: StartApp('photoshop')");
                        conprint("ShaderMap 4 [Syntax: StartApp('sm4')");
                        conprint("Blender 2.79 [Syntax: StartApp('blender279')");
                        conprint("Blender 2.83 [Syntax: StartApp('blender283')");
                        conprint("");
                        consoleInput.Text = "";
                    }
                    if (consoleInput.Text == "snd_play")
                    {
                        conprint("CMD: " + consoleInput.Text);
                        conprint("[Music Player] Select a sound file. Like UE4, the only supported format is WAV.");
                        OpenFileDialog dialog = new OpenFileDialog();
                        dialog.Filter = "";
                        if (dialog.ShowDialog() == true)
                        {
                            string path = dialog.FileName;
                            playSound(path);
                            conprint("[Music Player] Playing sound file: " + path);
                        }
                        consoleInput.Text = "";
                    }
                if (consoleInput.Text == "snd_stop")
                {
                    conprint("CMD: " + consoleInput.Text);
                    StopSound();
                    conprint("[Music Player] Audio playback haulted by user.");
                    consoleInput.Text = "";
                }
                }
                catch
                {

                }
            }
        }
    }
}

