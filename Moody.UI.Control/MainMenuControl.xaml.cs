// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainMenuControl.xaml.cs" company="">
//   
// </copyright>
// <summary>
//   Interaction logic for MainMenuControl.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Moody.UI.Control
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    using Moody.UI.Contract;
    using Moody.UI.ViewModel;

    /// <summary>
    ///     Interaction logic for MainMenuControl.xaml
    /// </summary>
    public partial class MainMenuControl : UserControl, IView
    {
        /// <summary>
        /// The main menu property.
        /// </summary>
        public static readonly DependencyProperty MainMenuViewModelProperty = DependencyProperty.Register(
            "MainMenuViewModel",
            typeof(MainMenuViewModel),
            typeof(MainMenuControl),
            new UIPropertyMetadata(null));

        /// <summary>
        ///     Initializes a new instance of the <see cref="MainMenuControl" /> class.
        /// </summary>
        public MainMenuControl()
        {
            this.MainMenuViewModel = new MainMenuViewModel(this);
            this.InitializeComponent();
            this.DataContext = this.MainMenuViewModel;
            this.SetFocus();
        }

        /// <summary>
        /// Gets or sets the main menu view model.
        /// </summary>
        public MainMenuViewModel MainMenuViewModel
        {
            get
            {
                return (MainMenuViewModel)this.GetValue(MainMenuViewModelProperty);
            }

            set
            {
                this.SetValue(MainMenuViewModelProperty, value);
            }
        }

        /// <summary>
        /// The set focus.
        /// </summary>
        public void SetFocus()
        {
            FocusManager.SetFocusedElement(this, this.Homepage);
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