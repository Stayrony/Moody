// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StatisticsViewModel.cs" company="">
//   
// </copyright>
// <summary>
//   The statistics view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Moody.UI.ViewModel.MenuItemsViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    using Moody.Service.BLL;
    using Moody.UI.Contract;

    /// <summary>
    /// The statistics view model.
    /// </summary>
    public class StatisticsViewModel : ViewModelBase
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="StatisticsViewModel"/> class.
        /// </summary>
        /// <param name="view">
        /// The view.
        /// </param>
        /// <exception cref="Exception">
        /// </exception>
        public StatisticsViewModel(IView view)
        {
            try
            {
                this.View = view;
                this.TagStatistic = this.GetTagStatistic();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        #endregion Constructor

        /// <summary>
        ///     Gets or sets the selected item.
        /// </summary>
        public object SelectedItem { get; set; }

        /// <summary>
        /// The get tag statistic.
        /// </summary>
        /// <returns>
        /// The <see cref="ObservableCollection"/>.
        /// </returns>
        private ObservableCollection<StatisticItem> GetTagStatistic()
        {
            var _tagStatisticItems = new ObservableCollection<StatisticItem>();
            var tagCountDictionary = new Dictionary<string, Dictionary<string, int>>();

            tagCountDictionary = this.statisticManager.GetTagCountDictionary();
            foreach (var kvp in tagCountDictionary)
            {
                // Console.WriteLine("For tag : " + kvp.Key);
                var totalCountOfTag = 0;
                foreach (var keyValuePair in kvp.Value)
                {
                    totalCountOfTag += keyValuePair.Value;

                    // Console.Write(keyValuePair.Key + " = " + keyValuePair.Value + "\t");
                }

                _tagStatisticItems.Add(new StatisticItem { Name = kvp.Key, Number = totalCountOfTag });

                // Console.WriteLine();
            }

            return _tagStatisticItems;
        }

        #region Field

        /// <summary>
        /// Gets the tag statistic.
        /// </summary>
        public ObservableCollection<StatisticItem> TagStatistic { get; private set; }

        /// <summary>
        /// The view.
        /// </summary>
        private readonly IView View;

        /// <summary>
        /// The statistic manager.
        /// </summary>
        private readonly StatisticManager statisticManager = new StatisticManager();

        #endregion Field
    }
}