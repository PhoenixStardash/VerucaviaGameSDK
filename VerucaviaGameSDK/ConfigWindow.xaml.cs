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
using PeanutButter.INI;
using VerucavaGameSDK;
using System.IO;
using System.CodeDom;
using Microsoft.Win32;
using System.Threading;

namespace VerucaviaGameSDK
{
    /// <summary>
    /// Interaction logic for ConfigWindow.xaml
    /// </summary>
    public partial class ConfigWindow
    {
        public string appconfig = AppDomain.CurrentDomain.BaseDirectory + @"config\";
        public ConfigWindow()
        {
            InitializeComponent();
            Console.WriteLine("Reading from config file: " + appconfig + "LauncherConfig.ini");
            Console.WriteLine("Populating Text Boxes with values from config file...");

        }

        public string projFile
        { get; set; }

        public string editorExeFile
        { get; set; }

        public string editorArguments
        { get; set; }

        private void BrowseButton2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BrowseButton3_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BrowseButton4_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog editorDialog = new OpenFileDialog();
            editorDialog.Title = "Open UE4Editor Executable";
            editorDialog.Filter = "Application|*.exe";
            if (editorDialog.ShowDialog() == true)
            {
                editorExeFile = Path.GetFullPath(editorDialog.FileName);
                Console.WriteLine("Value returned: " + editorDialog);

                EditorPath.Clear();
                EditorPath.AppendText(editorExeFile);
            }

        }
        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog projDialog = new OpenFileDialog();
            projDialog.Title = "Open UE4 Project File";
            projDialog.Filter = "Unreal Engine Project File|*.uproject";

            if (projDialog.ShowDialog() == true)
            {
                projFile = Path.GetFullPath(projDialog.FileName);
                Console.WriteLine("Value returned: " + projFile);
                ProjectPath.Clear();
                ProjectPath.AppendText(projFile);
            }

        }

        private void Ofd_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void GamePath_Initalized(object sender, EventArgs e)
        {
            var ini = new INIFile();
            ini.Load(appconfig + "LauncherConfig.ini");
            var gamePath = ini.GetValue("GameConfig", "GameDirectory").ToString();

            GamePath.AppendText(gamePath);
        }

        private void GameArgs1_Init(object sender, EventArgs e)
        {
            var ini = new INIFile();
            ini.Load(appconfig + "LauncherConfig.ini");
            var gameCmdline = ini.GetValue("GameConfig", "GameArguments").ToString();

            GameArgs1.AppendText(gameCmdline);
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (Directory.Exists(appconfig))
            {
                // Read text from writable text boxes
                editorArguments = ProjectPath.Text + ' ' + EditorArgs.Text;
                projFile = ProjectPath.Text;
                editorExeFile = EditorPath.Text;
                
                // Write to the config file
                Console.WriteLine("Writing to configuration file...");
                var MyIni = new MakeIniFile(appconfig + "LauncherConfig.ini");
                
                // Rewrite the Keys
                MyIni.DeleteKey("EditorExeFile", "ProjectConfiguration");
                MyIni.Write("EditorExeFile", editorExeFile, "ProjectConfiguration");

                MyIni.DeleteKey("CurrentProject", "ProjectConfiguration");
                MyIni.Write("CurrentProject", projFile, "ProjectConfiguration");
                
                MyIni.DeleteKey("EditorArguments", "ProjectConfiguration");
                Thread.Sleep(500);
                MyIni.Write("EditorArguments", editorArguments, "ProjectConfiguration");

            }
        }

        // Populate Text Boxes if neccessary.
        private void ProjectPath_Init(object sender, EventArgs e)
        {
            var ini = new INIFile();
            ini.Load(appconfig + "LauncherConfig.ini");

            if (ini.HasSetting("ProjectConfiguration", "CurrentProject"))
            {
                var currentProject = ini.GetValue("ProjectConfiguration", "CurrentProject").ToString();
                
                projFile = currentProject;
                
                ProjectPath.AppendText(currentProject);

                Console.WriteLine("Populated element: ProjectPath");
            }
            else
            {
                Console.WriteLine("WARNING: No key defined in configuration file.");
            }
        }

        private void EditorPath_Init(object sender, EventArgs e)
        {
            var ini = new INIFile();
            ini.Load(appconfig + "LauncherConfig.ini");

            // Check if a key exists in an INI file
            if (ini.HasSetting("ProjectConfiguration", "EditorExeFile"))
            {
                var editorExe = ini.GetValue("ProjectConfiguration", "EditorExeFile").ToString();

                editorExeFile = editorExe;

                EditorPath.AppendText(editorExe);
                Console.WriteLine("Populated element: EditorPath");
            }
            else
            {
                Console.WriteLine("WARNING: No key defined in configuration file.");
            }
        }

        private void EditorArgs_Init(object sender, EventArgs e)
        {
            var ini = new INIFile();
            ini.Load(appconfig + "LauncherConfig.ini");

            if (ini.HasSetting("ProjectConfiguration", "EditorArguments"))
            {
                var editorArgs = ini.GetValue("ProjectConfiguration", "EditorArguments").ToString();

                editorArguments = editorArgs;
                
                EditorArgs.AppendText(editorArgs);

                Console.WriteLine("Populated element: EditorArgs");
            }
            else
            {
                Console.WriteLine("WARNING: No key defined in configuration file.");
            }
        }
    }
}
