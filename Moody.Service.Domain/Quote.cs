// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Quote.cs" company="">
//   
// </copyright>
// <summary>
//   The quote.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Moody.Service.Domain
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    ///     The quote.
    /// </summary>
    public class Quote
    {
        // TODO QuoteId

        /// <summary>
        ///     Gets or sets the body.
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        ///     Gets or sets the author.
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        ///     Gets or sets the time created.
        /// </summary>
        public DateTime TimeCreated { get; set; }

        /// <summary>
        /// Gets or sets the tags.
        /// </summary>
        public List<string> Tags { get; set; }

        /// <summary>
        /// Gets or sets the quote id.
        /// </summary>
        public int QuoteId { get; set; }
    }
}