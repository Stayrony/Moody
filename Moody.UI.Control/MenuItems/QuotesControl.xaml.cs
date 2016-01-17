// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QuotesControl.xaml.cs" company="">
//   
// </copyright>
// <summary>
//    Interaction logic for QuotesControl.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Moody.UI.Control.MenuItems
{
    using System.Windows;
    using System.Windows.Controls;

    using Moody.UI.Contract;
    using Moody.UI.ViewModel.MenuItemsViewModel;

    /// <summary>
    ///      Interaction logic for QuotesControl.xaml
    /// </summary>
    public partial class QuotesControl : UserControl, IView
    {
        /// <summary>
        /// The quotes view model property.
        /// </summary>
        public static readonly DependencyProperty QuotesViewModelProperty =
            DependencyProperty.Register(
                "QuotesViewModel",
                typeof(QuotesViewModel),
                typeof(QuotesControl),
                new UIPropertyMetadata(null));

        /// <summary>
        ///     Initializes a new instance of the <see cref="QuotesControl" /> class.
        /// </summary>
        public QuotesControl()
        {
            this.InitializeComponent();
            this.QuotesViewModel = new QuotesViewModel(this);
            this.DataContext = this.QuotesViewModel;
            this.SetFocus();
        }

        /// <summary>
        /// Gets or sets the quotes view model.
        /// </summary>
        public QuotesViewModel QuotesViewModel
        {
            get
            {
                return (QuotesViewModel)this.GetValue(QuotesViewModelProperty);
            }

            set
            {
                this.SetValue(QuotesViewModelProperty, value);
            }
        }

        /// <summary>
        /// The show error.
        /// </summary>
        /// <param name="error">
        /// The error.
        /// </param>
        public void ShowError(string error)
        {
            MessageBox.Show(error);
        }

        /// <summary>
        /// The set focus.
        /// </summary>
        public void SetFocus()
        {
        }
    }
}