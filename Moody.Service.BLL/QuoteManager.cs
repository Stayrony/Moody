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
        /// <param name="newQuote">
        /// The new Quote.
        /// </param>
        /// <returns>
        /// The <see cref="Quote"/>.
        /// </returns>
        public Quote CreateQuote(Quote newQuote)
        {
            if (string.IsNullOrEmpty(newQuote.Author))
            {
                newQuote.Author = "Anonymous";
            }

            newQuote.TimeCreated = DateTime.Today;
            newQuote.Tags = newQuote.Tags.ConvertAll(t => t.ToLower());
            this.quoteDalManager.AddNewQuote(newQuote);

            /*
                * To insert date

               string date1="2013-12-12"; 
               DateTime date2;
               DateTime.TryParse(reader["datecolumn"], out date2);

               SqlCommand cmd= new SqlCommand("Insert into table (dateColumn) Values(@date2)",connection);
               cmd.Parameters.AddWithValue("@date2",date2.Date);
            */


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