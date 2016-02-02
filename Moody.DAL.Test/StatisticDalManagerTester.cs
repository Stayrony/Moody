// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StatisticDalManagerTester.cs" company="">
//   
// </copyright>
// <summary>
//   The statistic dal manager tester.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Moody.DAL.Test
{
    using System;
    using System.Collections.Generic;

    using NUnit.Framework;

    /// <summary>
    /// The statistic dal manager tester.
    /// </summary>
    [TestFixture]
    class StatisticDalManagerTester
    {
        /// <summary>
        /// The set up.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.statisticDalManager = new StatisticDalManager();
        }

        /// <summary>
        /// The statistic dal manager.
        /// </summary>
        private StatisticDalManager statisticDalManager;

        /// <summary>
        /// The get count item by tag basic test.
        /// </summary>
        [Test]
        public void GetCountItemByTagBasicTest()
        {
            string tagName = "dreamy";
            Dictionary<string, int> itemCountDictionary = new Dictionary<string, int>();
            itemCountDictionary = this.statisticDalManager.GetCountItemByTag(tagName);
            Console.WriteLine("For Tag : " + tagName);
            foreach (KeyValuePair<string, int> keyValuePair in itemCountDictionary)
            {
                Console.WriteLine(keyValuePair.Key + " = " + keyValuePair.Value);
            }
        }
    }
}