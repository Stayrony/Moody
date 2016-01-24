using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Moody.UI.Contract;
using Moody.UI.ViewModel.MenuItemsViewModel;

namespace Moody.UI.Control.MenuItems
{
    /// <summary>
    /// Interaction logic for ImagesControl.xaml
    /// </summary>
    public partial class ImagesControl : UserControl, IView
    {
        /// <summary>
        /// The images view model property.
        /// </summary>
        public static readonly DependencyProperty ImagesViewModelProperty =
            DependencyProperty.Register(
                "ImagesViewModel",
                typeof(ImagesViewModel),
                typeof(ImagesControl),
                new UIPropertyMetadata(null));

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImagesControl" /> class.
        /// </summary>
        public ImagesControl()
        {
            this.InitializeComponent();
            this.ImagesViewModel = new ImagesViewModel(this);
            this.DataContext = this.ImagesViewModel;
            this.SetFocus();
        }

        /// <summary>
        /// Gets or sets the images view model.
        /// </summary>
        public ImagesViewModel ImagesViewModel
        {
            get
            {
                return (ImagesViewModel)this.GetValue(ImagesViewModelProperty);
            }

            set
            {
                this.SetValue(ImagesViewModelProperty, value);
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
