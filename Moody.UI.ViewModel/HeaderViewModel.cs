// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HeaderViewModel.cs" company="">
//   
// </copyright>
// <summary>
//   The header view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Moody.UI.ViewModel
{
    using System;
    using System.Windows;
    using System.Windows.Input;

    using Moody.Exception;
    using Moody.UI.Contract;
    using Moody.UI.Utility;

    /// <summary>
    /// The header view model.
    /// </summary>
    public class HeaderViewModel : ViewModelBase
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="HeaderViewModel"/> class.
        /// </summary>
        /// <param name="view">
        /// The view.
        /// </param>
        /// <exception cref="Exception">
        /// </exception>
        public HeaderViewModel(IView view)
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

        #endregion  Constructor

        #region Public Method

        /// <summary>
        /// The search by tag.
        /// </summary>
        private void SearchByTag()
        {
            try
            {
                if (this.SearchingTag == string.Empty)
                {
                }
            }
            catch (ExceptionBase exception)
            {
                var message = exception.GetMessage();
                this.View.ShowError(message);
            }
        }

        // private void NavigateToSearchBox()
        // {
        // FocusManager.SetFocusedElement(SearchingTag, );
        // }

        #endregion Public Method

        #region Fields

        /// <summary>
        /// The view.
        /// </summary>
        private readonly IView View;

        /// <summary>
        /// The _navigate to search box command.
        /// </summary>
        private RelayCommand _navigateToSearchBoxCommand;

        /// <summary>
        /// The _search by tag command.
        /// </summary>
        private RelayCommand _searchByTagCommand;

        /// <summary>
        /// The searching tag property.
        /// </summary>
        public static readonly DependencyProperty SearchingTagProperty = DependencyProperty.Register(
            "SearchingTag",
            typeof(string),
            typeof(HeaderViewModel),
            new UIPropertyMetadata(null));

        #endregion Fields


        #region Search Properties

        /// <summary>
        /// Gets or sets the searching tag.
        /// </summary>
        public string SearchingTag
        {
            get
            {
                return (string)this.GetValue(SearchingTagProperty);
            }

            set
            {
                this.SetValue(SearchingTagProperty, value);
            }
        }

        #endregion Search Properties

        #region Presentation Properties

        /// <summary>
        /// Gets the search by tag command.
        /// </summary>
        public ICommand SearchByTagCommand
        {
            get
            {
                if (this._searchByTagCommand == null)
                {
                    this._searchByTagCommand = new RelayCommand(param => this.SearchByTag());
                }

                return this._searchByTagCommand;
            }
        }

        ///// <summary>
        ///// Gets the navigate to search box command.
        ///// </summary>
        //public ICommand NavigateToSearchBoxCommand
        //{
        //    // TODO remove
        //    get
        //    {
        //        if (this._navigateToSearchBoxCommand == null)
        //        {
        //            this._navigateToSearchBoxCommand = new RelayCommand(param => this.NavigateToSearchBox());
        //        }

        //        return this._navigateToSearchBoxCommand;
        //    }
        //}

        #endregion Presentation Properties
    }
}