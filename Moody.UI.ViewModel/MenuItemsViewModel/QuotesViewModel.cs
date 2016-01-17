// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QuotesViewModel.cs" company="">
//   
// </copyright>
// <summary>
//   The quotes view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Moody.UI.ViewModel.MenuItemsViewModel
{
    using System;
    using System.Collections.ObjectModel;
    using System.Windows;

    using Moody.Service.BLL;
    using Moody.Service.Domain;
    using Moody.UI.Contract;

    /// <summary>
    ///     The quotes view model.
    /// </summary>
    public class QuotesViewModel : ViewModelBase
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="QuotesViewModel"/> class.
        /// </summary>
        /// <param name="view">
        /// The view.
        /// </param>
        /// <exception cref="Exception">
        /// </exception>
        public QuotesViewModel(IView view)
        {
            try
            {
                this.View = view;
                this._quotesList = this.GetQuotes();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        #endregion Constructor

        /// <summary>
        ///     Gets the quotes list.
        /// </summary>
        public ObservableCollection<Quote> QuotesList
        {
            get
            {
                return this._quotesList;
            }
        }

        /// <summary>
        /// The get quotes.
        /// </summary>
        /// <returns>
        /// The <see cref="ObservableCollection"/>.
        /// </returns>
        private ObservableCollection<Quote> GetQuotes()
        {
            var quotes = this.quoteManager.GetAllQuotes();
            ObservableCollection<Quote> quoteCollection = new ObservableCollection<Quote>(quotes);
            return quoteCollection;
        }

        #region Fields

        /// <summary>
        ///     The view.
        /// </summary>
        private readonly IView View;

        /// <summary>
        ///     The _quotes list.
        /// </summary>
        private readonly ObservableCollection<Quote> _quotesList = new ObservableCollection<Quote>();

        /// <summary>
        ///     The body quote property.
        /// </summary>
        public static readonly DependencyProperty BodyQuoteProperty = DependencyProperty.Register(
            "Body",
            typeof(string),
            typeof(QuotesViewModel),
            new UIPropertyMetadata(null));

        /// <summary>
        ///     The author quote property.
        /// </summary>
        public static readonly DependencyProperty AuthorQuoteProperty = DependencyProperty.Register(
            "Author",
            typeof(string),
            typeof(QuotesViewModel),
            new UIPropertyMetadata(null));

        /// <summary>
        ///     The tags property.
        /// </summary>
        public static readonly DependencyProperty TagsProperty = DependencyProperty.Register(
            "Tags",
            typeof(string),
            typeof(QuotesViewModel),
            new UIPropertyMetadata(null));

        /// <summary>
        /// The quote manager.
        /// </summary>
        private readonly QuoteManager quoteManager = new QuoteManager();

        #endregion Fields

        #region User Properties

        /// <summary>
        ///     Gets or sets the body quote.
        /// </summary>
        public string Body
        {
            get
            {
                return (string)this.GetValue(BodyQuoteProperty);
            }

            set
            {
                this.SetValue(BodyQuoteProperty, value);
            }
        }

        /// <summary>
        ///     Gets or sets the author quote.
        /// </summary>
        public string Author
        {
            get
            {
                return (string)this.GetValue(AuthorQuoteProperty);
            }

            set
            {
                this.SetValue(AuthorQuoteProperty, value);
            }
        }

        /// <summary>
        ///     Gets or sets the tags.
        /// </summary>
        public string Tags
        {
            get
            {
                return (string)this.GetValue(TagsProperty);
            }

            set
            {
                this.SetValue(TagsProperty, value);
            }
        }

        #endregion User Properties
    }
}