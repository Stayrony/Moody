// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HeaderControl.xaml.cs" company="">
//   
// </copyright>
// <summary>
//   Interaction logic for HeaderControl.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Moody.UI.Control
{
    using System.Windows;
    using System.Windows.Controls;

    using Moody.UI.Contract;
    using Moody.UI.ViewModel;

    /// <summary>
    ///     Interaction logic for HeaderControl.xaml
    /// </summary>
    public partial class HeaderControl : UserControl, IView
    {
        /// <summary>
        /// The header view model property.
        /// </summary>
        public static readonly DependencyProperty HeaderViewModelProperty =
            DependencyProperty.Register(
                "HeaderViewModel",
                typeof(HeaderViewModel),
                typeof(HeaderControl),
                new UIPropertyMetadata(null));

        /// <summary>
        /// Initializes a new instance of the <see cref="HeaderControl"/> class.
        /// </summary>
        public HeaderControl()
        {
            this.HeaderViewModel = new HeaderViewModel(this);
            this.DataContext = this.HeaderViewModel;
            this.InitializeComponent();
            this.SetFocus();
        }

        /// <summary>
        /// Gets or sets the header view model.
        /// </summary>
        public HeaderViewModel HeaderViewModel
        {
            get
            {
                return (HeaderViewModel)this.GetValue(HeaderViewModelProperty);
            }

            set
            {
                this.SetValue(HeaderViewModelProperty, value);
            }
        }

        /// <summary>
        /// The set focus.
        /// </summary>
        public void SetFocus()
        {
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
    }
}