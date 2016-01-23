// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Image.cs" company="">
//   
// </copyright>
// <summary>
//   The image.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Moody.Service.Domain
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    ///     The image.
    /// </summary>
    public class Image
    {
        /// <summary>
        ///     Gets or sets the image path.
        /// </summary>
        public string ImagePath { get; set; }

        /// <summary>
        ///     Gets or sets the time created.
        /// </summary>
        public DateTime TimeCreated { get; set; }

        /// <summary>
        ///     Gets or sets the tags.
        /// </summary>
        public List<string> Tags { get; set; }
    }
}