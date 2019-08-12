# Informations for developers
# -------------------------------------------

## Authors


## Tools

| Name of Tool | Version | Description | Link |
| :------ | :--- | :--- | :--- |
| Visual Studio Community | 2017 | Development environment | via Google |
| WiX Toolset | 3.11 | Build tool for setup | [http://wixtoolset.org/](http://wixtoolset.org/) |
| WiX Toolset | 3.11 | Extension for Visual Studio | [http://wixtoolset.org/](http://wixtoolset.org/) |
| WixEdit | 0.7.5 | Editor for Wix files | [http://wixedit.sourceforge.net/](http://wixedit.sourceforge.net/) |
| 7-Zip | 19.00 | Zip tool | [http://7-zip.org/](http://7-zip.org/) |
| Git for Windows | 2.21.x | Version control | [https://git-scm.com/download/win](https://git-scm.com/download/win) |
| TortoiseGit | 2.8.x | Version control | [https://tortoisegit.org/](https://tortoisegit.org/) |


## License

see license file

## Assembly Signing

In the project build file *.csproj you may find following commands in a <PropertyGroup\>:

    <SignAssembly>true</SignAssembly>
    <AssemblyOriginatorKeyFile>WinFormsRibbon.snk</AssemblyOriginatorKeyFile>
For each .NET version we need a unique AssemblyVersion. This version should only change
in case of a new interface for users. The AssemblyVersion for the .NET2 build is 2.0.0.0 and the AssemblyVersion for the .NET4 build is 4.0.0.0
Only AssemblyFileVersion had to change for bugfixes. These things have to be done in file "AssemblyInfo.cs".


## Build

In the folder "System.Windows.Forms.Ribbon" there are project files for .NET2 and .NET4 (System.Windows.Forms.Ribbon.sln and System.Windows.Forms.Ribbon.NET4.sln).
The project files will build signed Assemblys.
In the folder "System.Windows.Forms.Ribbon\Setup" there are files to build a MSI-Setup (RibbonSetup.sln). Results of the build are in subfolder "msi". These .msi files will install the System.Windows.Forms.Ribbon.dll to the GAC (Global Assembly Cache) and to the x86 Programfiles (subfolder WinFormsRibbon) for referencing in Visual Studio.
For building the setup it is neccessary to install the Wix Toolset VisualStudio Extension.

## Todo

- solving open bugs (which are open ?)
- testing with different environment (Multi monitor, ...)
- uniform formatting of source code (code style)
- build a new release (5.0.2.0)
- zip of msi files for the new release
- instead many events in the controls or components it might be better to work with EventHandlerList
- Xml Document file for Intellisense. There are many warnings when building Xml file

## Release Versions

https://github.com/RibbonWinForms/RibbonWinForms/releases

- 5.0.1.0 release published by adriancs2, UTC time: Sunday, June 23, 2019, 14:03
