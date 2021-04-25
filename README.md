# Verucavia: New Age Official Game SDK
Welcome to the repository for my SDK!

If you're too lazy to do any thing below, Compiled binaries can be found [here](http://verucaviagame.ddns.net:90/files/apps/release/VerucaviaGameSDK-2.2_release.7z)

# Getting Started
### Pre-Requisies
- [.NET 4.8 Targetting Pack](https://dotnet.microsoft.com/download/dotnet-framework/net48)
- [.NET Framework 4.8](https://dotnet.microsoft.com/download/dotnet-framework/net48)
- [Visual Studio 2019](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=Community&rel=16)

### Dependencies (Included)
- [FluentWPF](https://www.nuget.org/packages/FluentWPF/)
- [PeanutButter.INI](https://www.nuget.org/packages/PeanutButter.INI/)

### Operating System
- Windows 10 Version 1903 or Higher
- Support for DX10 or higher

# Features
### Current
- Configurable via an INI file
- Command-line support
- A sleek, modern look, mimmicing Fluent Design apps seen in Windows 10

### Planned
- Add support for Unity3D
- Add additional command-line parameters
- Ability to add your own programs
- Config support
- Include a custom UE4 editor
- Creating mods

# Credits
- Microsoft for Fluent Design Icons

# Command Line Use
### Available command line arguments
```
Syntax: VerucaviaNewAgeSDK.exe [noSwitchForAppStart] [--help] [--about] [--verifyconfig] [--setup] [--launch] [--build]

--help           Prints the help message
--about          Shows the application's version and build config
--verifyconfig   For debugging perposes, to wonder why the app crashed.
--setup          Use this to set the game path and optional launch arguments.
--launch         Launch Verucavia: New Age
--build          Builds Verucavia: New Age by using Unreal Automation Tool
```
