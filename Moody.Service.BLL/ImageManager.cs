// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ImageManager.cs" company="">
//   
// </copyright>
// <summary>
//   The image manager.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Moody.Service.BLL
{
    using System;
    using System.Collections.Generic;

    using Moody.DAL;
    using Moody.Service.Domain;

    /// <summary>
    ///     The image manager.
    /// </summary>
    public class ImageManager
    {
        /// <summary>
        ///     The image dal manager.
        /// </summary>
        private readonly ImageDalManager imageDalManager = new ImageDalManager();

        /// <summary>
        ///     The get all images.
        /// </summary>
        /// <returns>
        ///     The <see cref="List" />.
        /// </returns>
        public List<Image> GetAllImages()
        {
            var images = this.imageDalManager.GetAll();
            return images;
        }

        /// <summary>
        /// The create image.
        /// </summary>
        /// <param name="newImage">
        /// The new image.
        /// </param>
        /// <returns>
        /// The <see cref="Image"/>.
        /// </returns>
        public Image CreateImage(Image newImage)
        {
            newImage.TimeCreated = DateTime.Now;
            newImage.Tags = newImage.Tags.ConvertAll(t => t.ToLower());
            this.imageDalManager.AddNewImage(newImage);
            return new Image();
        }

        /// <summary>
        /// The get images by tag.
        /// </summary>
        /// <param name="tag">
        /// The tag.
        /// </param>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public List<Image> GetImagesByTag(string tag)
        {
            return this.imageDalManager.GetImagesByTag(tag);
        }

        /// <summary>
        /// The delete image.
        /// </summary>
        /// <param name="image">
        /// The image.
        /// </param>
        public void DeleteImage(Image image)
        {
            // TODO delete image
        }
    }
}