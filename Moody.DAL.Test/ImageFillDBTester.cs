// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ImageFillDBTester.cs" company="">
//   
// </copyright>
// <summary>
//   The image fill db tester.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Moody.DAL.Test
{
    using System;
    using System.Collections.Generic;

    using Moody.Service.Domain;

    using NUnit.Framework;

    /// <summary>
    /// The image fill db tester.
    /// </summary>
    [TestFixture]
    internal class ImageFillDBTester
    {
        /// <summary>
        ///     The set up.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.imageDalManager = new ImageDalManager();
        }

        /// <summary>
        ///     The image dal manager.
        /// </summary>
        private ImageDalManager imageDalManager;

        /// <summary>
        /// The fill image basic test.
        /// </summary>
        [Test]
        public void FillImageBasicTest()
        {
            Image image1 = new Image();
            image1.ImagePath = @"C:\Users\mizju\Downloads\05bd68e21096017b180e7c11b14ff906.jpg";
            image1.TimeCreated = DateTime.Now;
            Console.WriteLine(image1.TimeCreated.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            image1.Tags = new List<string> { "passionate" };
            this.imageDalManager.AddNewImage(image1);

            Image image2 = new Image();
            image2.ImagePath = @"C:\Users\mizju\Google Drive\audi-r8-gt-orange.jpg";
            image2.TimeCreated = DateTime.Now;
            Console.WriteLine(image2.TimeCreated.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            image2.Tags = new List<string> { "happy", "success", "dreamy" };
            this.imageDalManager.AddNewImage(image2);

            Image image3 = new Image();
            image3.ImagePath = @"C:\Users\mizju\Google Drive\Calendar 2016\Ideas\2631410-czs-1-888.jpg";
            image3.TimeCreated = DateTime.Now;
            Console.WriteLine(image3.TimeCreated.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            image3.Tags = new List<string> { "light" };
            this.imageDalManager.AddNewImage(image3);

            Image image4 = new Image();
            image4.ImagePath =
                @"C:\Users\mizju\Google Drive\Moody\Navigation\Images\893df7653cd21833b5e80476bd032520.jpg";
            image4.TimeCreated = DateTime.Now;
            Console.WriteLine(image4.TimeCreated.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            image4.Tags = new List<string> { "light", "romantic", "Courage" };
            this.imageDalManager.AddNewImage(image4);

            Image image5 = new Image();
            image5.ImagePath = @"C:\Users\mizju\Google Drive\Moody\Logo\preview.png";
            image5.TimeCreated = DateTime.Now;
            Console.WriteLine(image5.TimeCreated.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            image5.Tags = new List<string> { "gleeful" };
            this.imageDalManager.AddNewImage(image5);

            Image image6 = new Image();
            image6.ImagePath = @"C:\Users\mizju\Google Drive\Moody\Logo\368e8e24633131.5633777779427.jpg";
            image6.TimeCreated = DateTime.Now;
            Console.WriteLine(image6.TimeCreated.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            image6.Tags = new List<string> { "ambient", "sweet" };
            this.imageDalManager.AddNewImage(image6);
        }
    }
}