// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TagDalManager.cs" company="">
//   
// </copyright>
// <summary>
//   The tag dal manager.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using Moody.Service.Domain;

namespace Moody.DAL
{
    using System.Data;
    using System.Data.SqlClient;

    using Moody.DAL.Utility;

    /// <summary>
    ///     The tag dal manager.
    /// </summary>
    public class TagDalManager
    {
        /// <summary>
        ///     The sql data manager.
        /// </summary>
        private readonly SqlDataManager sqlDataManager;

        /// <summary>
        ///     Initializes a new instance of the <see cref="TagDalManager" /> class.
        /// </summary>
        public TagDalManager()
        {
            this.sqlDataManager = new SqlDataManager();
        }

        /// <summary>
        /// The get tag id by name.
        /// </summary>
        /// <param name="tagName">
        /// The tag name.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int GetTagIdByName(string tagName)
        {
            // create Tag if not exist tag
            int tagId = 0;
            var sqlParameter = new SqlParameter[1];
            sqlParameter[0] = new SqlParameter("@Name", SqlDbType.VarChar) { Value = tagName };
            var dataTable = this.sqlDataManager.SelectProcedure("GetTagIdByName", sqlParameter);

            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    tagId = int.Parse(dataRow["TagId"].ToString());
                }
            }
            else
            {
                tagId = this.AddNewTag(tagName);
            }

            return tagId;
        }

        /// <summary>
        /// The add new tag.
        /// </summary>
        /// <param name="tagName">
        /// The tag name.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        private int AddNewTag(string tagName)
        {
            var sqlParameter = new SqlParameter[1];
            sqlParameter[0] = new SqlParameter("@Name", SqlDbType.VarChar) { Value = tagName };
            var tagId = this.sqlDataManager.InsertProcedureWithOutputInsertedId("AddTag", sqlParameter);
            return tagId;
        }

        /// <summary>
        /// The get all tags.
        /// </summary>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public List<Tag> GetAllTags()
        {
            List<Tag> tags = new List<Tag>();

            var query = "SELECT * FROM [Moody].[dbo].[Tags]";
            var dataTable = sqlDataManager.ExecuteSelectAllQuery(query);
            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    Tag tag = new Tag();
                    tag.TagId = int.Parse(dataRow["TagId"].ToString());
                    tag.Name = dataRow["Name"].ToString();

                    tags.Add(tag);
                }
            }
            return tags;
        }
    }
}