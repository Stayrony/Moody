// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ImageDalManager.cs" company="">
//   
// </copyright>
// <summary>
//   The image dal manager.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Globalization;
using System.Linq;

namespace Moody.DAL
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    using Moody.DAL.Utility;
    using Moody.Service.Domain;

    /// <summary>
    ///     The image dal manager.
    /// </summary>
    public class ImageDalManager
    {
        /// <summary>
        ///     The sql data manager.
        /// </summary>
        private readonly SqlDataManager sqlDataManager;

        /// <summary>
        ///     The table name.
        /// </summary>
        private readonly string tableName = "Images";

        /// <summary>
        ///     The tag dal manager.
        /// </summary>
        private readonly TagDalManager tagDalManager;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImageDalManager" /> class.
        /// </summary>
        public ImageDalManager()
        {
            this.sqlDataManager = new SqlDataManager();
            this.tagDalManager = new TagDalManager();
        }

        /// <summary>
        ///     The get all.
        /// </summary>
        /// <returns>
        ///     The <see cref="List" />.
        /// </returns>
        public List<Image> GetAll()
        {
            var images = new List<Image>();
            var query = "SELECT * FROM " + this.tableName;
            var dataTable = this.sqlDataManager.ExecuteSelectAllQuery(query);
            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    var image = new Image();
                    DateTime date;
                    int imageId;

                    imageId = int.Parse(dataRow["ImageId"].ToString());
                    image.ImagePath = dataRow["ImagePath"].ToString();
                    DateTime.TryParse(dataRow["TimeCreated"].ToString(), out date);
                    image.TimeCreated = date;
                    image.Tags = this.GetTagsByImageId(imageId);

                    images.Add(image);
                }
            }
            else
            {
                return null;
            }

            images = new List<Image>(images.OrderByDescending(i => i.TimeCreated));
            return images;
        }

        /// <summary>
        /// The get tags by image id.
        /// </summary>
        /// <param name="imageId">
        /// The image id.
        /// </param>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        private List<string> GetTagsByImageId(int imageId)
        {
            var tags = new List<string>();
            var sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@ImageId", SqlDbType.Int) { Value = imageId };
            var dataTable = this.sqlDataManager.SelectProcedure("GetTagByImageId", sqlParameters);

            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    tags.Add(dataRow["Name"].ToString());
                }
            }
            else
            {
                return null;
            }

            return tags;
        }

        /// <summary>
        /// The add new image.
        /// </summary>
        /// <param name="newImage">
        /// The new image.
        /// </param>
        /// <returns>
        /// The <see cref="Image"/>.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public Image AddNewImage(Image newImage)
        {
            int imageId;
            var sqlParameter = new SqlParameter[2];

            sqlParameter[0] = new SqlParameter("@ImagePath", SqlDbType.VarChar) { Value = newImage.ImagePath };
            sqlParameter[1] = new SqlParameter("@TimeCreated", SqlDbType.DateTime)
            {
                Value = newImage.TimeCreated
            };

            try
            {
                imageId = this.sqlDataManager.InsertProcedureWithOutputInsertedId("AddImage", sqlParameter);
            }
            catch (Exception exception)
            {
                throw exception;
            }

            foreach (var tag in newImage.Tags)
            {
                var tagId = this.tagDalManager.GetTagIdByName(tag);
                var sqlTagParameter = new SqlParameter[2];
                sqlTagParameter[0] = new SqlParameter("@ImageId", SqlDbType.Int) { Value = imageId };
                sqlTagParameter[1] = new SqlParameter("@TagId", SqlDbType.Int) { Value = tagId };
                this.sqlDataManager.InsertProcedure("BindingImageWithTag", sqlTagParameter);
            }

            return newImage;
        }

        /// <summary>
        /// The get images by tag.
        /// </summary>
        /// <param name="tagName">
        /// The tag name.
        /// </param>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public List<Image> GetImagesByTag(string tagName)
        {
            var images = new List<Image>();
            var sqlParameter = new SqlParameter[1];
            sqlParameter[0] = new SqlParameter("@Name", SqlDbType.VarChar) { Value = tagName };

            var dataTable = this.sqlDataManager.SelectProcedure("GetImageByTag", sqlParameter);

            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    var image = new Image();
                    DateTime date;
                    int imageId;

                    imageId = int.Parse(dataRow["ImageId"].ToString());
                    image.ImagePath = dataRow["ImagePath"].ToString();
                    DateTime.TryParse(dataRow["TimeCreated"].ToString(), out date);
                    image.TimeCreated = date;
                    image.Tags = this.GetTagsByImageId(imageId);

                    images.Add(image);
                }
            }
            else
            {
                return null;
            }

            images = new List<Image>(images.OrderByDescending(i => i.TimeCreated));
            return images;
        }

        /// <summary>
        /// The delete image.
        /// </summary>
        /// <param name="deletingImage">
        /// The deleting image.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int DeleteImage(Image deletingImage)
        {
            // TODO delete qoute
            return 0;
        }
    }
}