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
    /// Interaction logic for StatisticsControl.xaml
    /// </summary>
    public partial class StatisticsControl : UserControl, IView
    {


        public StatisticsViewModel StatisticsViewModel
        {
            get { return (StatisticsViewModel)GetValue(StatisticsViewModelProperty); }
            set { SetValue(StatisticsViewModelProperty, value); }
        }

        public static readonly DependencyProperty StatisticsViewModelProperty = DependencyProperty.Register(
               "StatisticsViewModel", 
               typeof(StatisticsViewModel), 
               typeof(StatisticsControl),
               new UIPropertyMetadata(null));


        public StatisticsControl()
        {
            InitializeComponent();
            this.SetFocus();
            this.StatisticsViewModel = new StatisticsViewModel(this);
            this.DataContext = StatisticsViewModel;
        }

        public void SetFocus()
        {

        }

        public void ShowError(string error)
        {
            MessageBox.Show(error);
        }
    }
}
