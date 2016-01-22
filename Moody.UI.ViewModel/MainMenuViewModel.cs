// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainMenuViewModel.cs" company="">
//   
// </copyright>
// <summary>
//   The main menu view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Moody.UI.ViewModel
{
    using System;
    using System.Windows.Input;

    using Moody.Exception;
    using Moody.UI.Context;
    using Moody.UI.Contract;
    using Moody.UI.Utility;

    /// <summary>
    ///     The main menu view model.
    /// </summary>
    public class MainMenuViewModel : ViewModelBase
    {
        #region Fields

        /// <summary>
        ///     The view.
        /// </summary>
        private readonly IView View;

        /// <summary>
        ///     The homepage link.
        /// </summary>
        private RelayCommand homepageLink;

        /// <summary>
        ///     The images link.
        /// </summary>
        private RelayCommand imagesLink;

        /// <summary>
        ///     The music link.
        /// </summary>
        private RelayCommand musicLink;

        /// <summary>
        ///     The profile link.
        /// </summary>
        private RelayCommand profileLink;

        /// <summary>
        ///     The quotes link.
        /// </summary>
        private RelayCommand quotesLink;

        /// <summary>
        ///     The statistics link.
        /// </summary>
        private RelayCommand statisticsLink;

        /// <summary>
        ///     The videos link.
        /// </summary>
        private RelayCommand videosLink;

        #endregion Fields

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="MainMenuViewModel"/> class.
        /// </summary>
        /// <param name="view">
        /// The view.
        /// </param>
        /// <exception cref="Exception">
        /// </exception>
        public MainMenuViewModel(IView view)
        {
            try
            {
                this.View = view;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        #endregion Constructor

        #region Presentation Properties

        /// <summary>
        ///     Gets the homepage link.
        /// </summary>
        public ICommand HomepageLink
        {
            get
            {
                if (this.homepageLink == null)
                {
                    this.homepageLink = new RelayCommand(param => this.Homepage(), param => true);
                }

                return this.homepageLink;
            }
        }

        /// <summary>
        /// Gets the images link.
        /// </summary>
        public ICommand ImagesLink
        {
            get
            {
                if (this.imagesLink == null)
                {
                    this.imagesLink = new RelayCommand(param => this.Images(), param => true);
                }

                return this.imagesLink;
            }
        }

        /// <summary>
        /// Gets the music link.
        /// </summary>
        public ICommand MusicLink
        {
            get
            {
                if (this.musicLink == null)
                {
                    this.musicLink = new RelayCommand(param => this.Music(), param => true);
                }

                return this.musicLink;
            }
        }

        /// <summary>
        /// Gets the profile link.
        /// </summary>
        public ICommand ProfileLink
        {
            get
            {
                if (this.profileLink == null)
                {
                    this.profileLink = new RelayCommand(param => this.Profile(), param => true);
                }

                return this.profileLink;
            }
        }

        /// <summary>
        /// Gets the quotes link.
        /// </summary>
        public ICommand QuotesLink
        {
            get
            {
                if (this.quotesLink == null)
                {
                    this.quotesLink = new RelayCommand(param => this.Quotes(), param => true);
                }

                return this.quotesLink;
            }
        }

        /// <summary>
        /// Gets the statistics link.
        /// </summary>
        public ICommand StatisticsLink
        {
            get
            {
                if (this.statisticsLink == null)
                {
                    this.statisticsLink = new RelayCommand(param => this.Statistics(), param => true);
                }

                return this.statisticsLink;
            }
        }

        /// <summary>
        /// Gets the videos link.
        /// </summary>
        public ICommand VideosLink
        {
            get
            {
                if (this.videosLink == null)
                {
                    this.videosLink = new RelayCommand(param => this.Videos(), param => true);
                }

                return this.videosLink;
            }
        }

        #endregion Presentation Properties


        #region Public Method

        /// <summary>
        ///     The homepage.
        /// </summary>
        public void Homepage()
        {
            try
            {
                ControlManager.GetInstance().Place("DashboardControl", "mainRegion", "HomepageControl");
            }
            catch (ExceptionBase exception)
            {
                var message = exception.GetMessage();
                this.View.ShowError(message);
            }
        }

        /// <summary>
        ///     The images.
        /// </summary>
        public void Images()
        {
            try
            {
                ControlManager.GetInstance().Place("DashboardControl", "mainRegion", "ImagesControl");
            }
            catch (ExceptionBase exception)
            {
                var error = exception.GetMessage();
                this.View.ShowError(error);
            }
        }

        /// <summary>
        ///     The music.
        /// </summary>
        public void Music()
        {
            try
            {
                ControlManager.GetInstance().Place("DashboardControl", "mainRegion", "EmptyItemControl");
            }
            catch (ExceptionBase exception)
            {
                var error = exception.GetMessage();
                this.View.ShowError(error);
            }
        }

        /// <summary>
        ///     The profile.
        /// </summary>
        public void Profile()
        {
            try
            {
                ControlManager.GetInstance().Place("DashboardControl", "mainRegion", "ProfileControl");
            }
            catch (ExceptionBase exception)
            {
                var error = exception.GetMessage();
                this.View.ShowError(error);
            }
        }

        /// <summary>
        ///     The quotes.
        /// </summary>
        public void Quotes()
        {
            try
            {
                ControlManager.GetInstance().Place("DashboardControl", "mainRegion", "QuotesControl");
            }
            catch (ExceptionBase exception)
            {
                var error = exception.GetMessage();
                this.View.ShowError(error);
            }
        }

        /// <summary>
        ///     The statistics.
        /// </summary>
        public void Statistics()
        {
            try
            {
                ControlManager.GetInstance().Place("DashboardControl", "mainRegion", "StatisticsControl");
            }
            catch (ExceptionBase exception)
            {
                var error = exception.GetMessage();
                this.View.ShowError(error);
            }
        }

        /// <summary>
        ///     The videos.
        /// </summary>
        public void Videos()
        {
            try
            {
                ControlManager.GetInstance().Place("DashboardControl", "mainRegion", "VideosControl");
            }
            catch (ExceptionBase exception)
            {
                var error = exception.GetMessage();
                this.View.ShowError(error);
            }
        }

        #endregion Public Method
    }
}