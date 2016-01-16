// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QuoteManager.cs" company="">
//   
// </copyright>
// <summary>
//   The quote manager.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Moody.Service.BLL
{
    using System;
    using System.Collections.Generic;

    using Moody.DAL;
    using Moody.Service.Domain;

    /// <summary>
    ///     The quote manager.
    /// </summary>
    public class QuoteManager
    {
        /// <summary>
        ///     The quote dal manager.
        /// </summary>
        private readonly QuoteDalManager quoteDalManager = new QuoteDalManager();

        /// <summary>
        ///     The get all quotes.
        /// </summary>
        /// <returns>
        ///     The <see cref="List" />.
        /// </returns>
        public List<Quote> GetAllQuotes()
        {
            var quotes = new List<Quote>();
            quotes = this.quoteDalManager.GetAll();

            return quotes;
        }

        /// <summary>
        /// The create quote.
        /// </summary>
        /// <returns>
        /// The <see cref="Quote"/>.
        /// </returns>
        public Quote CreateQuote()
        {
            var newQuote = new Quote();

            /*
                * To insert date

               string date1="2013-12-12"; 
               DateTime date2;
               DateTime.TryParse(reader["datecolumn"], out date2);

               SqlCommand cmd= new SqlCommand("Insert into table (dateColumn) Values(@date2)",connection);
               cmd.Parameters.AddWithValue("@date2",date2.Date);
            */
            newQuote.TimeCreated = DateTime.Today;

            return newQuote;
        }

        /// <summary>
        /// The get quotes by tag.
        /// </summary>
        /// <param name="tag">
        /// The tag.
        /// </param>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public List<Quote> GetQuotesByTag(string tag)
        {
            List<Quote> quotes = new List<Quote>();

            return quotes;
        }
    }
}