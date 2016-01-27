// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QuoteDalManagerTester.cs" company="">
//   
// </copyright>
// <summary>
//   The quote dal manager tester.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using Moody.Service.Domain;

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

        /// <summary>
        /// The get all basic test.
        /// </summary>
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

        /// <summary>
        /// The add new quote basic test.
        /// </summary>
        [Test]
        public void AddNewQuoteBasicTest()
        {
            //var newQuote = new Quote();
            //newQuote.Author = "Winston Churchill";
            //newQuote.Body = "Success is not final, failure is not fatal: it is the courage to continue that counts.";
            //newQuote.Tags = new List<string> { "Courage", "Failure", "success" };
            //newQuote.TimeCreated = DateTime.Now;
            //this.quoteDalManager.AddNewQuote(newQuote);

            //var newQuote = new Quote();
            //newQuote.Author = "Robert Downey Jr.";
            //newQuote.Body = "Listen, smile, agree, and then do whatever the fuck you were gonna do anyway.";
            //newQuote.Tags = new List<string> { "dramatic", "sweet", "success" };
            //newQuote.TimeCreated = DateTime.Now;
            //this.quoteDalManager.AddNewQuote(newQuote);

            //var newQuote = new Quote();
            //newQuote.Author = "Winston Churchill";
            //newQuote.Body = "Success is not final, failure is not fatal: it is the courage to continue that counts.";
            //newQuote.Tags = new List<string> { "gleeful", "dreamy", "success" };
            //newQuote.TimeCreated = DateTime.Now;
            //this.quoteDalManager.AddNewQuote(newQuote);

            var newQuote = new Quote();
            newQuote.Author = "Huckleberry";
            newQuote.Body = "I am your huckleberry friend";
            newQuote.Tags = new List<string> { "gleeful", "happy", "romantic", "sweet" };
            newQuote.TimeCreated = DateTime.Now;
            this.quoteDalManager.AddNewQuote(newQuote);
        }
    }
}