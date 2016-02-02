// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StatisticDalManager.cs" company="">
//   
// </copyright>
// <summary>
//   The statistic manager.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Moody.DAL
{
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    using Moody.DAL.Utility;

    /// <summary>
    /// The statistic manager.
    /// </summary>
    public class StatisticDalManager
    {
        /// <summary>
        /// The sql data manager.
        /// </summary>
        private readonly SqlDataManager sqlDataManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="StatisticDalManager"/> class.
        /// </summary>
        public StatisticDalManager()
        {
            this.sqlDataManager = new SqlDataManager();
        }

        /// <summary>
        /// The get count item by tag.
        /// </summary>
        /// <param name="tagName">
        /// The tag name.
        /// </param>
        /// <returns>
        /// The <see cref="Dictionary"/>.
        /// </returns>
        public Dictionary<string, int> GetCountItemByTag(string tagName)
        {
            int quoteTagCount;
            int imageTagCount;
            var itemCountDictionary = new Dictionary<string, int>();

            SqlParameter[] sqlParameter = new SqlParameter[1];
            sqlParameter[0] = new SqlParameter("@Name", SqlDbType.VarChar) { Value = tagName };
            DataTable dataTable = this.sqlDataManager.SelectProcedure("GetCountItemByTag", sqlParameter);

            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    quoteTagCount = int.Parse(dataRow["QuoteTagCount"].ToString());
                    imageTagCount = int.Parse(dataRow["ImageTagCount"].ToString());

                    itemCountDictionary.Add(nameof(quoteTagCount), quoteTagCount);
                    itemCountDictionary.Add(nameof(imageTagCount), imageTagCount);
                }
            }

            return itemCountDictionary;
        }
    }
}