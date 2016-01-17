// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RegisterControl.xaml.cs" company="">
//   
// </copyright>
// <summary>
//   Interaction logic for RegisterControl.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Moody.UI.Control
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    using Moody.UI.Contract;
    using Moody.UI.ViewModel;

    /// <summary>
    ///     Interaction logic for RegisterControl.xaml
    /// </summary>
    public partial class RegisterControl : UserControl, IView
    {
        /// <summary>
        ///     The register view model property.
        /// </summary>
        public static readonly DependencyProperty RegisterViewModelProperty =
            DependencyProperty.Register(
                "RegisterViewModel",
                typeof(RegisterViewModel),
                typeof(RegisterControl),
                new UIPropertyMetadata(null));

        /// <summary>
        ///     Initializes a new instance of the <see cref="RegisterControl" /> class.
        /// </summary>
        public RegisterControl()
        {
            this.RegisterViewModel = new RegisterViewModel(this);
            this.InitializeComponent();
            this.SetFocus();
            this.DataContext = this.RegisterViewModel;

            // RegisterViewModel.LoginName = "dsdsds";
            // RegisterViewModel.Email = "beyoncem4@gmail.com";
            // RegisterViewModel.Password = "ChristianKane27%&";
            // RegisterViewModel.ConfirmPassword = "ChristianKane27%&";
        }

        /// <summary>
        ///     Gets or sets the register view model.
        /// </summary>
        public RegisterViewModel RegisterViewModel
        {
            get
            {
                return (RegisterViewModel)this.GetValue(RegisterViewModelProperty);
            }

            set
            {
                this.SetValue(RegisterViewModelProperty, value);
            }
        }

        /// <summary>
        ///     The set focus.
        /// </summary>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void SetFocus()
        {
            FocusManager.SetFocusedElement(this, this.LoginNameTxt);
        }

        /// <summary>
        /// The show error.
        /// </summary>
        /// <param name="error">
        /// The error.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void ShowError(string error)
        {
            MessageBox.Show(error);
        }
    }
}