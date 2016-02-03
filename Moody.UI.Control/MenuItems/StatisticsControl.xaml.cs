// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StatisticsControl.xaml.cs" company="">
//   
// </copyright>
// <summary>
//   Interaction logic for StatisticsControl.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Moody.UI.Control.MenuItems
{
    using System.Windows;
    using System.Windows.Controls;

    using Moody.UI.Contract;
    using Moody.UI.ViewModel.MenuItemsViewModel;

    /// <summary>
    ///     Interaction logic for StatisticsControl.xaml
    /// </summary>
    public partial class StatisticsControl : UserControl, IView
    {
        /// <summary>
        /// The statistics view model property.
        /// </summary>
        public static readonly DependencyProperty StatisticsViewModelProperty =
            DependencyProperty.Register(
                "StatisticsViewModel",
                typeof(StatisticsViewModel),
                typeof(StatisticsControl),
                new UIPropertyMetadata(null));

        /// <summary>
        /// Initializes a new instance of the <see cref="StatisticsControl"/> class.
        /// </summary>
        public StatisticsControl()
        {
            this.InitializeComponent();
            this.SetFocus();
            this.StatisticsViewModel = new StatisticsViewModel(this);
            this.DataContext = this.StatisticsViewModel;
        }

        /// <summary>
        /// Gets or sets the statistics view model.
        /// </summary>
        public StatisticsViewModel StatisticsViewModel
        {
            get
            {
                return (StatisticsViewModel)this.GetValue(StatisticsViewModelProperty);
            }

            set
            {
                this.SetValue(StatisticsViewModelProperty, value);
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