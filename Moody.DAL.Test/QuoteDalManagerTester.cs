// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QuoteDalManagerTester.cs" company="">
//   
// </copyright>
// <summary>
//   The quote dal manager tester.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Moody.DAL.Test
{
    using System;

    using NUnit.Framework;

    /// <summary>
    /// The quote dal manager tester.
    /// </summary>
    [TestFixture]
    public class QuoteDalManagerTester
    {
        /// <summary>
        /// The set up.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.quoteDalManager = new QuoteDalManager();
        }

        /// <summary>
        /// The quote dal manager.
        /// </summary>
        private QuoteDalManager quoteDalManager;

        /// <summary>
        /// The get quotes by tag basic test.
        /// </summary>
        [Test]
        public void GetQuotesByTagBasicTest()
        {
            var tagName = "dreamy";

            var quotesList = this.quoteDalManager.GetQuotesByTag(tagName);
            Assert.That(quotesList.Count, Is.EqualTo(1));

            foreach (var quote in quotesList)
            {
                Console.WriteLine(quote.Body);
                Console.WriteLine(" - " + quote.Author);
                Console.Write("Tags: ");
                foreach (var tag in quote.Tags)
                {
                    Console.Write(tag + ", ");
                }

                Console.WriteLine("\n");
            }
        }

        /// <summary>
        /// The get tags by quote id basic test.
        /// </summary>
        [Test]
        public void GetTagsByQuoteIdBasicTest()
        {
            var tags = this.quoteDalManager.GetTagsByQuoteId(1);
            foreach (var tag in tags)
            {
                Console.WriteLine(tag);
            }
        }

        [Test]
        public void GetAllBasicTest()
        {
            var quotesList = this.quoteDalManager.GetAll();

            foreach (var quote in quotesList)
            {
                Console.WriteLine(quote.Body);
                Console.WriteLine(" - " + quote.Author);
                Console.Write("Tags: ");
                foreach (var tag in quote.Tags)
                {
                    Console.Write(tag + ", ");
                }

                Console.WriteLine("\n");
            }
        }
    }
}