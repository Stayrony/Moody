// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ImageDalManagerTester.cs" company="">
//   
// </copyright>
// <summary>
//   The image dal manager tester.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using Moody.Service.Domain;
using NUnit.Framework;

namespace Moody.DAL.Test
{
    // <summary>
    //   The image dal manager tester.
    // </summary>
    [TestFixture]
    public class ImageDalManagerTester
    {
        /// <summary>
        /// The set up.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.imageDalManager = new ImageDalManager();
        }

        /// <summary>
        /// The image dal manager.
        /// </summary>
        private ImageDalManager imageDalManager;

        /// <summary>
        /// The add new image basic test.
        /// </summary>
        [Test]
        public void AddImageBasicTest()
        {
            Image image = new Image();
            // image.ImagePath = @"C:/Users/mizju/Downloads/sister.jpg"; blurred-summer-background_23-2147511429.jpg
            // http://40.media.tumblr.com/56ed1be0dd63635dc504f2da630f1114/tumblr_nmnotqlXt51s4eggto1_1280.jpg
             image.ImagePath = @"C:\Users\mizju\Google Drive\Moody\Ideas\hand-painted-summer-card_23-2147511337.jpg";
            // image.ImagePath = @"C:\Users\mizju\Google Drive\Moody\Ideas\4fb32b7e1c947196ad9bbe5789c869d2.jpg";
            // image.ImagePath = @"C:\Users\mizju\OneDrive\Pictures\JPN_33_Miyajima_40.jpg";
            image.TimeCreated = DateTime.Now;
            Console.WriteLine(image.TimeCreated.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            image.Tags = new List<string>() { "gleeful", "light" };
            imageDalManager.AddNewImage(image);
        }

        /// <summary>
        /// The get all basic test.
        /// </summary>
        [Test]
        public void GetAllBasicTest()
        {
            var images = imageDalManager.GetAll();
            foreach (var image in images)
            {
                Console.WriteLine(image.ImagePath);
                Console.Write("Tags: ");
                foreach (var tag in image.Tags)
                {
                    Console.Write(tag + ", ");
                }
                Console.WriteLine("\n");
            }
        }

        /// <summary>
        /// The delete image basic test.
        /// </summary>
        [Test]
        public void DeleteImageBasicTest()
        {
            int imageId = 2;
            this.imageDalManager.DeleteImage(imageId);
        }

    }
}