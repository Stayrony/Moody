using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Moody.Service.BLL;
using Moody.UI.Contract;

namespace Moody.UI.ViewModel.MenuItemsViewModel
{
    public class StatisticsViewModel : ViewModelBase
    {
        #region Constructor

        public StatisticsViewModel(IView view)
        {
            try
            {
                this.View = view;
                this.TagStatistic = this.GetTagStatistic();
            }
            catch (System.Exception exception)
            {
                throw exception;
            }
        }

        #endregion Constructor

        #region Field

        public ObservableCollection<StatisticItem> TagStatistic { get; private set; }
        private readonly IView View;
        private readonly StatisticManager statisticManager = new StatisticManager();
        private object selectedItem;

        #endregion Field

        private ObservableCollection<StatisticItem> GetTagStatistic()
        {
            ObservableCollection<StatisticItem> _tagStatisticItems = new ObservableCollection<StatisticItem>();
            Dictionary<string, Dictionary<string, int>> tagCountDictionary =
                new Dictionary<string, Dictionary<string, int>>();

            tagCountDictionary = this.statisticManager.GetTagCountDictionary();
            foreach (var kvp in tagCountDictionary)
            {
                // Console.WriteLine("For tag : " + kvp.Key);
                int totalCountOfTag = 0;
                foreach (var keyValuePair in kvp.Value)
                {
                    totalCountOfTag += keyValuePair.Value;
                    //  Console.Write(keyValuePair.Key + " = " + keyValuePair.Value + "\t");
                }

                _tagStatisticItems.Add(new StatisticItem {Name = kvp.Key, Number = totalCountOfTag});

                //  Console.WriteLine();
            }

            return _tagStatisticItems;
        }

        /// <summary>
        /// Gets or sets the selected item.
        /// </summary>
        public object SelectedItem
        {
            get { return this.selectedItem; }

            set
            {
                // selected item has changed
                this.selectedItem = value;
            }
        }
    }
}