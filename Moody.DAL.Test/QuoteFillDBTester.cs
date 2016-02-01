// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QuoteFillDBTester.cs" company="">
//   
// </copyright>
// <summary>
//   The quote fill db tester.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Moody.DAL.Test
{
    using System;
    using System.Collections.Generic;

    using Moody.Service.Domain;

    using NUnit.Framework;

    /// <summary>
    /// The quote fill db tester.
    /// </summary>
    [TestFixture]
    public class QuoteFillDBTester
    {
        /// <summary>
        ///     The set up.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.quoteDalManager = new QuoteDalManager();
        }

        /// <summary>
        ///     The quote dal manager.
        /// </summary>
        private QuoteDalManager quoteDalManager;

        /// <summary>
        /// The fill quote basic test.
        /// </summary>
        [Test]
        public void FillQuoteBasicTest()
        {
            Quote quote1 = new Quote();
            quote1.Author = "Huckleberry";
            quote1.Body = "I am your huckleberry friend";
            quote1.Tags = new List<string> { "gleeful", "happy", "romantic", "sweet" };
            quote1.TimeCreated = DateTime.Now;
            this.quoteDalManager.AddNewQuote(quote1);
        }
    }
}