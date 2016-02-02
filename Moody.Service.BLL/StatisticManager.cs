// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StatisticManager.cs" company="">
//   
// </copyright>
// <summary>
//   The statistic manager.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Moody.Service.BLL
{
    using System.Collections.Generic;

    using Moody.DAL;
    using Moody.Service.Domain;

    /// <summary>
    /// The statistic manager.
    /// </summary>
    public class StatisticManager
    {
        /// <summary>
        /// The quantity dal manager.
        /// </summary>
        private readonly StatisticDalManager statisticDalManager;

        /// <summary>
        /// The tag dal manager.
        /// </summary>
        private readonly TagDalManager tagDalManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="StatisticManager"/> class.
        /// </summary>
        public StatisticManager()
        {
            this.statisticDalManager = new StatisticDalManager();
            this.tagDalManager = new TagDalManager();
        }

        /// <summary>
        /// The get tag count dictionary.
        /// <example>
        ///  ambient, quoteTagCount = 0	imageTagCount = 1
        ///  dreamy, quoteTagCount = 1	imageTagCount = 1
        /// </example>
        /// </summary>
        /// <returns>
        /// The <see cref="Dictionary"/>.
        /// </returns>
        public Dictionary<string, Dictionary<string, int>> GetTagCountDictionary()
        {
            var tagCountDictionary = new Dictionary<string, Dictionary<string, int>>();
            var tags = new List<Tag>();

            tags = this.tagDalManager.GetAllTags();
            foreach (var tag in tags)
            {
                var itemDictionary = new Dictionary<string, int>();
                itemDictionary = this.statisticDalManager.GetCountItemByTag(tag.Name);
                tagCountDictionary.Add(tag.Name, itemDictionary);
            }

            return tagCountDictionary;
        }
    }
}