// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StatisticManagerTester.cs" company="">
//   
// </copyright>
// <summary>
//   The statistic manager tester.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Moody.Service.BLL.Test
{
    using System;
    using System.Collections.Generic;

    using NUnit.Framework;

    /// <summary>
    /// The statistic manager tester.
    /// </summary>
    [TestFixture]
    public class StatisticManagerTester
    {
        /// <summary>
        /// The set up.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.statisticManager = new StatisticManager();
        }

        /// <summary>
        /// The statistic manager.
        /// </summary>
        private StatisticManager statisticManager;

        /// <summary>
        /// The get tag count dictionary.
        /// </summary>
        [Test]
        public void GetTagCountDictionary()
        {
            Dictionary<string, Dictionary<string, int>> tagCountDictionary = new Dictionary<string, Dictionary<string, int>>();
            tagCountDictionary = this.statisticManager.GetTagCountDictionary();
            foreach (var kvp in tagCountDictionary)
            {
                Console.WriteLine("For tag : " + kvp.Key);
                foreach (var keyValuePair in kvp.Value)
                {
                    Console.Write(keyValuePair.Key + " = " + keyValuePair.Value + "\t");
                }

                Console.WriteLine();
            }
        }
    }
}