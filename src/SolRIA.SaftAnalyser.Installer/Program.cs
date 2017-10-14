using System;
using System.Text;
using WixSharp;
using WixSharp.Forms;

namespace SolRIA.SaftAnalyser.Installer
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseFolderPath = @"C:\Users\frede\Source\Repos\saft\src\SolRIA.SaftAnalyser\bin\Release";

            var project = new ManagedProject("SolRIA SAFT",
                          new Dir(@"%ProgramFiles%\SolRIA\SolRIA SAFT",
                              new File(System.IO.Path.Combine(baseFolderPath, "license.txt")),
                              new File(System.IO.Path.Combine(baseFolderPath, "NLog.config")),
                              new File(System.IO.Path.Combine(baseFolderPath, "SolRIA.SaftAnalyser.exe"),
                                  new FileShortcut("SolRIA SAFT Analyser", @"%ProgramMenu%\SolRIA\SolRIA SAFT"),
                                  new FileShortcut("SolRIA SAFT Analyser", @"%Desktop%")),
                              new File(System.IO.Path.Combine(baseFolderPath, "CommonServiceLocator.dll")),
                              new File(System.IO.Path.Combine(baseFolderPath, "Dragablz.dll")),
                              new File(System.IO.Path.Combine(baseFolderPath, "EntityFramework.dll")),
                              new File(System.IO.Path.Combine(baseFolderPath, "EntityFramework.SqlServer.dll")),
                              new File(System.IO.Path.Combine(baseFolderPath, "EPPlus.dll")),
                              new File(System.IO.Path.Combine(baseFolderPath, "MaterialDesignColors.dll")),
                              new File(System.IO.Path.Combine(baseFolderPath, "MaterialDesignThemes.Wpf.dll")),
                              new File(System.IO.Path.Combine(baseFolderPath, "Microsoft.Practices.Unity.Configuration.dll")),
                              new File(System.IO.Path.Combine(baseFolderPath, "Microsoft.Practices.Unity.dll")),
                              new File(System.IO.Path.Combine(baseFolderPath, "Microsoft.Practices.Unity.RegistrationByConvention.dll")),
                              new File(System.IO.Path.Combine(baseFolderPath, "NLog.dll")),
                              new File(System.IO.Path.Combine(baseFolderPath, "Prism.dll")),
                              new File(System.IO.Path.Combine(baseFolderPath, "Prism.Unity.Wpf.dll")),
                              new File(System.IO.Path.Combine(baseFolderPath, "Prism.Wpf.dll")),
                              new File(System.IO.Path.Combine(baseFolderPath, "SolRIA.SaftAnalyser.Logic.dll")),
                              new File(System.IO.Path.Combine(baseFolderPath, "Syncfusion.Data.WPF.dll")),
                              new File(System.IO.Path.Combine(baseFolderPath, "Syncfusion.SfGrid.WPF.dll")),
                              new File(System.IO.Path.Combine(baseFolderPath, "Syncfusion.SfSkinManager.WPF.dll")),
                              new File(System.IO.Path.Combine(baseFolderPath, "Syncfusion.Shared.WPF.dll")),
                              new File(System.IO.Path.Combine(baseFolderPath, "Syncfusion.Themes.Blend.WPF.dll")),
                              new File(System.IO.Path.Combine(baseFolderPath, "sqlite3.dll")),
                              new File(System.IO.Path.Combine(baseFolderPath, "System.Data.SQLite.dll")),
                              new File(System.IO.Path.Combine(baseFolderPath, "System.Data.SQLite.EF6.dll")),
                              new File(System.IO.Path.Combine(baseFolderPath, "System.Data.SQLite.Linq.dll")),
                              new File(System.IO.Path.Combine(baseFolderPath, "System.Windows.Interactivity.dll"))),
                              new Dir("x64",
                                  new File(System.IO.Path.Combine(baseFolderPath, "x64", "SQLite.Interop.dll"))),
                              new Dir("x86",
                                  new File(System.IO.Path.Combine(baseFolderPath, "x86", "SQLite.Interop.dll"))));
            
            project.ResolveWildCards();
            project.OutFileName = "SolRIA.SaftAnalyser";
            project.ProductId = Guid.NewGuid();
            project.UpgradeCode = new Guid("{9ADF9E4F-BEC5-4875-8E93-6287751C0503}");
            project.Version = Version.Parse("17.10.14.0");
            project.LicenceFile = System.IO.Path.Combine(baseFolderPath, "license.rtf");

            project.MajorUpgradeStrategy = MajorUpgradeStrategy.Default;
            project.MajorUpgradeStrategy.RemoveExistingProductAfter = Step.InstallInitialize;

            project.ControlPanelInfo.Comments = "SolRIA SAF-T Analyser";
            project.ControlPanelInfo.HelpLink = "http://www.solria.pt/";
            project.ControlPanelInfo.UrlInfoAbout = "http://www.solria.pt/";
            project.ControlPanelInfo.ProductIcon = System.IO.Path.Combine(baseFolderPath, "app.ico");
            project.ControlPanelInfo.Contact = "SolRIA, Ideal Software Solutions LDA";
            project.ControlPanelInfo.Manufacturer = "SolRIA, Ideal Software Solutions LDA";
            project.ControlPanelInfo.NoModify = true;
            project.ControlPanelInfo.NoRepair = true;

            project.BackgroundImage = "solria_background2.bmp";
            project.BannerImage = "solria_banner.bmp";
            project.LocalizationFile = "wixui_pt-PT.wxl";
            project.Encoding = Encoding.UTF8;

            project.ManagedUI = ManagedUI.Empty;    //no standard UI dialogs

            //custom set of standard UI dialogs
            project.ManagedUI = new ManagedUI();

            project.ManagedUI.InstallDialogs.Add(Dialogs.Welcome)
                                            .Add(Dialogs.Licence)
                                            .Add(Dialogs.Progress)
                                            .Add(Dialogs.Exit);

            project.ManagedUI.ModifyDialogs.Add(Dialogs.MaintenanceType)
                                           .Add(Dialogs.Progress)
                                           .Add(Dialogs.Exit);

            Compiler.BuildMsi(project);

            Console.WriteLine("Msi build complete. Enter to close.");
            Console.ReadLine();
        }
    }
}
