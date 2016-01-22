// --------------------------------------------------------------------------------------------------------------------
// <copyright file="App.xaml.cs" company="">
//   
// </copyright>
// <summary>
//   Interaction logic for App.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Moody.UI
{
    using System;
    using System.Windows;

    using Moody.UI.Context;
    using Moody.UI.Control;
    using Moody.UI.Control.MenuItems;

    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// The main window.
        /// </summary>
        private MainWindow mainWindow;

        /// <summary>
        /// The app start up.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="args">
        /// The args.
        /// </param>
        private void AppStartUp(object sender, StartupEventArgs args)
        {
            try
            {
                // Bootstrapper.Init();
                ControlManager.GetInstance().Add("MainWindow", typeof(MainWindow));
                ControlManager.GetInstance().Add("LoginControl", typeof(LoginControl));
                ControlManager.GetInstance().Add("DashboardControl", typeof(DashboardControl));
                ControlManager.GetInstance().Add("RegisterControl", typeof(RegisterControl));

                // Menu Items
                ControlManager.GetInstance().Add("HomepageControl", typeof(HomepageControl));
                ControlManager.GetInstance().Add("MusicControl", typeof(MusicControl));
                ControlManager.GetInstance().Add("StatisticsControl", typeof(StatisticsControl));
                ControlManager.GetInstance().Add("ImagesControl", typeof(ImagesControl));
                ControlManager.GetInstance().Add("ProfileControl", typeof(ProfileControl));
                ControlManager.GetInstance().Add("QuotesControl", typeof(QuotesControl));
                ControlManager.GetInstance().Add("VideosControl", typeof(VideosControl));

                //Empty Item
                ControlManager.GetInstance().Add("EmptyItemControl", typeof(EmptyItemControl));

                this.mainWindow = ControlManager.GetInstance().GetControl("MainWindow") as MainWindow;
                this.mainWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                this.mainWindow.Show();

                ControlManager.GetInstance().Place("MainWindow", "mainRegion", "LoginControl");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// The app exit.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="args">
        /// The args.
        /// </param>
        public void AppExit(object sender, ExitEventArgs args)
        {
            this.Shutdown();
        }

        /// <summary>
        /// The quit.
        /// </summary>
        public void Quit()
        {
            this.Shutdown();
        }
    }
}